import React from 'react';
import PropTypes from 'prop-types';
import { makeStyles } from '@material-ui/core/styles';
import Breadcrumbs from '@material-ui/core/Breadcrumbs';
import Typography from '@material-ui/core/Typography';
import Link from '@material-ui/core/Link';
import NavigateNextIcon from '@material-ui/icons/NavigateNext';
import { RouteItems } from '../../shared/route-paths';
import './breadcrumb.css'

const useStyles = makeStyles((theme) => ({
    root: {
        '& > * + *': {
            marginTop: theme.spacing(2),
        },
    },
}));

const BreadcrumbCustom = (props) => {
    const classes = useStyles();

    return (
        <div className='breadcrumbcustom'>

            <div className={classes.root} >
                <Breadcrumbs separator={<NavigateNextIcon fontSize="small" />} aria-label="breadcrumb">

                    {props.routes.map((item, index) => {
                        return (
                            <div key={index}>

                                {index !== (props.routes.length - 1) &&
                                    <Link color="inherit" href={item.routeItem.route} onClick={item.routeItem.handleClick}>
                                        {item.routeItem.label}
                                    </Link>
                                }

                                {index === (props.routes.length - 1) &&
                                    <Typography color="textPrimary">{item.routeItem.label}</Typography>
                                }
                            </div>
                        )
                    })}
                </Breadcrumbs>
            </div>
        </div>
    )
}

BreadcrumbCustom.propTypes = {
    routeItem: PropTypes.array.isRequired
}

BreadcrumbCustom.defaultProps = {
    routeItem: [{
        route: RouteItems.ROOT.route,
        label: RouteItems.ROOT.label
    }]
}

export default BreadcrumbCustom;