function loadRestaurants() {
    const restaurantsList = [
        { key: 0, label: 'Selecione' },
        { key: 1, label: 'Atelier das Massas' },
        { key: 2, label: 'Panela de Ferro' },
        { key: 3, label: 'Forno a Lenha' },
        { key: 4, label: 'Delícias na Panela' },
        { key: 5, label: 'Sabores na Panela' },
        { key: 6, label: 'Costela no Roletchê' },
        { key: 7, label: 'El Tonel' },
        { key: 8, label: 'Sambô' },
        { key: 9, label: 'Daimu' },
        { key: 10, label: 'Baalbek' },
        { key: 11, label: 'Bistro' },
        { key: 12, label: 'Lancheria do Parque' }
    ];
    return restaurantsList;
}

function loadUsers() {
    const usersList = [
        { key: 0, label: 'Selecione' },
        { key: 1, label: 'João Pedro' },
        { key: 2, label: 'Carlos Antônio' },
        { key: 3, label: 'Patrícia Almeida' },
        { key: 4, label: 'Lucas Alves' },
        { key: 5, label: 'Marcia Abgail' },
        { key: 6, label: 'Marcelo da Silva' },
        { key: 7, label: 'Juliana Alburquerque' }
    ];

    return usersList;
}

export { loadRestaurants, loadUsers };