import React, { Component } from "react";

class LocalScan extends Component {
  displayName = LocalScan.name;

  constructor(props) {
    super(props);
    this.state = { localscan: undefined, loading: true };

    fetch(`https://localhost:5001/api/LocalScan/${this.props.localscan}`)
      .then(response => response.json())
      .then(data => {
        this.setState({ localscan: data, loading: false });
      })
      .then(console.log(this.state.localscan));
  }

  static renderForecastsTable(forecasts) {
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


















// import React, { Component } from "react";
// import ApiService from "../services/ApiService";

// class LocalScan extends Component {
//   state = {
//     LocalScan: undefined,
//     Loading: true
//   }
//   constructor(props) {
//     super(props);
//     this.apiService = new ApiService();
//   }

//   componentDidMount() {
//     this.apiService.getLocalScan(this.props.localscan).then(ls => this.setState({ ...this.state, LocalScan: ls })).then(this.setState({...this.state, Loading: false}));
//     console.log("Did mount");
//     console.log(this.state.LocalScan);
//   }

//   render() {
//     console.log("Component: " + this.props.localscan);
//     console.log(this.state.LocalScan);
//     let { localScan } = this.state.LocalScan;
//     if(this.state.Loading){
//       return ( <p>Loading...</p> );
//     }
//     else{
//       return (
//         <div>
//           <table className="table">
//             <thead>
//               <tr>
//                 <th scope="col">Characters</th>
//               </tr>
//             </thead>
//             <tbody>
//               {localScan.charactersList.map(blog => (
//                 <tr key={blog.id}>
//                   <td>
//                     <p>{blog.name}</p>
//                   </td>
//                 </tr>
//               ))}
//             </tbody>
//           </table>
//         </div>
//       );
//     }
//   }
// }

// export default LocalScan;
