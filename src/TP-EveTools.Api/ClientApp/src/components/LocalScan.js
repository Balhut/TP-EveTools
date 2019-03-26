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
        <table className="table">
          <thead>
            <tr>
              <th>Characters</th>
            </tr>
          </thead>
          <tbody>
            {forecasts.characterList.map(forecast => (
              <tr key={forecast.id}>
                <td>{forecast.name}</td>
              </tr>
            ))}
          </tbody>
        </table>
      );
    } else {
      return <p>Local Scan does not exist.</p>;
    }
  }

  render() {
    let contents = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      LocalScan.renderForecastsTable(this.state.localscan)
    );

    return (
      <div>
        <h1>Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }
}
export default LocalScan;
