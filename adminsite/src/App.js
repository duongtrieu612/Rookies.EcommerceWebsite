import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import React, { useEffect, useState } from "react";
import {Table} from 'react-bootstrap';

function App() {
  const [categories, setCategory] = useState([]);

  async function loadCategory() {
    await axios.get("https://localhost:7067/api/Category").then((res) => {
      setCategory(res.data);
    });
  }

  function DeleteCategory(id) {
     axios.delete(`https://localhost:7067/api/Category/${id}`)
     .then(() => {
        loadCategory()
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
                <button onClick={() => DeleteCategory(category.id)} className='btn btn-danger btn-sm' >Delete</button>
              </td>
            </tr>
          )}
        </tbody>
      </Table>
    </div>
  );
}
export default App;
