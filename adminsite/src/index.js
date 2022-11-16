import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import Navb from './Components/Navb';
import Product from './Components/Product';
import {
  BrowserRouter as Router,
  Route,
  Routes,
} from "react-router-dom";
import {Card,Button, Container} from "react-bootstrap"
import Category from './Components/Category';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>  
    <Router>
    <Navb />
      <Routes>
        <Route  path="/" element={<App/>} />
        <Route  path="/Category" element={<Category/>} />
        <Route  path="/Product" element={<Product/>} />
      </Routes  >
    </Router>
  </React.StrictMode>
);  

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
