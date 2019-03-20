import React, { Component } from "react";
import { Route, Switch } from "react-router-dom";
import DScanPage from "./pages/DScanPage";
import LocalScanPage from "./pages/LocalScanPage";
import { Home } from "./components/Home";
import { FetchData } from "./components/FetchData";
import NavBar from "./components/NavBar";
import "./App.css";

class App extends Component {
  render() {
    return (
      <div>
        <NavBar />
        <div className="App container">
          <Switch>
            <Route exact path="/" component={Home} />
            <Route path="/DScan" component={DScanPage} />
            <Route path="/LocalScan" component={LocalScanPage} />
            <Route path="/fetchdata" component={FetchData} />
          </Switch>
        </div>
      </div>
    );
  }
}

export default App;
