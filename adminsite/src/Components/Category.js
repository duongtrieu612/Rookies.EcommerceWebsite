import React from 'react';

import axios from 'axios';

export default class Category extends React.Component {
  state = {
    category: []
  }

  componentDidMount() {
    axios.get(`https://localhost:7067/api/Category`)
      .then(res => {
        const category = res.data;
        this.setState({ category });
      })
      .catch(error => console.log(error));
  }

  render() {
    return (
      <ul>
        { this.state.category.map(category => <li>{category.name}</li>)}
      </ul>
    )
  }
}
