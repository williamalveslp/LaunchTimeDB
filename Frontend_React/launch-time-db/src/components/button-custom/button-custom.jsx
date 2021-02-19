import React from 'react';
import Button from '@material-ui/core/Button';
import PropTypes from 'prop-types';

const ButtonCustom = (props) => {
    const { label, type, color, onClick } = props;

    return (
        <Button
            fullWidth
            variant="contained"
            color={color}
            type={type}
            onClick={onClick}
        >{props.children}{label}
        </Button>
    )
}

ButtonCustom.defaultProps = {
    label: '',
    color: 'primary',
    type: 'button',
    onClick: () => { }
}

ButtonCustom.propTypes = {
    label: PropTypes.string.isRequired,
    color: PropTypes.string.isRequired,
    type: PropTypes.string.isRequired,
    onClick: PropTypes.func.isRequired
}

export default ButtonCustom;