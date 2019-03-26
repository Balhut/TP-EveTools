import React, { Component } from "react";

import LocalScan from "../components/LocalScan";

class LocalScanPage extends Component {

  render() {
    return (
      <div>
        <LocalScan localscan={this.props.match.params.id} />
      </div>
    );
  }
}

export default LocalScanPage;
