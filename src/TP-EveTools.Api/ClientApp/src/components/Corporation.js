import React, { Component } from "react";

class Corporation extends Component {
  displayName = Corporation.name;

  constructor(props) {
    super(props);
    this.state = {
      corporation: undefined,
      loading: true
    };

    fetch(`https://esi.evetech.net/latest/corporations/${this.props.id}`)
      .then(response => response.json())
      .then(data => {
        this.setState({ corporation: data, loading: false });
      });
  }

  static renderCorporationInfo(corporation, id) {
    if (corporation.alliance_id !== undefined) {
      return (
        <div>
          <center>
            <img
              alt="Logo"
              src={
                "https://imageserver.eveonline.com/Corporation/" +
                id +
                "_128.png"
              }
            />
            <img
              alt="Logo"
              src={
                "https://imageserver.eveonline.com/Alliance/" +
                corporation.alliance_id +
                "_128.png"
              }
            />
          </center>
          <div id="char_tab">
            <table className="table">
              <tbody>
                <tr>
                  <td align="center">Name:</td>
                  <td align="center">
                    {corporation.name} (
                    <a
                      target="_blank"
                      rel="noopener noreferrer"
                      href={"https://zkillboard.com/corporation/" + id + "/"}
                    >
                      zKb &#187;
                    </a>
                    )
                  </td>
                </tr>
                <tr>
                  <td align="center">Alliance:</td>
                  <td align="center">
                    <a
                      target="_blank"
                      rel="noopener noreferrer"
                      href={"/alliance/" + corporation.alliance_id}
                    >
                      {corporation.alliance_id}
                    </a>{" "}
                    &nbsp;(
                    <a
                      target="_blank"
                      rel="noopener noreferrer"
                      href={
                        "https://zkillboard.com/alliance/" +
                        corporation.alliance_id +
                        "/"
                      }
                    >
                      zKb &#187;
                    </a>
                    )
                  </td>
                </tr>
                <tr>
                  <td align="center">CEO:</td>
                  <td align="center">
                    <a href={"/character/" + corporation.ceo_id}>
                      {corporation.ceo_id}
                    </a>
                    &nbsp;(
                    <a
                      target="_blank"
                      rel="noopener noreferrer"
                      href={
                        "https://zkillboard.com/character/" +
                        corporation.ceo_id +
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
                  <td align="center">{corporation.ticker}</td>
                </tr>
                <tr>
                  <td align="center">Member count:</td>
                  <td align="center">{corporation.member_count}</td>
                </tr>
                <tr>
                  <td align="center">Website:</td>
                  <td align="center">
                    <a
                      target="_blank"
                      rel="noopener noreferrer"
                      href={corporation.url}
                    >
                      {corporation.url}
                    </a>
                  </td>
                </tr>
                <tr>
                  <td align="center">War eligible:</td>
                  <td align="center">{"" + corporation.war_eligible}</td>
                </tr>
                <tr>
                  <td align="center">Tax rate:</td>
                  <td align="center">{corporation.tax_rate}</td>
                </tr>
                <tr>
                  <td align="center">Date founded:</td>
                  <td align="center">{corporation.date_founded}</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      );
    } else {
      return (
        <div>
          <center>
            <img
              alt="Logo"
              src={
                "https://imageserver.eveonline.com/corporation/" +
                id +
                "_128.png"
              }
            />
          </center>
          <div id="char_tab">
            <table className="table">
              <tbody>
                <tr>
                  <td align="center">Name:</td>
                  <td align="center">
                    {corporation.name} (
                    <a
                      target="_blank"
                      rel="noopener noreferrer"
                      href={"https://zkillboard.com/corporation/" + id + "/"}
                    >
                      zKb &#187;
                    </a>
                    )
                  </td>
                </tr>
                <tr>
                  <td align="center">CEO:</td>
                  <td align="center">
                    <a href={"/character/" + corporation.ceo_id}>
                      {corporation.ceo_id}
                    </a>
                    (
                    <a
                      target="_blank"
                      rel="noopener noreferrer"
                      href={
                        "https://zkillboard.com/character/" +
                        corporation.ceo_id +
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
                  <td align="center">{corporation.ticker}</td>
                </tr>
                <tr>
                  <td align="center">Member count:</td>
                  <td align="center">{corporation.member_count}</td>
                </tr>
                <tr>
                  <td align="center">Website:</td>
                  <td align="center">
                    <a href={corporation.url}>{corporation.url}</a>
                  </td>
                </tr>
                <tr>
                  <td align="center">War eligible:</td>
                  <td align="center">{corporation.war_eligible}</td>
                </tr>
                <tr>
                  <td align="center">Tax rate:</td>
                  <td align="center">{corporation.tax_rate}</td>
                </tr>
                <tr>
                  <td align="center">Date founded:</td>
                  <td align="center">{corporation.date_founded}</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      );
    }
  }

  render() {
    let contents = this.state.loading ? (
      <p align="center">
        <em>Loading...</em>
      </p>
    ) : (
      Corporation.renderCorporationInfo(this.state.corporation, this.props.id)
    );

    return (
      <div>
        <h1 align="center">Corporation info</h1>
        {contents}
      </div>
    );
  }
}

export default Corporation;
