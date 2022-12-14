
import axios from 'axios';
import React, { useEffect, useState } from "react";
import {Table, Modal, Button} from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';

function Category() {

  const [searchTerm, setSearchTerm] = useState("");
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
    setName("")
    setShow1(true)
  }
  function submitForm(e) {
    e.preventDefault();
    axios.post("https://localhost:7067/api/Category", data)
    .then(() => {
      setShow1(false)
      
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
          <Modal.Title>X??a Danh m???c n??y</Modal.Title>
        </Modal.Header>
        <Modal.Body>B???n c?? ch???c mu???n x??a danh m???c n??y kh??ng?</Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            H???y
          </Button>
          <Button variant="danger" onClick={()=>DeleteCategory(takeid)}>
            X??a
          </Button>
        </Modal.Footer>
      </Modal>

      <Modal show={show1} onHide={handleClose1}>
          <Modal.Header closeButton>
            <Modal.Title>Th??m Danh m???c </Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <div>
              <form className='form'>
                <input
                  value={name}
                  onChange={(e) => setName(e.target.value)}
                  className="w-100"
                  type="text"
                  placeholder="Nh???p t??n danh m???c"
                />
              </form>
            </div>
          </Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={handleClose1}>
              H???y
            </Button>
            <Button variant="primary" type="submit" onClick={submitForm}>
              Th??m
            </Button>
          </Modal.Footer>
        </Modal>

        <Modal show={show2} onHide={handleClose2}>
          <Modal.Header closeButton>
            <Modal.Title>C???p nh???t Danh m???c </Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <div>
              <form className='form'>
                <input
                  value={name}
                  onChange={(e) => setName(e.target.value)}
                  className="w-100"
                  type="text"
                  placeholder="Nh???p t??n danh m???c"
                />
              </form>
            </div>
          </Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={handleClose2}>
              H???y
            </Button>
            <Button variant="primary" type="submit" onClick={Update}>
              C???p Nh???t
            </Button>
          </Modal.Footer>
        </Modal>


<div>
<div className="crud shadow-lg p-3 mb-5 mt-5 bg-body rounded"> 
          <div className="row ">
            
           <div className="col-sm-3 mt-5 mb-4 text-gred">
              <div className="search">
                <form className="form-inline">
                 <input className="form-control mr-sm-2" type="search" placeholder="Search" onChange={(event) => {setSearchTerm(event.target.value);}}/>
                
                </form>
              </div>    
              </div>  
              <div className="col-sm-3 offset-sm-2 mt-5 mb-4 text-gred" style={{color:"green"}}><h3><b>Category</b></h3></div>
              <div className="col-sm-3 offset-sm-1  mt-5 mb-4 text-gred">
              <Button variant="primary" onClick={AddCategory}>
                Th??m
              </Button>
             </div>
      <Table className='table table-striped table-hover table-bordered'>
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {categories.filter((val)=>{
            if(searchTerm=="")
            {
              return val
            }
            else if(val.name.toLowerCase().includes(searchTerm.toLowerCase()))
            {
              return val
            }
          }).map(category =>
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
</div>
    </div>
    </div>
  );
}
export default Category
