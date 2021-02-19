import React, { useState } from 'react';
import PropTypes from 'prop-types';
import clsx from 'clsx';
import { lighten, makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TablePagination from '@material-ui/core/TablePagination';
import TableRow from '@material-ui/core/TableRow';
import TableSortLabel from '@material-ui/core/TableSortLabel';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import Paper from '@material-ui/core/Paper';
import Checkbox from '@material-ui/core/Checkbox';
import IconButton from '@material-ui/core/IconButton';
import Tooltip from '@material-ui/core/Tooltip';
import DeleteIcon from '@material-ui/icons/Delete';
import Link from '@material-ui/core/Link';

function descendingComparator(a, b, orderBy) {
  if (b[orderBy] < a[orderBy]) {
    return -1;
  }
  if (b[orderBy] > a[orderBy]) {
    return 1;
  }
  return 0;
}

function getComparator(order, orderBy) {
  return order === 'desc'
    ? (a, b) => descendingComparator(a, b, orderBy)
    : (a, b) => -descendingComparator(a, b, orderBy);
}

function stableSort(array, comparator) {
  const stabilizedThis = array.map((el, index) => [el, index]);
  stabilizedThis.sort((a, b) => {
    const order = comparator(a[0], b[0]);
    if (order !== 0) return order;
    return a[1] - b[1];
  });
  return stabilizedThis.map((el) => el[0]);
}

const EnhancedTableHead = (props) => {
  const { classes, onSelectAllClick, order, orderBy, numSelected, rowCount, onRequestSort } = props;
  const createSortHandler = (property) => (event) => {
    onRequestSort(event, property);
  };

  return (
    <TableHead>
      <TableRow>
        <TableCell padding="checkbox">

          {props.isDeleteMode &&
            <Checkbox
              indeterminate={numSelected > 0 && numSelected < rowCount}
              checked={rowCount > 0 && numSelected === rowCount}
              onChange={onSelectAllClick}
              inputProps={{ 'aria-label': 'select all desserts' }}
            />
          }

        </TableCell>
        {props.headers.map((headerItem) => (
          <TableCell
            key={headerItem.id}
            align={headerItem.numeric ? 'right' : 'left'}
            padding={headerItem.disablePadding ? 'none' : 'default'}
            sortDirection={orderBy === headerItem.id ? order : false}
          >
            <TableSortLabel
              active={orderBy === headerItem.id}
              direction={orderBy === headerItem.id ? order : 'asc'}
              onClick={createSortHandler(headerItem.id)}
            >
              {headerItem.label}
              {orderBy === headerItem.id ? (
                <span className={classes.visuallyHidden}>
                  {order === 'desc' ? 'sorted descending' : 'sorted ascending'}
                </span>
              ) : null}
            </TableSortLabel>
          </TableCell>
        ))}
      </TableRow>
    </TableHead>
  );
}

EnhancedTableHead.propTypes = {
  classes: PropTypes.object.isRequired,
  numSelected: PropTypes.number.isRequired,
  onRequestSort: PropTypes.func.isRequired,
  onSelectAllClick: PropTypes.func.isRequired,
  order: PropTypes.oneOf(['asc', 'desc']).isRequired,
  orderBy: PropTypes.string.isRequired,
  rowCount: PropTypes.number.isRequired,
  isDeleteMode: PropTypes.bool
};

const useToolbarStyles = makeStyles((theme) => ({
  root: {
    paddingLeft: theme.spacing(2),
    paddingRight: theme.spacing(1),
  },
  highlight:
    theme.palette.type === 'light'
      ? {
        color: theme.palette.secondary.main,
        backgroundColor: lighten(theme.palette.secondary.light, 0.85),
      }
      : {
        color: theme.palette.text.primary,
        backgroundColor: theme.palette.secondary.dark,
      },
  title: {
    flex: '1 1 100%',
  },
}));

const EnhancedTableToolbar = (props) => {
  const classes = useToolbarStyles();
  const { numSelected } = props;

  return (
    <Toolbar
      className={clsx(classes.root, {
        [classes.highlight]: numSelected > 0,
      })}
    >
      {numSelected > 0 ? (
        <Typography className={classes.title} color="inherit" variant="subtitle1" component="div">
          {numSelected} selecionado(s)
        </Typography>
      ) : (
          <Typography className={classes.title} variant="h6" id="tableTitle" component="div">
            {props.title}
          </Typography>
        )}

      {numSelected > 0 ? (
        <Tooltip title="Excluir">
          <IconButton aria-label="delete">
            <DeleteIcon />
          </IconButton>
        </Tooltip>
      ) : (
          <>
          </>
        )}

      { /* 
      import FilterListIcon from '@material-ui/icons/FilterList';
      {numSelected > 0 ? (
        <Tooltip title="Excluir">
          <IconButton aria-label="delete">
            <DeleteIcon />
          </IconButton>
        </Tooltip>
      ) : (
          <Tooltip title="Filtrar lista">
            <IconButton aria-label="filter list">
              <FilterListIcon />
            </IconButton>
          </Tooltip>
        )} */}
    </Toolbar>
  );
};

EnhancedTableToolbar.propTypes = {
  numSelected: PropTypes.number.isRequired,
};

const useStyles = makeStyles((theme) => ({
  root: {
    width: '100%',
  },
  paper: {
    width: '100%',
    marginBottom: theme.spacing(2),
  },
  table: {
    minWidth: 750,
  },
  visuallyHidden: {
    border: 0,
    clip: 'rect(0 0 0 0)',
    height: 1,
    margin: -1,
    overflow: 'hidden',
    padding: 0,
    position: 'absolute',
    top: 20,
    width: 1,
  },
}));

//---------------------------------------------------

const TableSelectionCustom = (props) => {
  const classes = useStyles();
  const [orderBy, setOrderBy] = useState(props.keyOrderByDefault);
  const [order, setOrder] = useState(props.orderByDefault ? props.orderByDefault : 'asc');
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(5);
  const dense = true;

  const handleRequestSort = (event, property) => {
    const isAsc = orderBy === property && order === 'asc';
    setOrder(isAsc ? 'desc' : 'asc');
    setOrderBy(property);
  };

  const handleSelectAllClick = (event) => {
    if (event.target.checked) {
      // Get the values from specific property.
      const newSelecteds = props.rows.map((n) => n.key);

      props.handleItemsSelected(newSelecteds);
      return;
    }
    props.handleItemsSelected([]);
  };

  // Row clicked.
  const handleClick = (event, value) => {

    const selectedIndex = props.getItemsSelected.indexOf(value);
    let newSelected = [];

    if (selectedIndex === -1) {
      newSelected = newSelected.concat(props.getItemsSelected, value);
    } else if (selectedIndex === 0) {
      newSelected = newSelected.concat(props.getItemsSelected.slice(1));
    } else if (selectedIndex === props.getItemsSelected.length - 1) {
      newSelected = newSelected.concat(props.getItemsSelected.slice(0, -1));
    } else if (selectedIndex > 0) {
      newSelected = newSelected.concat(
        props.getItemsSelected.slice(0, selectedIndex),
        props.getItemsSelected.slice(selectedIndex + 1),
      );
    }

    props.handleItemsSelected(newSelected);
  };

  const handleChangePage = (event, newPage) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (event) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

  const isSelected = (keyValue) => props.getItemsSelected.indexOf(keyValue) !== -1;
  const emptyRows = rowsPerPage - Math.min(rowsPerPage, props.rows.length - page * rowsPerPage);

  return (
    <div className={classes.root}>
      <Paper className={classes.paper}>
        <EnhancedTableToolbar
          title={props.title}
          numSelected={props.getItemsSelected.length}
        />
        <TableContainer>
          <Table
            className={classes.table}
            aria-labelledby="tableTitle"
            size={dense ? 'small' : 'medium'}
            aria-label="enhanced table"
          >
            <EnhancedTableHead
              classes={classes}
              numSelected={props.getItemsSelected.length}
              order={order}
              orderBy={orderBy}
              onSelectAllClick={handleSelectAllClick}
              onRequestSort={handleRequestSort}
              rowCount={props.rows.length}
              headers={props.headers}
              isDeleteMode={props.isDeleteMode}
            />
            <TableBody>
              {stableSort(props.rows, getComparator(order, orderBy))
                .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                .map((row, index) => {

                  const rowKey = row.key;
                  const isItemSelected = isSelected(row.key);
                  const labelId = `enhanced-table-checkbox-${index}`;

                  const valuesFromRow = Object.values(row);
                  valuesFromRow.shift();

                  return (
                    <TableRow
                      hover
                      onClick={(event) => !props.isDeleteMode ? () => { } : handleClick(event, rowKey)}
                      role="checkbox"
                      aria-checked={isItemSelected}
                      tabIndex={-1}
                      key={rowKey}
                      selected={isItemSelected}
                    >
                      <TableCell padding="checkbox">
                        {props.isDeleteMode &&
                          <Checkbox
                            checked={isItemSelected}
                            inputProps={{ 'aria-labelledby': labelId }}
                          />
                        }
                      </TableCell>

                      {valuesFromRow.map((itemRowValue, indexRowValue) => (
                        displayRow(itemRowValue, indexRowValue, `${labelId}-${indexRowValue}`, `${props.linkToOpen}${rowKey}`, props.isDeleteMode)
                      ))}

                    </TableRow>
                  );
                })}
              {emptyRows > 0 && (
                <TableRow style={{ height: (dense ? 33 : 53) * emptyRows }}>
                  <TableCell colSpan={6} />
                </TableRow>
              )}
            </TableBody>
          </Table>
        </TableContainer>
        <TablePagination
          rowsPerPageOptions={[5, 10, 15]}
          component="div"
          count={props.rows.length}
          rowsPerPage={rowsPerPage}
          page={page}
          onChangePage={handleChangePage}
          onChangeRowsPerPage={handleChangeRowsPerPage}
        />
      </Paper>
    </div>
  );
}

function displayRow(itemRowValue, indexRowValue, key, linkToOpen, isDeleteMode) {

  if (indexRowValue > 0) { // Simple column.
    return (
      <>
        <TableCell align='left' id={key} key={key}>
          {itemRowValue}
        </TableCell>
      </>
    )
  }
  else {
    return (
      <>
        <TableCell component="th" scope="row" padding="none" id={key} key={key}>
          {isDeleteMode &&
            <>
              {itemRowValue}
            </>
          }

          {!isDeleteMode &&
            <Link href={linkToOpen} onClick={() => { }}>
              {itemRowValue}
            </Link>
          }

        </TableCell>
      </>
    )
  }
}

TableSelectionCustom.defaultProps = {
  title: '',
  headers: [],
  rows: [],
  keyOrderByDefault: '',
  orderByDefault: '',
  isDeleteMode: true,
  handleItemsSelected: () => { }
}

TableSelectionCustom.propTypes = {
  title: PropTypes.string.isRequired,
  headers: PropTypes.array.isRequired,
  rows: PropTypes.array.isRequired,
  keyOrderByDefault: PropTypes.string.isRequired,
  orderByDefault: PropTypes.string.isRequired,
  isDeleteMode: PropTypes.bool.isRequired,
  handleItemsSelected: PropTypes.func.isRequired
}

export default TableSelectionCustom;