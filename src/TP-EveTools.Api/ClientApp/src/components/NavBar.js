import React, { Component } from "react";
import { Link } from "react-router-dom";

class NavBar extends Component {
  render() {
    return (
      <div id="top">
        <nav className="navbar navbar-expand-lg navbar-dark  bg-dark">
          <div className="App container">
            <Link className="navbar-brand" to="/">
              Twarde Pukanie.
            </Link>
            <ul className="navbar-nav">
              <li className="nav-item">
                <Link className="nav-link" to="/DScan">
                  DScan
                </Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/LocalScan">
                  LocalScan
                </Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/FetchData">
                  Fetch Data
                </Link>
              </li>
            </ul>
          </div>
        </nav>
      </div>
    );
  }
}

export default NavBar;
