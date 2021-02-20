function loadRestaurants() {
    const restaurantsList = [
        { key: 0, label: 'Selecione' },
        { key: 1, label: 'Atelier das Massas' },
        { key: 10, label: 'Baalbek' },
        { key: 11, label: 'Bistro' },
        { key: 6, label: 'Costela no Roletchê' },
        { key: 9, label: 'Daimu' },
        { key: 4, label: 'Delícias na Panela' },
        { key: 3, label: 'Forno a Lenha' },
        { key: 7, label: 'El Tonel' },
        { key: 12, label: 'Lancheria do Parque' },
        { key: 5, label: 'Sabores na Panela' },
        { key: 8, label: 'Sambô' },
        { key: 2, label: 'Panela de Ferro' }
    ];
    return restaurantsList;
}

function loadUsers() {
    const usersList = [
        { key: 0, label: 'Selecione' },
        { key: 2, label: 'Carlos Antônio' },
        { key: 4, label: 'Lucas Alves' },
        { key: 1, label: 'João Pedro' },
        { key: 7, label: 'Juliana Alburquerque' },
        { key: 6, label: 'Marcelo da Silva' },
        { key: 5, label: 'Marcia Abgail' },
        { key: 3, label: 'Patrícia Almeida' }
    ];

    return usersList;
}

export { loadRestaurants, loadUsers };