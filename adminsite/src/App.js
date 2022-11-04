import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import React, { useEffect, useState } from "react";
import {Table} from 'react-bootstrap';

function App() {
  const [categories, setCategory] = useState([]);

  function loadCategory() {
    axios.get("https://localhost:7067/api/Category").then((res) => {
      setCategory(res.data);
    });
  }

  useEffect(() => {
    loadCategory();
  }, []);

  return (
    <div className='container'>
      <button className='btn btn-secondary'>Add</button>
      <Table className='table'>
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {categories.map(category =>
            <tr key={category.id}>
              <td>{category.id}</td>
              <td>{category.name}</td>
              <td> 
                <button className='btn btn-info btn-sm'>Edit</button>
                <button className='btn btn-danger btn-sm'>Delete</button>
              </td>
            </tr>
          )}
        </tbody>
      </Table>
    </div>
  );
}
export default App;
