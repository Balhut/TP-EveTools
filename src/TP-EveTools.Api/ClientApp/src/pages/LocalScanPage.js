import React, { Component } from "react";

import LocalScan from "../components/LocalScan";

class LocalScanPage extends Component {
  constructor(props) {
    super(props);
  }
  render() {
    return (
      <div>
        <LocalScan/>
      </div>
    );
  }
}

export default LocalScanPage;