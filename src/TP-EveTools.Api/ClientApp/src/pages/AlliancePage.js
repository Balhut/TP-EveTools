import React, { Component } from "react";

import Alliance from "../components/Alliance";

class AlliancePage extends Component {

  render() {
    return (
      <div>
        <Alliance id={this.props.match.params.id} />
      </div>
    );
  }
}

export default AlliancePage;
