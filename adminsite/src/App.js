import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import React, { useEffect, useState } from "react";
import {Table, Modal, Button} from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';

function App() {

  const navigate = useNavigate();
  const [takeid, setId] = useState(null);
  const [name, setName] = useState("");
  const data = {
    name: name,
  };

  const [categories, setCategory] = useState([]);
  

  //deleteModal
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  //AddModal
  const [show1, setShow1] = useState(false);
  const handleClose1 = () => setShow1(false);
  const handleShow1 = () => setShow1(true);

  //EditModal
  const [show2, setShow2] = useState(false);
  const handleClose2 = () => setShow2(false);
  const handleShow2 = () => setShow2(true);

  async function loadCategory() {
    await axios.get("https://localhost:7067/api/Category").then((res) => {
      setCategory(res.data);
    });
  }

  
//add
  function AddCategory()
  {
    setShow1(true)
  }
  function submitForm(e) {
    e.preventDefault();
    axios.post("https://localhost:7067/api/Category", data)
    .then(() => {
      setShow1(false)
      navigate("/")
      
      loadCategory()
  });
  }

  //update
  const EditCategory = (id,name) =>
  {
    setShow2(true)
    setId(id)
    setName(name)
  }
  function Update(e) {
    e.preventDefault();
    axios.put(`https://localhost:7067/api/Category/${takeid}`, data)
    .then(() => {
      setShow2(false)
      navigate("/")
      loadCategory()
  });
  }

  //delete
  const DeleteClick = (id) =>{
    setShow(true)
    setId(id)
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
          <Button variant="danger" onClick={()=>DeleteCategory(takeid)}>
            Xóa
          </Button>
        </Modal.Footer>
      </Modal>

      <Modal show={show1} onHide={handleClose1}>
          <Modal.Header closeButton>
            <Modal.Title>Thêm Danh mục </Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <div>
              <form className='form'>
                <input
                  value={name}
                  onChange={(e) => setName(e.target.value)}
                  className="w-100"
                  type="text"
                  placeholder="Nhập tên danh mục"
                />
              </form>
            </div>
          </Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={handleClose1}>
              Hủy
            </Button>
            <Button variant="primary" type="submit" onClick={submitForm}>
              Thêm
            </Button>
          </Modal.Footer>
        </Modal>

        <Modal show={show2} onHide={handleClose2}>
          <Modal.Header closeButton>
            <Modal.Title>Cập nhật Danh mục </Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <div>
              <form className='form'>
                <input
                  value={name}
                  onChange={(e) => setName(e.target.value)}
                  className="w-100"
                  type="text"
                  placeholder="Nhập tên danh mục"
                />
              </form>
            </div>
          </Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={handleClose2}>
              Hủy
            </Button>
            <Button variant="primary" type="submit" onClick={Update}>
              Cập Nhật
            </Button>
          </Modal.Footer>
        </Modal>

      <button className='btn btn-secondary' onClick={AddCategory}>Add</button>
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
                <button className='btn btn-info btn-sm' onClick={()=>EditCategory(category.id,category.name)}>Edit</button>
                <button onClick={()=>DeleteClick(category.id)} className='btn btn-danger btn-sm' >Delete</button>                
              </td>
            </tr>
          )}
        </tbody>
      </Table>
    </div>
  );
}
export default App
