import React, { Component } from "react";
import ApiService from "../services/ApiService";
import TextEditor from "./TextEditor";

class AddLocalScan extends Component {
  state = {
    postText: "",
    sending: false,
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
    this.setState({...this.state, sending: true});
    this.setState({...this.state, btnText: "Parsing..."});
    const post = {
      content: this.state.postText
    };
    this.apiService.addLocalScan(post);
  };

  render() {
    const submitDisabled = this.state.sending;
    return (
      <div>
        <div id="top">
          <button
            id="parse"
            className="button"
            disabled={submitDisabled}
            onClick={this.create}
          >
            <span>{this.state.btnText}</span>
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
