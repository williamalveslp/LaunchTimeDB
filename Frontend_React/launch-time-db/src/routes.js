import React from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import { RoutePaths } from './shared/route-paths';

import HomePage from './pages/home';
import FacilitatorContainer from './pages/facilitators';
import RestaurantContainer from './pages/restaurants';
/*import ProductListContainer from './pages/products/list';
import CustomerListPage from './pages/customers/list'; */

const Routes = () => {
    return (
        <Router>
            <Switch>
                <Route exact path={RoutePaths.ROOT} component={HomePage} />
                <Route exact path={RoutePaths.FACILITATORS_PAGE} component={FacilitatorContainer} />
                <Route exact path={RoutePaths.RESTAURANTS_PAGE} component={RestaurantContainer} />
             {/*  <Route exact path={RoutePaths.PRODUCTS_PAGE_DETAIL} component={ProductDetailContainer} />
                <Route exact path={RoutePaths.PRODUCTS_PAGE_LIST} component={ProductListContainer} />
                <Route exact path={RoutePaths.CUSTOMERS_PAGE_LIST} component={CustomerListPage} /> */}
            </Switch>
        </Router>
    )
}

export default Routes;