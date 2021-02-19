import React from 'react';
import './footer.css';
//import { MDBContainer, MDBFooter } from "mdbreact";
import PropTypes from 'prop-types';

const Footer = (props) => {
  return (
    <div className='footer'>
      <label>TEXT</label>
      
     {/*  <MDBFooter color={props.backgroundColor}>
        <div className="footer-copyright text-center py-2">
          <MDBContainer fluid>
            &copy; {new Date().getFullYear()} Copyright -
            <a href="https://www.linkedin.com/in/williamalvesgoi/" target="_blank" rel="noopener noreferrer"> William Goi</a>
          </MDBContainer>
        </div>
      </MDBFooter>*/}
    </div >
  )
}

Footer.propTypes = {
  backgroundColor: PropTypes.string.isRequired
}

Footer.defaultProps = {
  backgroundColor: 'blue'
}

export default Footer;
