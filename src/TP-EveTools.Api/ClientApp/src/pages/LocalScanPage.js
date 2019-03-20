import React, { Component } from "react";

import LocalScan from "../components/LocalScan";

class LocalScanPage extends Component {
  constructor(props) {
    super(props);
  }
  render() {
    console.log("Page: " + this.props.match.params.id);
    return (
      <div>
        <LocalScan localscan={this.props.match.params.id} />
      </div>
    );
  }
}

export default LocalScanPage;
