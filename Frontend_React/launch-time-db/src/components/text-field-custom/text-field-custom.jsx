import React from 'react';
import TextField from '@material-ui/core/TextField';
import PropTypes from 'prop-types';

const TextFieldCustom = (props) => {
    const { id, name, label, value, maxLength, onChange, required, autoComplete, isHandleChange } = props;

    debugger;

    return (
        <>
            {!isHandleChange && (
                <TextField
                    id={id}
                    label={label}
                    name={name}
                    fullWidth
                    required={required}
                    inputProps={{
                        maxLength: maxLength,
                        autoComplete: autoComplete ? 'onn' : 'off'
                    }}
                    value={value}
                    onChange={(e) => onChange(e.target.value)}
                />
            )}

            {isHandleChange && (
                <TextField
                    id={id}
                    label={label}
                    name={name}
                    fullWidth
                    required={required}
                    inputProps={{
                        maxLength: maxLength,
                        autoComplete: autoComplete ? 'onn' : 'off'
                    }}
                    onChange={onChange}
                />
            )}
        </>
    )
}

TextFieldCustom.defaultProps = {
    id: '',
    label: '',
    maxLength: 1,
    required: false,
    isHandleChange: false,
    autoComplete: false,
    onChange: () => { }
}

TextFieldCustom.propTypes = {
    id: PropTypes.string.isRequired,
    label: PropTypes.string.isRequired,
    maxLength: PropTypes.number.isRequired,
    required: PropTypes.bool.isRequired,
    isHandleChange: PropTypes.bool.isRequired,
    autoComplete: PropTypes.bool,
    onChange: PropTypes.func.isRequired
}

export default TextFieldCustom;