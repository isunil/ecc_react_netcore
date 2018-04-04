import React from 'react';
import Select from './select';
import ResultCard from './resultCard';

const baseUrl = "http://localhost:5000/api/";

export default class ColorCodeSelectionForm extends React.Component {
    constructor() {
        super();
        this.state = {
            ColorCodes: [],
            MultiplyerColorCodes: [],
            TolaranceColorCodes: [],
            selectedBandAColor: '',
            selectedBandBColor: '',
            selectedBandCColor: '',
            selectedBandDColor: '',
            minimumOhmValue: '',
            maximumOhmValue: ''
        };
        this.handleBandAColorSelect = this
            .handleBandAColorSelect
            .bind(this);
        this.handleBandBColorSelect = this
            .handleBandBColorSelect
            .bind(this);
        this.handleBandCColorSelect = this
            .handleBandCColorSelect
            .bind(this);
        this.handleBandDColorSelect = this
            .handleBandDColorSelect
            .bind(this);
        this.handleFormSubmit = this
            .handleFormSubmit
            .bind(this);
        this.handleClearForm = this
            .handleClearForm
            .bind(this);
    }

    componentDidMount() {
        fetch(`${baseUrl}colorcodes`)
            .then(response => response.json())
            .then(data => {
                this.setState({ColorCodes: data, loading: false});
            });
        fetch(`${baseUrl}multiplyercolors`)
            .then(response => response.json())
            .then(data => {
                this.setState({MultiplyerColorCodes: data, loading: false});
            });
        fetch(`${baseUrl}tolarancecolors`)
            .then(response => response.json())
            .then(data => {
                this.setState({TolaranceColorCodes: data, loading: false});
            });
    }
    handleBandAColorSelect(e) {
        this.setState({selectedBandAColor: e.target.value});
    }
    handleBandBColorSelect(e) {
        this.setState({selectedBandBColor: e.target.value});
    }
    handleBandCColorSelect(e) {
        this.setState({selectedBandCColor: e.target.value});
    }
    handleBandDColorSelect(e) {
        this.setState({selectedBandDColor: e.target.value});
    }
    resetSelections = () => (this.setState({
        minimumOhmValue: '',
        maximumOhmValue: '',
        selectedBandAColor: '',
        selectedBandBColor: '',
        selectedBandCColor: '',
        selectedBandDColor: ''
    }));

    handleClearForm(e) {
        e.preventDefault();
        this.resetSelections();
    }
    handleFormSubmit(e) {
        e.preventDefault();

        const formPayload = {
            BandAColor: this.state.selectedBandAColor,
            BandBColor: this.state.selectedBandBColor,
            BandCColor: this.state.selectedBandCColor,
            BandDColor: this.state.selectedBandDColor
        };

        fetch(`${baseUrl}ohmvalue/`, {
            method: "POST",
            headers: {
                'Access-Control-Allow-Origin': '*',
                'Content-Type': 'application/json'
            },
                crossDomain: true,
                body: JSON.stringify(formPayload)
            })
            .then(response => response.json())
            .then(data => {
                this.setState({minimumOhmValue: data.minimumOhmValue, maximumOhmValue: data.maximumOhmValue});
            });
        //this.handleClearForm(e);
    }
    render() {
        return (
            <form className="" onSubmit={this.handleFormSubmit}>
                <div className="d-flex justify-content-around">
                    <div className="col-sm">
                        <Select
                            name={'BandAColor'}
                            placeholder={'Band A Color'}
                            controlFunc={this.handleBandAColorSelect}
                            options={this.state.ColorCodes}
                            selectedOption={this.state.selectedBandAColor}/>
                    </div>
                    <div className="col-sm">
                        <Select
                            name={'BandBColor'}
                            placeholder={'Band B Color'}
                            controlFunc={this.handleBandBColorSelect}
                            options={this.state.ColorCodes}
                            selectedOption={this.state.selectedBandBColor}/>
                    </div>
                    <div className="col-sm">
                        <Select
                            name={'BandCColor'}
                            placeholder={'Band C Color'}
                            controlFunc={this.handleBandCColorSelect}
                            options={this.state.MultiplyerColorCodes}
                            selectedOption={this.state.selectedBandCColor}/>
                    </div>
                    <div className="col-sm">
                        <Select
                            name={'BandDColor'}
                            placeholder={'Band D Color'}
                            controlFunc={this.handleBandDColorSelect}
                            options={this.state.TolaranceColorCodes}
                            selectedOption={this.state.selectedBandDColor}/>
                    </div>
                </div>
                <br/>
                <div className="d-flex justify-content-center">
                    <div className="form-group">
                        <input
                            type="submit"
                            className="btn btn-primary float-left mr-2"
                            value="Submit"/>
                        <button className="btn btn-primary float-left" onClick={this.handleClearForm}>Clear form</button>
                    </div>
                </div>

                <ResultCard
                    minimumOhmValue={this
                    .state
                    .minimumOhmValue
                    .toString()}
                    maximumOhmValue={this
                    .state
                    .maximumOhmValue
                    .toString()}/>
            </form>
        );

    }
}