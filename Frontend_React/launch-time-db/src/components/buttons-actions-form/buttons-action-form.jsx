import React from 'react';
import PropTypes from 'prop-types';
import Grid from '@material-ui/core/Grid';
import ButtonCustom from '../../components/button-custom';
import ChevronLeftIcon from '@material-ui/icons/ChevronLeft';

const ButtonsActionForm = (props) => {

    return (
        <>
            <Grid container spacing={props.spacingBetweenRows}>
                <Grid item xs={props.xlBackButton}>
                    <ButtonCustom
                        label='Voltar'
                        color='default'
                        onClick={() => window.history.back()}
                    ><ChevronLeftIcon />
                    </ButtonCustom>
                </Grid>

                <Grid item xs={props.xlSaveButton}>
                    <ButtonCustom
                        label='Salvar'
                        type='submit'
                    />
                </Grid>

                <Grid item xs={props.xlDefault}>
                </Grid>
            </Grid>
        </>
    )
}

ButtonsActionForm.propTypes = {
    spacingBetweenRows: PropTypes.number,
    xlBackButton: PropTypes.number,
    xlSaveButton: PropTypes.number,
    xlDefault: PropTypes.number
}

ButtonsActionForm.defaultProps = {
    spacingBetweenRows: 2,
    xlBackButton: 2,
    xlSaveButton: 2,
    xlDefault: 6
}

export default ButtonsActionForm;