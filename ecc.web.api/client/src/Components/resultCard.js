import React from 'react';
import {string} from 'prop-types';
import _ from 'lodash';

const ResultCard = (props) => (
    <div>
        {!_.isEmpty(props.minimumOhmValue) && !_.isEmpty(props.maximumOhmValue) && <div className="row d-flex justify-content-center">
            <div className="col-sm-6">
                <div className="card">
                    <div className="card-body">
                        <p>Minimum Ohm:
                            <b>
                                {props.minimumOhmValue}</b>
                        </p>
                        <p>Maximum Ohm:
                            <b>{props.maximumOhmValue}</b>
                        </p>
                    </div>
                </div>
            </div>
        </div>}
    </div>
);

ResultCard.propTypes = {
    maximumOhmValue: string.isRequired,
    minimumOhmValue: string.isRequired
};

export default ResultCard;