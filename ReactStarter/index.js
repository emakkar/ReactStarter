import React, { Component } from 'react';
import ReactDOM from "react-dom";

class Welcome extends Component {
    render() {
        return (<p>Hello World</p>);
    }
}

ReactDOM.render(<Welcome />, document.getElementById("app"));