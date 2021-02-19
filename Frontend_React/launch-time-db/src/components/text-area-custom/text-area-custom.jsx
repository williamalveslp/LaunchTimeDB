import React from 'react';
import PropTypes from 'prop-types';
import TextField from '@material-ui/core/TextField';

const TextAreaCustom = (props) => {
    const { id, name, label, value, rowMax, maxLength, onChange, autoComplete, isHandleChange, required } = props;

    return (
        <>
            {!isHandleChange && (
                <TextField
                    id={id}
                    name={name}
                    label={label}
                    multiline
                    rowsMax={rowMax}
                    fullWidth
                    required={required}
                    inputProps={{
                        maxLength: { maxLength },
                        autoComplete: autoComplete ? 'onn' : 'off'
                    }}
                    value={value}
                    onChange={(e) => onChange(e.target.value)}
                />
            )}

            {isHandleChange && (
                <TextField
                    id={id}
                    name={name}
                    label={label}
                    multiline
                    rowsMax={rowMax}
                    fullWidth
                    required={required}
                    inputProps={{
                        maxLength: { maxLength },
                        autoComplete: autoComplete ? 'onn' : 'off'
                    }}
                    onChange={onChange}
                />
            )}

        </>
    )
}

TextAreaCustom.defaultPros = {
    id: '',
    label: '',
    maxLength: 1,
    required: false,
    rowsMax: 1,
    autoComplete: false,
    onChange: () => { }
}

TextAreaCustom.propTypes = {
    id: PropTypes.string,
    label: PropTypes.string.isRequired,
    maxLength: PropTypes.number.isRequired,
    required: PropTypes.bool,
    rowsMax: PropTypes.number.isRequired,
    autoComplete: PropTypes.bool,
    onChange: PropTypes.func.isRequired
}

export default TextAreaCustom;