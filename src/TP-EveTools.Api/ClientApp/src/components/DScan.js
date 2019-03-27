import React, { Component } from "react";

class DScan extends Component {
  displayName = DScan.name;

  constructor(props) {
    super(props);
    this.state = { dscan: undefined, loading: true };

    fetch(`/api/DScan/${this.props.dscan}`)
      .then(response => response.json())
      .then(data => {
        this.setState({ dscan: data, loading: false });
      });
  }

  static renderDScanTable(dscan) {
    if (dscan != null) {
        return (
            <div>
                <o>Dscan</o>
            </div>
        );
    }
    else
    {
        return <p>Directional Scan does not exist.</p>;
    }
  }

  render() {
    let contents = this.state.loading ? (
      <p align="center">
        <em>Loading...</em>
      </p>
    ) : (
      DScan.renderDScanTable(this.state.dscan)
    );

    return (
      <div>
        <h1 align="center">Directional Scan</h1>
        {contents}
      </div>
    );
  }

}
export default DScan;