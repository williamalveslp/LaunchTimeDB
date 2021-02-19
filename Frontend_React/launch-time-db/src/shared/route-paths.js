const RoutePaths = {
    ROOT: '/',
    // Facilitators
    FACILITATORS_PAGE: '/Facilitator/List/',
    // Restaurants
    RESTAURANTS_PAGE : '/Restaurant/List/'
};

const RouteItems = {
    ROOT: {
        route: RoutePaths.ROOT,
        label: 'Home'
    },
    // Facilitators
    FACILITATORS_PAGE: {
        route: RoutePaths.FACILITATORS_PAGE,
        label: 'Agenda'
    },
    // Restaurants
    RESTAURANTS_PAGE: {
        route: RoutePaths.RESTAURANTS_PAGE,
        label: 'Restaurantes'
    }
}

export { RoutePaths, RouteItems };