import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import React, { useEffect, useState } from "react";
import {Table, Modal, Button} from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';
import Product from './Components/Product';

function App() {
  return(
    <>
    <Product/>
    </>
  )
}

export default App
