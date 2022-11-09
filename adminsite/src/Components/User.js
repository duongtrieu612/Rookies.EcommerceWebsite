import { Button } from "react-bootstrap"
function User()
{
    return(
        <div className="container ">
          <div className="crud shadow-lg p-3 mb-5 mt-5 bg-body rounded"> 
          <div className="row ">
           
           <div className="col-sm-3 mt-5 mb-4 text-gred">
              <div className="search">
                <form className="form-inline">
                 <input className="form-control mr-sm-2" type="search" placeholder="Search Student" aria-label="Search"/>
                
                </form>
              </div>    
              </div>  
              <div className="col-sm-3 offset-sm-2 mt-5 mb-4 text-gred" style={{color:"green"}}><h3><b>Student Details</b></h3></div>
              <div className="col-sm-3 offset-sm-1  mt-5 mb-4 text-gred">
              <Button variant="primary">
                Add New User
              </Button>
             </div>
           </div>  
            <div className="row">
                <div className="table-responsive " >
                 <table className="table table-striped table-hover table-bordered">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Name </th>
                            <th>Address</th>
                            <th>City </th>
                            <th>Country </th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        
                        <tr>
                            <td>1</td>
                            <td>Rual Octo</td>
                            <td>Deban Steet</td>
                            <td>Newyork</td>
                            <td>USA</td>
                            <td>
                               <a href="#" className="view" title="View" data-toggle="tooltip" style={{color:"#10ab80"}}><i class="material-icons">&#xE417;</i></a>
                                <a href="#" className="edit" title="Edit" data-toggle="tooltip"><i class="material-icons">&#xE254;</i></a>
                                <a href="#" className="delete" title="Delete" data-toggle="tooltip" style={{color:"red"}}><i class="material-icons">&#xE872;</i></a>
                                 
                            </td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>Demark</td>
                            <td>City Road.13</td>
                            <td>Dubai</td>
                            <td>UAE</td>
                            <td>
                            <a href="#" className="view" title="View" data-toggle="tooltip" style={{color:"#10ab80"}}><i className="material-icons">&#xE417;</i></a>
                                <a href="#" className="edit" title="Edit" data-toggle="tooltip"><i className="material-icons">&#xE254;</i></a>
                                <a href="#" className="delete" title="Delete" data-toggle="tooltip" style={{color:"red"}}><i className="material-icons">&#xE872;</i></a>
                            </td>
                        </tr>
                         
 
                        <tr>
                            <td>3</td>
                            <td>Richa Deba</td>
                            <td>Ocol Str. 57</td>
                            <td>Berlin</td>
                            <td>Germany</td>
                            <td>
                            <a href="#" className="view" title="View" data-toggle="tooltip" style={{color:"#10ab80"}}><i className="material-icons">&#xE417;</i></a>
                                <a href="#" className="edit" title="Edit" data-toggle="tooltip"><i className="material-icons">&#xE254;</i></a>
                                <a href="#" className="delete" title="Delete" data-toggle="tooltip" style={{color:"red"}}><i className="material-icons">&#xE872;</i></a>
                            </td>
                        </tr>
 
                        <tr>
                            <td>4</td>
                            <td>James Cott</td>
                            <td>Berut Road</td>
                            <td>Paris</td>
                            <td>France</td>
                            <td>
                            <a href="#" className="view" title="View" data-toggle="tooltip" style={{color:"#10ab80"}}><i className="material-icons">&#xE417;</i></a>
                                <a href="#" className="edit" title="Edit" data-toggle="tooltip"><i className="material-icons">&#xE254;</i></a>
                                <a href="#" className="delete" title="Delete" data-toggle="tooltip" style={{color:"red"}}><i className="material-icons">&#xE872;</i></a>
                            </td>
                        </tr>
 
 
                        <tr>
                            <td>5</td>
                            <td>Dheraj</td>
                            <td>Bulf Str. 57</td>
                            <td>Delhi</td>
                            <td>India</td>
                            <td>
                            <a href="#" className="view" title="View" data-toggle="tooltip" style={{color:"#10ab80"}}><i className="material-icons">&#xE417;</i></a>
                                <a href="#" className="edit" title="Edit" data-toggle="tooltip"><i className="material-icons">&#xE254;</i></a>
                                <a href="#" className="delete" title="Delete" data-toggle="tooltip" style={{color:"red"}}><i className="material-icons">&#xE872;</i></a>
                            </td>
                        </tr>
 
 
                        <tr>
                            <td>6</td>
                            <td>Maria James</td>
                            <td>Obere Str. 57</td>
                            <td>Tokyo</td>
                            <td>Japan</td>
                            <td>
                            <a href="#" className="view" title="View" data-toggle="tooltip" style={{color:"#10ab80"}}><i className="material-icons">&#xE417;</i></a>
                                <a href="#" className="edit" title="Edit" data-toggle="tooltip"><i className="material-icons">&#xE254;</i></a>
                                <a href="#" className="delete" title="Delete" data-toggle="tooltip" style={{color:"red"}}><i className="material-icons">&#xE872;</i></a>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>   
        </div>  
        </div>
        </div>
    )

}

export default User