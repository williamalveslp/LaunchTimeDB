import React, { useState, useEffect } from "react";
import FacilitatorCalendarPage from '../page/facilitator-calendar-page';
import { loadRestaurants, loadUsers } from './functions/load-data';

const FacilitatorContainer = () => {
    const [users, setUsers] = useState([]);
    const [restaurants, setRestaurants] = useState([]);

    const [user, setUser] = useState(0);
    const [restaurant, setRestaurant] = useState(0);
    const [calendarDateSelected, setCalendarDateSelected] = useState(new Date());

    const [schedules, setSchedules] = useState([]);

    useEffect(() => {
        setUsers(loadUsers);
        setRestaurants(loadRestaurants);
    }, []);

    const getRestaurantById = (id) => {
        const found = restaurants.find(f => f.key === id);
        return found;
    }

    const getUserById = (id) => {
        const found = users.find(f => f.key === id);
        return found;
    }

    const clearFields = () => {
        setUser(0);
        setRestaurant(0);
        setCalendarDateSelected(new Date());
    }

    const deleteScheduleByFilter = (userName, restaurantName, date) => {
        const found = schedules.find(f => f.userName === userName
            && f.restaurantName === restaurantName
            && f.date === date);

        if (!found) return false;

        const newSchedules = schedules.filter(item => item !== found);
        setSchedules(newSchedules);
        return true;
    }

    const hasVotedOnSameDay = (userId, votedDate) => {
        const hasVotedSameDay = schedules.find(f => f.userId === userId
            && f.votedDate === votedDate);

        return (hasVotedSameDay != undefined) && (hasVotedSameDay != null);
    }

    return (
        <>
            <FacilitatorCalendarPage
                users={users}
                user={user}
                setUser={setUser}

                restaurants={restaurants}
                restaurant={restaurant}
                setRestaurant={setRestaurant}

                calendarDateSelected={calendarDateSelected}
                setCalendarDateSelected={setCalendarDateSelected}
                getRestaurantById={(id) => getRestaurantById(id)}
                getUserById={(id) => getUserById(id)}
                deleteScheduleByFilter={(userName, restaurantName, date) => deleteScheduleByFilter(userName, restaurantName, date)}
                schedules={schedules}
                setSchedules={setSchedules}
                clearFields={() => clearFields()}
                hasVotedOnSameDay={(userId, votedDate) => hasVotedOnSameDay(userId, votedDate)}
            />
        </>
    );
}

export default FacilitatorContainer;