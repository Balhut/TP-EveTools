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

  static renderLocalScanTable(localscan) {
    if (localscan != null) {
      return (
        <div>
          <p align="center">Created at: {localscan.createdAt}</p>
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
                  {localscan.characterList.map(ls => (
                    <tr key={ls.id}>
                      <td>
                        <a
                          target="_blank"
                          rel="noopener noreferrer"
                          href={"/character/" + ls.id}
                        >
                          {ls.name}
                        </a>
                      </td>
                      <td align="center">
                        <a
                          target="_blank"
                          rel="noopener noreferrer"
                          href={
                            "https://zkillboard.com/character/" +
                            ls.id +
                            "/"
                          }
                        >
                          &#187;
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
                  {localscan.corporationList.map(ls => (
                    <tr key={ls.corpId}>
                      <td>
                        <a
                          target="_blank"
                          rel="noopener noreferrer"
                          href={"/corporation/" + ls.corpId}
                        >
                          {ls.corpName}
                        </a>
                        &nbsp;(
                        <a
                          target="_blank"
                          rel="noopener noreferrer"
                          href={
                            "https://zkillboard.com/corporation/" +
                            ls.corpId +
                            "/"
                          }
                        >
                          &#187;
                        </a>
                        )
                      </td>
                      <td>{ls.corpCount}</td>
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
                  {localscan.allianceList.map(ls => (
                    <tr key={ls.allyId}>
                      <td>
                        <a
                          target="_blank"
                          rel="noopener noreferrer"
                          href={"/alliance/" + ls.allyId}
                        >
                          {ls.allyName}
                        </a>
                        &nbsp;(
                        <a
                          target="_blank"
                          rel="noopener noreferrer"
                          href={
                            "https://zkillboard.com/alliance/" +
                            ls.allyId +
                            "/"
                          }
                        >
                          &#187;
                        </a>
                        )
                      </td>
                      <td>{ls.allyCount}</td>
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
      <p align="center">
        <em>Loading...</em>
      </p>
    ) : (
      LocalScan.renderLocalScanTable(this.state.localscan)
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
