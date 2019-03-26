import React, { Component } from "react";

class LocalScan extends Component {
  displayName = LocalScan.name;

  constructor(props) {
    super(props);
    this.state = { localscan: undefined, loading: true };

    fetch(`/api/LocalScan/${this.props.localscan}`)
      .then(response => response.json())
      .then(data => {
        this.setState({ localscan: data, loading: false });
      });
  }

  static renderForecastsTable(forecasts) {
    if (forecasts != null) {
      return (
        <div>
          <p align="center">Created at: {forecasts.createdAt}</p>
          <div id="wrapper">
            <div id="c1">
              <h3 align="center">Characters</h3>
              <table className="table">
                <thead>
                  <tr>
                    <th>Character name</th>
                    <th align="center">zKillboard</th>
                  </tr>
                </thead>
                <tbody>
                  {forecasts.characterList.map(forecast => (
                    <tr key={forecast.id}>
                      <td>
                        <a
                          target="_blank"
                          rel="noopener noreferrer"
                          href={"/character/" + forecast.id}
                        >
                          {forecast.name}
                        </a>
                      </td>
                      <td align="center">
                        <a
                          target="_blank"
                          rel="noopener noreferrer"
                          href={
                            "https://zkillboard.com/character/" +
                            forecast.id +
                            "/"
                          }
                        >
                          {" "}
                          &#187;{" "}
                        </a>
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
            <div id="c2">
              <h3 align="center">Corporations</h3>
              <table className="table">
                <thead>
                  <tr>
                    <th>Corp name (zKb)</th>
                    <th />
                  </tr>
                </thead>
                <tbody>
                  {forecasts.corporationList.map(forecast => (
                    <tr key={forecast.corpId}>
                      <td>
                        <a
                          target="_blank"
                          rel="noopener noreferrer"
                          href={"/corporation/" + forecast.corpId}
                        >
                          {forecast.corpName}
                        </a>
                        &nbsp;(
                        <a
                          target="_blank"
                          rel="noopener noreferrer"
                          href={
                            "https://zkillboard.com/corporation/" +
                            forecast.corpId +
                            "/"
                          }
                        >
                          &#187;
                        </a>
                        )
                      </td>
                      <td>{forecast.corpCount}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
            <div id="c3">
              <h3 align="center">Alliances</h3>
              <table className="table">
                <thead>
                  <tr>
                    <th>Alliance name (zKb)</th>
                    <th align="center" />
                  </tr>
                </thead>
                <tbody>
                  {forecasts.allianceList.map(forecast => (
                    <tr key={forecast.allyId}>
                      <td>
                        <a
                          target="_blank"
                          rel="noopener noreferrer"
                          href={"/alliance/" + forecast.allyId}
                        >
                          {forecast.allyName}
                        </a>
                        &nbsp;(
                        <a
                          target="_blank"
                          rel="noopener noreferrer"
                          href={
                            "https://zkillboard.com/alliance/" +
                            forecast.allyId +
                            "/"
                          }
                        >
                          &#187;
                        </a>
                        )
                      </td>
                      <td>{forecast.allyCount}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </div>
        </div>
      );
    } else {
      return <p>Local Scan does not exist.</p>;
    }
  }

  render() {
    let contents = this.state.loading ? (
      <p>
        <em align="center">Loading...</em>
      </p>
    ) : (
      LocalScan.renderForecastsTable(this.state.localscan)
    );

    return (
      <div>
        <h1 align="center">Local Scan</h1>
        {contents}
      </div>
    );
  }
}
export default LocalScan;
