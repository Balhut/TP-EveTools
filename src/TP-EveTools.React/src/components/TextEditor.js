import React, {Component} from 'react';
import RichTextEditor from 'react-rte';

const toolbarConfig = {
  // Optionally specify the groups to display (displayed in the order listed).
  display: []
};

class TextEditor extends Component {
  state = {
    value: RichTextEditor.createEmptyValue()
  }

  onChange = (value) => {
    this.setState({value});
    if (this.props.onChange) {
      this.props.onChange(
        value.toString('html')
      );
    }
  };

  render () {
    return (
      <RichTextEditor
        className="textEditor"
        toolbarConfig={toolbarConfig}
        value={this.state.value}
        onChange={this.onChange}
        placeholder={this.props.placeholder}
      />
    );
  }
}

export default TextEditor