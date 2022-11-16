
import axios from 'axios';
import React, { useEffect, useState } from "react";
import {Table, Modal, Button, Dropdown} from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';

function Product() {

  const [searchTerm, setSearchTerm] = useState("");
  const navigate = useNavigate();
  const [takeid, setId] = useState(null);
  const [name, setName] = useState("");
  const [price, setPrice] = useState("");
  const [image, setImage] = useState("");
  const [createdDate, setCreatedDate] = useState("");
  const [categoryId, setCategoryId] = useState("");
  const data = {
    name: name,
    price: price,
    image: image,
    categoryId: categoryId,
    createdDate: createdDate,
  };

  const createdata = {
    name: name,
    price: price,
    image: image,
    categoryId: categoryId,
  };

  const [products, setProduct] = useState([]);
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

  async function loadProduct() {
    await axios.get("https://localhost:7067/api/Products").then((res) => {
      setProduct(res.data);
    });
  }
  async function loadCategory() {
    await axios.get("https://localhost:7067/api/Category").then((res) => {
      setCategory(res.data);
    });
  }

  
//add
  function AddProduct()
  {
    setId("")
    setName("")
    setPrice("")
    setImage("")
    setCategoryId("")
    setCreatedDate("")
    setShow1(true)
  }
  function submitForm(e) {
    e.preventDefault();
    axios.post("https://localhost:7067/api/Products", createdata)
    .then(() => {
      setShow1(false)
      loadProduct()
  });
  }

  //update
  const EditProduct = (id,name,price,image,createdDate) =>
  {
    setShow2(true)
    setId(id)
    setName(name)
    setPrice(price)
    setImage(image)
    setCreatedDate(createdDate)
  }
  function Update(e) {
    e.preventDefault();
    axios.put(`https://localhost:7067/api/Products/${takeid}`, data)
    .then(() => {
      setShow2(false)
      loadProduct()
  });
  }

  //delete
  const DeleteClick = (id) =>{
    setShow(true)
    setId(id)
  }
  function DeleteProduct(id) {
     axios.delete(`https://localhost:7067/api/Products/${id}`)
     .then(() => {
        setShow(false)
        loadProduct()
    });
  }



  useEffect(() => {
    loadProduct();
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
          <Button variant="danger" onClick={()=>DeleteProduct(takeid)}>
            Xóa
          </Button>
        </Modal.Footer>
      </Modal>

      <Modal show={show1} onHide={handleClose1}>
          <Modal.Header closeButton>
            <Modal.Title>Thêm hàng </Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <div>
              <form className='form'>
                <input
                  value={name}
                  onChange={(e) => setName(e.target.value)}
                  className="w-100 mt-2"
                  type="text"
                  placeholder="Nhập tên hàng"
                />
                <input
                  value={price}
                  onChange={(e) => setPrice(e.target.value)}
                  className="w-100 mt-2"
                  type="text"
                  placeholder="Nhập giá tiền"
                />
                <input
                  value={image}
                  onChange={(e) => setImage(e.target.value)}
                  className="w-100 mt-2"
                  type="text"
                  placeholder="Hình ảnh"
                />
                <input
                  value={categoryId}
                  onChange={(e) => setCategoryId(e.target.value)}
                  className="w-100 mt-2"
                  type="text"
                  readOnly={true}
                  placeholder="Chọn danh mục"
                />
                <select 
                  className='mt-2'
                  value={categoryId} onChange={(e) => setCategoryId(e.target.value)}>
                  {categories.map(category => 
                  <option 
                  key={category.id} 
                  value={category.id}>
                  {category.name}</option>
                  )}
                </select>
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
                  className="w-100 mt-2"
                  type="text"
                  placeholder="Nhập tên danh mục"
                />
                <input
                  value={price}
                  onChange={(e) => setPrice(e.target.value)}
                  className="w-100 mt-2"
                  type="text"
                  placeholder="Nhập giá tiền"
                />
                <input
                  value={image}
                  onChange={(e) => setImage(e.target.value)}
                  className="w-100 mt-2"
                  type="text"
                  placeholder="Hình ảnh"
                />
                <input
                  value={createdDate}
                  onChange={(e) => setCreatedDate(e.target.value)}
                  className="w-100 text-light bg-secondary mt-2"
                  type="text"
                  readOnly={true}
                  placeholder="Ngày"
                />
                <input
                  value={categoryId}
                  onChange={(e) => setCategoryId(e.target.value)}
                  className="w-100 text-light bg-secondary mt-2"
                  type="text"
                  readOnly={true}
                  placeholder="Chọn danh mục"
                />
                <select 
                  className='mt-2'
                  value={categoryId} onChange={(e) => setCategoryId(e.target.value)}>
                  {categories.map(category => 
                  <option 
                  key={category.id} 
                  value={category.id}>
                  {category.name}</option>
                  )}
                </select>
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
              <div className="col-sm-3 offset-sm-2 mt-5 mb-4 text-gred" style={{color:"green"}}><h3><b>Product</b></h3></div>
              <div className="col-sm-3 offset-sm-1  mt-5 mb-4 text-gred">
              <Button variant="primary" onClick={AddProduct}>
                Add New Product
              </Button>
             </div>
      <Table className='table table-striped table-hover table-bordered' >
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Price</th>
            <th>Image</th>
            <th>Created Date</th>
            <th>Category ID</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {products.filter((val)=>{
            if(searchTerm=="")
            {
              return val
            }
            else if(val.name.toLowerCase().includes(searchTerm.toLowerCase()))
            {
              return val
            }
          }).map(product =>
            <tr key={product.id}>
              <td>{product.id}</td>
              <td>{product.name}</td>
              <td>{product.price}</td>
              <td style={{width:"200px"}} >{product.image}</td>
              <td>{product.createdDate}</td>
              <td>{product.categoryId}</td>
              <td> 
                <button className='btn btn-info btn-sm' onClick={()=>{EditProduct(product.id,product.name,product.price,product.image,product.createdDate);setCategoryId(product.categoryId)}}>Edit</button>
                <button onClick={()=>DeleteClick(product.id)} className='btn btn-danger btn-sm' >Delete</button>                
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
export default Product
