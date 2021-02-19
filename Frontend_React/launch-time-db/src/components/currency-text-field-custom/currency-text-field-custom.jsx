import React from 'react';
import CurrencyTextField from '@unicef/material-ui-currency-textfield'
import PropTypes from 'prop-types';

const CurrencyTextFieldCustom = (props) => {

    const { id, name, label, currencySymbol, required, value, onChange, isHandleChange } = props;

    return (
        <>
            {!isHandleChange && (
                <CurrencyTextField
                    id={id}
                    name={name}
                    label={label}
                    variant="standard"
                    currencySymbol={currencySymbol}
                    minimumValue="0"
                    outputFormat="string"
                    decimalCharacter="."
                    digitGroupSeparator=","
                    fullWidth
                    required={required}
                    value={value}
                    onChange={(e) => onChange(e)}
                />
            )}

            {isHandleChange && (
                <CurrencyTextField
                    id={id}
                    name={name}
                    label={label}
                    variant="standard"
                    currencySymbol={currencySymbol}
                    minimumValue="0"
                    outputFormat="string"
                    decimalCharacter="."
                    digitGroupSeparator=","
                    fullWidth
                    required={required}
                    value={value}
                    onChange={onChange}
                />
            )}
        </>
    )
}

CurrencyTextFieldCustom.propTypes = {
    id: PropTypes.string.isRequired,
    label: PropTypes.string.isRequired,
    currencySymbol: PropTypes.string,
    value: PropTypes.number,
    required: PropTypes.bool,
    onChange: PropTypes.func
}

CurrencyTextFieldCustom.defaultProps = {
    id: `id_${new Date().getMilliseconds}`,
    label: 'Currency Field Default',
    currencySymbol: 'R$',
    value: 0,
    required: false,
    onChange: () => { }
}

export default CurrencyTextFieldCustom;


