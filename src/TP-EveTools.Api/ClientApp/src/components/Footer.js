import React, { Component } from "react";
import { Link } from "react-router-dom";

class Footer extends Component {
  render() {
    return (
      <nav className="navbar fixed-bottom navbar-expand-lg navbar-dark navbar-fixed-top bg-dark">
        <div id="centered" className="copyright">
          <div>
            <a href="/">TeamSpeak3</a> <span> - </span>{" "}
            <a href="/">zKillboard</a> <span> - </span> <a href="/">Discord</a>
          </div>
          <div>
            <a href="/"> Twarde Pukanie.</a> © 2019
          </div>
        </div>
      </nav>
    );
  }
}

export default Footer;
