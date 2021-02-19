import React from 'react';
import PropTypes from 'prop-types';
import Select from '@material-ui/core/Select';
import MenuItem from '@material-ui/core/MenuItem';
import InputLabel from '@material-ui/core/InputLabel';
import FormControl from '@material-ui/core/FormControl';

const SelectCustom = (props) => {

    const { id, name, value, label, required, items, onChange, isHandleChange } = props;

    return (
        <>
            <FormControl required={required} fullWidth>
                <InputLabel id={`${id}-label`}>{label}</InputLabel>

                {!isHandleChange && (
                    <Select
                        labelId={`${id}-label`}
                        id={id}
                        name={name}
                        value={value}
                        onChange={(e) => onChange(e.target.value)}
                    >
                        {items.map((item, index) => (
                            <MenuItem key={index} value={item.key}>{item.label}</MenuItem>
                        ))}
                    </Select>
                )}

                {isHandleChange && (
                    <Select
                        labelId={`${id}-label`}
                        id={id}
                        name={name}
                        value={value}
                        onChange={onChange}
                    >
                        {items.map((item, index) => (
                            <MenuItem key={index} value={item.key}>{item.label}</MenuItem>
                        ))}
                    </Select>
                )}

            </FormControl>
        </>
    )
}

SelectCustom.propTypes = {
    id: PropTypes.string.isRequired,
    label: PropTypes.string.isRequired,
    value: PropTypes.any.isRequired,
    items: PropTypes.array.isRequired,
    onChange: PropTypes.func.isRequired,
    isHandleChange: PropTypes.bool.isRequired,
    required: PropTypes.bool.isRequired
}

SelectCustom.defaultProps = {
    id: `id_${new Date().getMilliseconds}`,
    label: 'Select Field Default',
    value: 0,
    items: [{
        key: 0,
        label: 'Selecione'
    }],
    onChange: () => { },
    isHandleChange: false,
    required: false
}

export default SelectCustom;