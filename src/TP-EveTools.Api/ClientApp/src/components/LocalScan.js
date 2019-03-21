import React, { Component } from "react";
import ApiService from "../services/ApiService";

class LocalScan extends Component {
    state = {
        LocalScan: []
    }
  constructor(props) {
    super(props);
    this.apiService = new ApiService();
  }

  componentDidMount() {
    this.apiService.getLocalScan(this.props.localscan).then(post => {
      this.setState({ ...this.state, LocalScan });
    });
  }

  render() {
      console.log("Component: " + this.props.localscan);
    return (<p>{this.props.localscan}</p>);
  }
}

export default LocalScan;
