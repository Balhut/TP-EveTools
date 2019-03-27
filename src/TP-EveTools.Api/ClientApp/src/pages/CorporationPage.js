import React, { Component } from "react";

import Corporation from "../components/Corporation";

class CorporationPage extends Component {

  render() {
    return (
      <div>
        <Corporation id={this.props.match.params.id} />
      </div>
    );
  }
}

export default CorporationPage;
