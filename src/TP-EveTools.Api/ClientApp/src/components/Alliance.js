import React, { Component } from "react";

class Alliance extends Component {
  displayName = Alliance.name;

  constructor(props) {
    super(props);
    this.state = {
      alliance: undefined,
      loading: true
    };

    fetch(`https://esi.evetech.net/latest/alliances/${this.props.id}`)
      .then(response => response.json())
      .then(data => {
        this.setState({ alliance: data, loading: false });
      });
  }

  static renderAllianceInfo(alliance, id) {
    return (
      <div>
        <center>
          <img
            alt="Logo"
            src={
              "https://imageserver.eveonline.com/Corporation/" +
              alliance.executor_corporation_id +
              "_128.png"
            }
          />
          <img
            alt="Logo"
            src={
              "https://imageserver.eveonline.com/Alliance/" + id + "_128.png"
            }
          />
        </center>
        <div id="char_tab">
          <table className="table">
            <tbody>
              <tr>
                <td align="center">Name:</td>
                <td align="center">
                  {alliance.name} (
                  <a
                    target="_blank"
                    rel="noopener noreferrer"
                    href={"https://zkillboard.com/alliance/" + id + "/"}
                  >
                    zKb &#187;
                  </a>
                  )
                </td>
              </tr>
              <tr>
                <td align="center">Executor corp:</td>
                <td align="center">
                  <a
                    target="_blank"
                    rel="noopener noreferrer"
                    href={"/corporation/" + alliance.executor_corporation_id}
                  >
                    {alliance.executor_corporation_id}
                  </a>
                  &nbsp;(
                  <a
                    target="_blank"
                    rel="noopener noreferrer"
                    href={
                      "https://zkillboard.com/corporation/" +
                      alliance.executor_corporation_id +
                      "/"
                    }
                  >
                    zKb &#187;
                  </a>
                  )
                </td>
              </tr>
              <tr>
                <td align="center">Ticker:</td>
                <td align="center">{alliance.ticker}</td>
              </tr>
              <tr>
                <td align="center">Date founded:</td>
                <td align="center">{alliance.date_founded}</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    );
  }

  render() {
    let contents = this.state.loading ? (
      <p align="center">
        <em>Loading...</em>
      </p>
    ) : (
      Alliance.renderAllianceInfo(this.state.alliance, this.props.id)
    );

    return (
      <div>
        <h1 align="center">Alliance info</h1>
        {contents}
      </div>
    );
  }
}

export default Alliance;
