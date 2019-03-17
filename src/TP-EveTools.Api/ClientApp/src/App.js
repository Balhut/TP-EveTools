import React, { Component } from "react";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import { Layout } from "./components/Layout";
import { Home } from "./components/Home";
import { FetchData } from "./components/FetchData";

class App extends Component {
  render() {
    return (
      <div className="App container">
        <Layout>
          <Router>
            <Switch>
              <Route exact path="/" component={Home} />
              <Route path="/fetchdata" component={FetchData} />
            </Switch>
          </Router>
        </Layout>
      </div>
    );
  }
}

export default App;
