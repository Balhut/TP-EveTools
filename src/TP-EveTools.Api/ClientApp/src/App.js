import React, { Component } from "react";
import { Route, Switch } from "react-router-dom";
import "./App.css";

import AddDScanPage from "./pages/AddDScanPage";
import AddLocalScanPage from "./pages/AddLocalScanPage";
import LocalScanPage from "./pages/LocalScanPage";
import { Home } from "./components/Home";
import { FetchData } from "./components/FetchData";
import NavBar from "./components/NavBar";


class App extends Component {
  render() {
    return (
      <div>
        <NavBar />
        <div className="App container">
          <Switch>
            <Route exact path="/" component={Home} />
            <Route path="/LocalScan/:id" component={LocalScanPage} />
            <Route path="/DScan" component={AddDScanPage} />
            <Route path="/LocalScan" component={AddLocalScanPage} />
            
            <Route path="/fetchdata" component={FetchData} />
          </Switch>
        </div>
      </div>
    );
  }
}

export default App;
