import React, {Component} from 'react';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import ColorCodeSelectionForm from './Components/colorCodeSelectionForm';

class App extends Component {
  render() {
    return (
      <div>
        <header className="navbar navbar-dark bg-dark">
          <button
            className="navbar-toggler"
            type="button"
            data-toggle="collapse"
            data-target="#navbarTogglerDemo01"
            aria-controls="navbarTogglerDemo01"
            aria-expanded="false"
            aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
          </button>
        </header>
        <div id="container" className="container">
          <div className="row">
            <div className="col-sm-12 offset-sm-1 text-center">
              <h1 className="display-1">&nbsp;</h1>
              <div className="col-sm-10 text-center">
                <h3 className="display-4">Electronic Color Coding</h3>
                <br/>
                <ColorCodeSelectionForm/>
              </div>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default App;