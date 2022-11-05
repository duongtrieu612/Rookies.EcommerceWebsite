import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import React, { useEffect, useState } from "react";
import {Table, Modal, Button} from 'react-bootstrap';

function App() {
  const [categories, setCategory] = useState([]);
  const [show, setShow] = useState(false);
  const [deleteId, setdeleteId] = useState(null);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  async function loadCategory() {
    await axios.get("https://localhost:7067/api/Category").then((res) => {
      setCategory(res.data);
    });
  }

  const DeleteClick = (id) =>{
    setShow(true)
    setdeleteId(id)
  }
    

  function DeleteCategory(id) {
     axios.delete(`https://localhost:7067/api/Category/${id}`)
     .then(() => {
        setShow(false)
        loadCategory()
    });
  }

  useEffect(() => {
    loadCategory();
  }, []);

  

  return (
    <div className='container'>
      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Xóa Danh mục này</Modal.Title>
        </Modal.Header>
        <Modal.Body>Bạn có chắc muốn xóa danh mục này không?</Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Hủy
          </Button>
          <Button variant="danger" onClick={()=>DeleteCategory(deleteId)}>
            Xóa
          </Button>
        </Modal.Footer>
      </Modal>
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
                <button onClick={()=>DeleteClick(category.id)} className='btn btn-danger btn-sm' >Delete</button>                
              </td>
            </tr>
          )}
        </tbody>
      </Table>
    </div>
  );
}
export default App;
