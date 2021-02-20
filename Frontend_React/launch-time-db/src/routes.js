import React from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import { RoutePaths, RouteItems } from './shared/route-paths';

import HomePage from './pages/home';
import FacilitatorScheduleContainer from './pages/facilitators/schedules';
import FacilitatorCalendarContainer from './pages/facilitators/calendar';
import RestaurantContainer from './pages/restaurants';

const Routes = () => {
    return (
        <Router>
            <Switch>
                <Route exact path={RoutePaths.ROOT} component={HomePage} />
                <Route exact path={RoutePaths.FACILITATORS_SCHEDULES_PAGE} component={FacilitatorScheduleContainer} />
                <Route exact path={RoutePaths.FACILITATORS_CALENDAR_PAGE} component={FacilitatorCalendarContainer} />
                <Route exact path={RoutePaths.RESTAURANTS_PAGE} component={RestaurantContainer} />
            </Switch>
        </Router>
    )
}

export default Routes;