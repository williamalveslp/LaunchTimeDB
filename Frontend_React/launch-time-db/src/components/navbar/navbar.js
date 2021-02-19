import React from 'react';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { RoutePaths, RouteItems } from '../../shared/route-paths';
import PropTypes from 'prop-types';

const NavbarCustom = (props) => {

    return (
        <div>
            <Navbar bg={props.backgroundColor} variant="dark">
                <Navbar.Brand href={RouteItems.ROOT.route}>Launch Time [DBServer]</Navbar.Brand>
                <Nav className="mr-auto">
                    <Nav.Link href={RouteItems.FACILITATORS_PAGE.route}>{RouteItems.FACILITATORS_PAGE.label}</Nav.Link>
                    <Nav.Link href={RouteItems.RESTAURANTS_PAGE.route}>{RouteItems.RESTAURANTS_PAGE.label}</Nav.Link>
                </Nav>
            </Navbar>
        </div >
    )
}

NavbarCustom.propTypes = {
    backgroundColor: PropTypes.string.isRequired
}

NavbarCustom.defaultProps = {
    backgroundColor: 'dark'
}

export default NavbarCustom;