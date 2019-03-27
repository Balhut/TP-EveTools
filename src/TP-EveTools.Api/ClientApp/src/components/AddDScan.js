import React, { Component } from "react";
import ApiService from "../services/ApiService";
import TextEditor from "./TextEditor";

class AddDScan extends Component {
  state = {
    postText: "",
    btnText: "Parse"
  };

  constructor(props) {
    super(props);
    this.apiService = new ApiService();
  }

  onPostChange = value => {
    this.setState({ ...this.state, postText: value });
  };

  create = () => {
    this.setState({...this.state, btnText: "Parsing..."});
    const post = {
      content: this.state.postText
    };
    this.apiService.addDScan(post);
  };

  render() {
    return (
      <div>
        <div id="top">
          <button
            id="parse"
            className="button"
            onClick={this.create}
          >
            <span>{this.state.btnText}</span>
          </button>
        </div>
        <div id="text">
          <TextEditor
            onChange={this.onPostChange}
            placeholder="Paste directional scan you copied in EVE..."
          />
        </div>
      </div>
    );
  }
}

export default AddDScan;
