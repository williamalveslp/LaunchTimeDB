const RoutePaths = {
    ROOT: '/',
    // Facilitators
    FACILITATORS_CALENDAR_PAGE: '/Facilitador/Calendario/',
    FACILITATORS_SCHEDULES_PAGE: '/Facilitador/Agenda/',
    // Restaurants
    RESTAURANTS_PAGE: '/Restaurantes/Listagem/'

};

const RouteItems = {
    ROOT: {
        route: RoutePaths.ROOT,
        label: 'Home'
    },
    // Facilitators
    FACILITATORS_CALENDAR_PAGE: {
        route: RoutePaths.FACILITATORS_CALENDAR_PAGE,
        label: 'Calendário'
    },
    FACILITATORS_SCHEDULES_PAGE:{
        route: RoutePaths.FACILITATORS_SCHEDULES_PAGE,
        label: 'Agenda'
    },
    // Restaurants
    RESTAURANTS_PAGE: {
        route: RoutePaths.RESTAURANTS_PAGE,
        label: 'Restaurantes'
    }
}

export { RoutePaths, RouteItems };