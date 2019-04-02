import React, { Component } from "react";

class DScan extends Component {
  displayName = DScan.name;

  constructor(props) {
    super(props);
    this.state = { dscan: undefined, loading: true };

    fetch(`/api/DScan/${this.props.dscan}`)
      .then(response => response.json())
      .then(data => {
        this.setState({ dscan: data, loading: false });
      });
  }

  render() {
    let contents = this.state.loading ? (
      <p align="center">
        <em>Loading...</em>
      </p>
    ) : (
      DScan.renderDScanTable(this.state.dscan)
    );

    return (
      <div>
        <h1 align="center">Directional Scan</h1>
        {contents}
      </div>
    );
  }

  static renderDScanTable(dscan) {
    if (dscan.systemName !== "Unknown") {
      return DScan.renderWithSystemName(dscan);
    } else {
      return DScan.renderWithUnknownSystemName(dscan);
    }
  }

  static renderWithSystemName(dscan) {
    if (
      dscan != null &&
      dscan.ships != null &&
      dscan.interestingTargets == null
    ) {
      return (
        <div>
          <h2 align="center">
            System:{" "}
            <a
              target="_blank"
              rel="noopener noreferrer"
              href={"http://evemaps.dotlan.net/system/" + dscan.systemName}
            >
              {dscan.systemName}
            </a>
          </h2>
          <p align="center">Created at: {dscan.createdAt}</p>
          <div id="wrapper">
            <div id="c1">
              <h3 align="center">Ships&Structures</h3>
              <table className="table">
                <thead>
                  <tr>
                    <th>Name</th>
                    <th />
                  </tr>
                </thead>
                <tbody>
                  {dscan.ships.map(ship => (
                    <tr key={ship.name}>
                      <td>{ship.name}</td>
                      <td align="center">{ship.count}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
            <div id="c2">
              <h3 align="center">Types</h3>
              <table className="table">
                <thead>
                  <tr>
                    <th>Type</th>
                    <th />
                  </tr>
                </thead>
                <tbody>
                  {dscan.types.map(type => (
                    <tr key={type.name}>
                      <td>{type.name}</td>
                      <td align="center">{type.count}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
            <div id="c3">
              <h3 align="center">Classes</h3>
              <table className="table">
                <thead>
                  <tr>
                    <th>Class</th>
                    <th />
                  </tr>
                </thead>
                <tbody>
                  {dscan.classes.map(cls => (
                    <tr key={cls.name}>
                      <td>{cls.name}</td>
                      <td align="center">{cls.count}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </div>
        </div>
      );
    } else if (dscan != null && dscan.ships == null) {
      return (
        <div>
          <h2 align="center">
            System:{" "}
            <a
              target="_blank"
              rel="noopener noreferrer"
              href={"http://evemaps.dotlan.net/system/" + dscan.systemName}
            >
              {dscan.systemName}
            </a>
          </h2>
          <p align="center">Created at: {dscan.createdAt}</p>
          <p align="center">No interesting targets found.</p>
        </div>
      );
    } else if (
      dscan != null &&
      dscan.ships != null &&
      dscan.interestingTargets != null
    ) {
      return (
        <div>
          <h2 align="center">
            System:{" "}
            <a
              target="_blank"
              rel="noopener noreferrer"
              href={"http://evemaps.dotlan.net/system/" + dscan.systemName}
            >
              {dscan.systemName}
            </a>
          </h2>
          <p align="center">Created at: {dscan.createdAt}</p>
          <div id="wrapper">
            <div id="c1">
              <h3 align="center">Ships&Structures</h3>
              <table className="table">
                <thead>
                  <tr>
                    <th>Name</th>
                    <th />
                  </tr>
                </thead>
                <tbody>
                  {dscan.ships.map(ship => (
                    <tr key={ship.name}>
                      <td>{ship.name}</td>
                      <td align="center">{ship.count}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
            <div id="c2">
              <h3 align="center">Types</h3>
              <table className="table">
                <thead>
                  <tr>
                    <th>Type</th>
                    <th />
                  </tr>
                </thead>
                <tbody>
                  {dscan.types.map(type => (
                    <tr key={type.name}>
                      <td>{type.name}</td>
                      <td align="center">{type.count}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
            <div id="c3">
              <h3 align="center">Classes</h3>
              <table className="table">
                <thead>
                  <tr>
                    <th>Class</th>
                    <th />
                  </tr>
                </thead>
                <tbody>
                  {dscan.classes.map(cls => (
                    <tr key={cls.name}>
                      <td>{cls.name}</td>
                      <td align="center">{cls.count}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
            <div id="c4">
              <h3 align="center">Notables</h3>
              <table className="table">
                <thead>
                  <tr>
                    <th>Name</th>
                    <th id="centered">Type</th>
                  </tr>
                </thead>
                <tbody>
                  {dscan.interestingTargets.map(notable => (
                    <tr key={notable.name}>
                      <td>{notable.name}</td>
                      <td align="center">{notable.type}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </div>
        </div>
      );
    } else {
      return <p align="center">Directional Scan does not exist.</p>;
    }
  }

  static renderWithUnknownSystemName(dscan) {
    if (
      dscan != null &&
      dscan.ships != null &&
      dscan.interestingTargets == null
    ) {
      return (
        <div>
          <h2 align="center">System: {dscan.systemName}</h2>
          <p align="center">Created at: {dscan.createdAt}</p>
          <div id="wrapper">
            <div id="c1">
              <h3 align="center">Ships&Structures</h3>
              <table className="table">
                <thead>
                  <tr>
                    <th>Name</th>
                    <th />
                  </tr>
                </thead>
                <tbody>
                  {dscan.ships.map(ship => (
                    <tr key={ship.name}>
                      <td>{ship.name}</td>
                      <td align="center">{ship.count}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
            <div id="c2">
              <h3 align="center">Types</h3>
              <table className="table">
                <thead>
                  <tr>
                    <th>Type</th>
                    <th />
                  </tr>
                </thead>
                <tbody>
                  {dscan.types.map(type => (
                    <tr key={type.name}>
                      <td>{type.name}</td>
                      <td align="center">{type.count}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
            <div id="c3">
              <h3 align="center">Classes</h3>
              <table className="table">
                <thead>
                  <tr>
                    <th>Class</th>
                    <th />
                  </tr>
                </thead>
                <tbody>
                  {dscan.classes.map(cls => (
                    <tr key={cls.name}>
                      <td>{cls.name}</td>
                      <td align="center">{cls.count}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </div>
        </div>
      );
    } else if (dscan != null && dscan.ships == null) {
      return (
        <div>
          <h2 align="center">System: {dscan.systemName}</h2>
          <p align="center">Created at: {dscan.createdAt}</p>
          <p align="center">No interesting targets found.</p>
        </div>
      );
    } else if (
      dscan != null &&
      dscan.ships != null &&
      dscan.interestingTargets != null
    ) {
      return (
        <div>
          <h2 align="center">System: {dscan.systemName}</h2>
          <p align="center">Created at: {dscan.createdAt}</p>
          <div id="wrapper">
            <div id="c1">
              <h3 align="center">Ships&Structures</h3>
              <table className="table">
                <thead>
                  <tr>
                    <th>Name</th>
                    <th />
                  </tr>
                </thead>
                <tbody>
                  {dscan.ships.map(ship => (
                    <tr key={ship.name}>
                      <td>{ship.name}</td>
                      <td align="center">{ship.count}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
            <div id="c2">
              <h3 align="center">Types</h3>
              <table className="table">
                <thead>
                  <tr>
                    <th>Type</th>
                    <th />
                  </tr>
                </thead>
                <tbody>
                  {dscan.types.map(type => (
                    <tr key={type.name}>
                      <td>{type.name}</td>
                      <td align="center">{type.count}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
            <div id="c3">
              <h3 align="center">Classes</h3>
              <table className="table">
                <thead>
                  <tr>
                    <th>Class</th>
                    <th />
                  </tr>
                </thead>
                <tbody>
                  {dscan.classes.map(cls => (
                    <tr key={cls.name}>
                      <td>{cls.name}</td>
                      <td align="center">{cls.count}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
            <div id="c4">
              <h3 align="center">Notables</h3>
              <table className="table">
                <thead>
                  <tr>
                    <th>Name</th>
                    <th id="centered">Type</th>
                  </tr>
                </thead>
                <tbody>
                  {dscan.interestingTargets.map(notable => (
                    <tr key={notable.name}>
                      <td>{notable.name}</td>
                      <td align="center">{notable.type}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </div>
        </div>
      );
    } else {
      return <p align="center">Directional Scan does not exist.</p>;
    }
  }
}
export default DScan;
