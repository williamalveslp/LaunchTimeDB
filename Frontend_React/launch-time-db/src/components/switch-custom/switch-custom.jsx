import React from 'react';
import PropTypes from 'prop-types';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Switch from '@material-ui/core/Switch';

const SwitchCustom = (props) => {
    const { label, checked, onChange, name } = props;
    
    return (
        <FormControlLabel
            label={label}
            control={
                <Switch
                    checked={checked}
                    onChange={onChange}
                    name={name}
                />
            }
        />
    )
}

SwitchCustom.defaultProps = {
    checked: false,
    handleChange: () => { },
    name: ''
}

SwitchCustom.propTypes = {
    checked: PropTypes.bool.isRequired,
    handleChange: PropTypes.func.isRequired,
    name: PropTypes.string.isRequired
}

export default SwitchCustom;