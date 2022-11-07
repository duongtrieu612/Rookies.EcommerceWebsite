import {Container, Navbar, Nav,NavDropdown} from 'react-bootstrap'
import { Link } from 'react-router-dom'
import '../App.css'


function Navb (){
    return(
        <Navbar variant="dark" expand="lg">
            <Container>
                <Navbar.Brand ><Link style={{ textDecoration: 'none', color:"white", fontWeight:'bold',textTransform:'uppercase'}} to="/">AdminSite</Link></Navbar.Brand>
                <Navbar.Toggle />
                <Navbar.Collapse id="basic-navbar-nav">
                <Nav className="me-auto">
                    <Link style={{ textDecoration: 'none', color:"white", marginRight:"20px"}} to="/Product">Product</Link>
                    <Link style={{ textDecoration: 'none', color:"white", marginRight:"20px" }} to="/Category">Category</Link>
                    <Link style={{ textDecoration: 'none', color:"white", marginRight:"20px" }} to="/User">User</Link>
                </Nav>
                </Navbar.Collapse>
            </Container>
            
        </Navbar>
    )
}
export default Navb
    