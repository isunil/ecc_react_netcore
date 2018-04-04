import React from 'react';
import {string, array, func} from 'prop-types';
const Select = (props) => (
    <div className="form-group">
        <select
            name={props.name}
            value={props.selectedOption}
            onChange={props.controlFunc}
            className="form-select">
            <option value="">{props.placeholder}</option>
            {props
                .options
                .map(opt => {
                    return (
                        <option key={opt} value={opt}>{opt}</option>
                    );
                })}
        </select>
    </div>
);

Select.propTypes = {
    name: string.isRequired,
    options: array.isRequired,
    selectedOption: string,
    controlFunc: func.isRequired,
    placeholder: string
};

export default Select;