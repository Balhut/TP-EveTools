import React, { Component } from "react";
import { Link } from "react-router-dom";

class NavBar extends Component {
  render() {
    return (
      <nav className="navbar navbar-expand-lg navbar-dark navbar-fixed-top bg-dark">
      <div className="container">
        <Link className="navbar-brand" to="/">
          Twarde Pukanie.
        </Link>
        <form className="navbar-form navbar-right">
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
        </form>
        </div>
      </nav>
    );
  }
}

export default NavBar;
