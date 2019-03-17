import React, { Component } from 'react';

export class Layout extends Component {
  displayName = Layout.name

  render() {
    return (
      <div className="container">
        <div className="row">
          <div className="col" sm={9}>
            {this.props.children}
          </div>
        </div>
      </div>
    );
  }
}
