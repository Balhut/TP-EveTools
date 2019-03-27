import React, { Component } from "react";

class Character extends Component {
  displayName = Character.name;

  constructor(props) {
    super(props);
    this.state = {
      character: undefined,
      loading: true
    };

    fetch(`https://esi.evetech.net/latest/characters/${this.props.id}`)
      .then(response => response.json())
      .then(data => {
        this.setState({ character: data, loading: false });
      });
  }

  static renderCharacterInfo(character, id) {
    if (character.alliance_id !== undefined) {
      return (
        <div>
          <center>
            <img
              alt="Characters avatar"
              src={
                "https://imageserver.eveonline.com/Character/" + id + "_256.jpg"
              }
            />
          </center>
          <div id="char_tab">
            <table className="table">
              <tbody>
                <tr>
                  <td align="center">Name:</td>
                  <td align="center">
                    {character.name} (
                    <a
                      target="_blank"
                      rel="noopener noreferrer"
                      href={"https://zkillboard.com/character/" + id + "/"}
                    >
                      zKb &#187;
                    </a>
                    )
                  </td>
                </tr>
                <tr>
                  <td align="center">Corporation:</td>
                  <td align="center">
                    <img
                      alt="Logo"
                      src={
                        "https://imageserver.eveonline.com/Corporation/" +
                        character.corporation_id +
                        "_32.png"
                      }
                    />{" "}
                    &nbsp;
                    <a
                      target="_blank"
                      rel="noopener noreferrer"
                      href={"/corporation/" + character.corporation_id}
                    >
                      {character.corporation_id}
                    </a>{" "}
                    &nbsp;(
                    <a
                      target="_blank"
                      rel="noopener noreferrer"
                      href={
                        "https://zkillboard.com/corporation/" +
                        character.corporation_id +
                        "/"
                      }
                    >
                      zKb &#187;
                    </a>
                    )
                  </td>
                </tr>
                <tr>
                  <td align="center">Alliance:</td>
                  <td align="center">
                    <img
                      alt="Logo"
                      src={
                        "https://imageserver.eveonline.com/Alliance/" +
                        character.alliance_id +
                        "_32.png"
                      }
                    />{" "}
                    &nbsp;
                    <a
                      target="_blank"
                      rel="noopener noreferrer"
                      href={"/alliance/" + character.alliance_id}
                    >
                      {character.alliance_id}
                    </a>
                    &nbsp;(
                    <a
                      target="_blank"
                      rel="noopener noreferrer"
                      href={
                        "https://zkillboard.com/alliance/" +
                        character.alliance_id +
                        "/"
                      }
                    >
                      zKb &#187;
                    </a>
                    )
                  </td>
                </tr>
                <tr>
                  <td align="center">Security status:</td>
                  <td align="center">{character.security_status}</td>
                </tr>
                <tr>
                  <td align="center">Birthday:</td>
                  <td align="center">{character.birthday}</td>
                </tr>
                <tr>
                  <td align="center">Gender:</td>
                  <td align="center">{character.gender}</td>
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
              alt="Characters avatar"
              src={
                "https://imageserver.eveonline.com/Character/" + id + "_256.jpg"
              }
            />
          </center>
          <div id="char_tab">
            <table className="table">
              <tbody>
                <tr>
                  <td align="center">Name:</td>
                  <td align="center">
                    {character.name} (
                    <a
                      target="_blank"
                      rel="noopener noreferrer"
                      href={"https://zkillboard.com/character/" + id + "/"}
                    >
                      zKb &#187;
                    </a>
                    )
                  </td>
                </tr>
                <tr>
                  <td align="center">Corporation:</td>
                  <td align="center">
                    <img
                      alt="Logo"
                      src={
                        "https://imageserver.eveonline.com/Corporation/" +
                        character.corporation_id +
                        "_32.png"
                      }
                    />{" "}
                    &nbsp;
                    <a
                      target="_blank"
                      rel="noopener noreferrer"
                      href={"/corporation/" + character.corporation_id}
                    >
                      {character.corporation_id}
                    </a>
                    &nbsp;(
                    <a
                      target="_blank"
                      rel="noopener noreferrer"
                      href={
                        "https://zkillboard.com/corporation/" +
                        character.corporation_id +
                        "/"
                      }
                    >
                      zKb &#187;
                    </a>
                    )
                  </td>
                </tr>
                <tr>
                  <td align="center">Security status:</td>
                  <td align="center">{character.security_status}</td>
                </tr>
                <tr>
                  <td align="center">Birthday:</td>
                  <td align="center">{character.birthday}</td>
                </tr>
                <tr>
                  <td align="center">Gender:</td>
                  <td align="center">{character.gender}</td>
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
      Character.renderCharacterInfo(this.state.character, this.props.id)
    );

    return (
      <div>
        <h1 align="center">Character info</h1>
        {contents}
      </div>
    );
  }
}

export default Character;
