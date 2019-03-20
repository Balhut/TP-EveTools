import React, { Component } from "react";
import ApiService from "../services/ApiService";
import TextEditor from "./TextEditor";

class AddLocalScan extends Component {
  state = {
    postText: ""
  };

  constructor(props) {
    super(props);
    this.apiService = new ApiService();
  }

  onPostChange = value => {
    this.setState({ ...this.state, postText: value });
  };

  create = () => {
    const post = {
      content: this.state.postText
    };
    this.apiService.addLocalScan(post);
  };

  render() {
    return (
      <div>
        <div id="top">
          <button id="parse" className="button" onClick={this.create}>
            <span>Parse</span>
          </button>
        </div>
        <div id="text">
          <TextEditor
            onChange={this.onPostChange}
            placeholder="Paste local scan you copied in EVE..."
          />
        </div>
      </div>
    );
  }
}

export default AddLocalScan;
