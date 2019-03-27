import React, { Component } from "react";

import DScan from "../components/DScan";

class DScanPage extends Component {

  render() {
    return (
      <div>
        <DScan dscan={this.props.match.params.id} />
      </div>
    );
  }
}

export default DScanPage;
