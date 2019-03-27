import React, { Component } from "react";

import Character from "../components/Character";

class CharacterPage extends Component {

  render() {
    return (
      <div>
        <Character id={this.props.match.params.id} />
      </div>
    );
  }
}

export default CharacterPage;
