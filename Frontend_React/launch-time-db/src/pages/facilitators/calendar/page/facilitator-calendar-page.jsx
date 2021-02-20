import React from 'react';
import Calendar from 'react-calendar';
import 'react-calendar/dist/Calendar.css';
import SelectCustom from '../../../../components/select-custom';
import Grid from '@material-ui/core/Grid';
import ButtonCustom from '../../../../components/button-custom';
import Table from 'react-bootstrap/Table';
import Alert from 'react-bootstrap/Alert';
import { isSameWeek } from '../../../../shared/dates-same-week';
import { generateCurrentDate } from '../../../../shared/generate-currente-date';

const FacilitatorCalendarPage = (props) => {

    const { user, setUser, users, restaurants, restaurant, setRestaurant,
        calendarDateSelected, setCalendarDateSelected, getRestaurantById,
        schedules, setSchedules, getUserById, deleteScheduleByFilter, clearFields, hasVotedOnSameDay } = props;

    const confirmToSave = () => {
        const date = calendarDateSelected.toLocaleDateString();

        const isValid = validateRequiredFields();
        if (!isValid)
            return;

        const restaurantSelected = getRestaurantById(restaurant);
        const userSelected = getUserById(user);

        const message = `Tem certeza que deseja Votar no restaurante "${restaurantSelected.label}" na data "${date}"?`;
        const response = window.confirm(message);
        if (!response)
            return;

        // *********  Validation Vote on same day ************
        const currentDate = generateCurrentDate();
        const votedOnSameDay = hasVotedOnSameDay(userSelected.key, currentDate);
        if (votedOnSameDay) {
            alert('Não é permitido o mesmo usuário votar mais de uma vez por dia.');
            return;
        }

        // *********  Validation Restaurant voted on same Week ************
        var sameRestaurantFound = false;
        for (var i = 0; i < schedules.length; i++) {
            if (schedules[i].restaurantName == restaurantSelected.label) {
                sameRestaurantFound = true;
                break;
            }
        }
        if (sameRestaurantFound) {

            const onlyDatesVoted = schedules.map(({ date }) => ({ date }));
            const isDatesFromSameWeek = validateIfSameWeek(onlyDatesVoted, date);

            if (isDatesFromSameWeek) {
                alert('Não é permitido mais de um voto na mesma semana.');
                return;
            }
        }

        let newSchedule = schedules;

        newSchedule.push({
            userId: userSelected.key,
            userName: userSelected.label,
            restauranteId: restaurantSelected.key,
            restaurantName: restaurantSelected.label,
            date: date,
            votedDate: currentDate
        });

        setSchedules(newSchedule);
        alert('Salvo com sucesso!');

        clearFields();
    }

    const validateIfSameWeek = (onlyDatesVoted, dateInformed) => {
        const isDatesFromSameWeek = isSameWeek(onlyDatesVoted, dateInformed);
        return isDatesFromSameWeek;
    }

    const validateRequiredFields = () => {
        if (user === 0) {
            alert('Usuário não foi informado.');
            return false;

        } else if (restaurant === 0) {
            alert('Restaurante não selecionado.');
            return false;
        }
        return true;
    }

    const deleteSchedule = (userName, restaurantName, date) => {

        const message = `Tem certeza que deseja Excluir o voto no "${restaurantName}" em"${date}"?`;
        const response = window.confirm(message);
        if (!response)
            return;

        const result = deleteScheduleByFilter(userName, restaurantName, date);

        if (!result) {
            alert('Voto não encontrado.');
            return;
        }
        alert('Excluído com sucesso.');
    }

    return (
        <>
            <br />
            <Grid container spacing={4}>
                <Grid item xs={3}>
                    <SelectCustom
                        id={'user'}
                        name={'user'}
                        value={user}
                        label={'Usuário'}
                        required='true'
                        items={users}
                        onChange={(e) => setUser(e)}
                    />
                </Grid>
                <Grid item xs={9}>
                </Grid>
            </Grid>
            <br />
            <br />
            <h4>Dia para a escolha do restaurante</h4>
            <Grid container spacing={3}>
                <Grid item xs={4}>
                    <Calendar
                        value={calendarDateSelected}
                        onClickDay={(e) => setCalendarDateSelected(e)}
                    />
                </Grid>
                <Grid item xs={4}>
                    <SelectCustom
                        id={'restaurant'}
                        name={'restaurant'}
                        value={restaurant}
                        label={'Restaurante'}
                        required='true'
                        items={restaurants}
                        onChange={(e) => setRestaurant(e)}
                    />
                    <br />
                    <br />
                    <ButtonCustom
                        label={'Salvar'}
                        type={'button'}
                        onClick={(e) => confirmToSave()}
                    />
                </Grid>

                <Grid item xs={4}>
                </Grid>
            </Grid>

            <br />
            <hr />
            <Grid container spacing={3}>
                <Grid item xs={8}>
                    <h4>Votos</h4>
                    {schedules.length <= 0 &&
                        <>
                            <Alert variant={"warning"}>
                                Não há votos no momento.
                            </Alert>
                        </>
                    }
                    {schedules.length > 0 &&
                        <>
                            <br />
                            <Table striped bordered hover>
                                <thead>
                                    <tr>
                                        <th>Desenvolvedor</th>
                                        <th>Restaurante</th>
                                        <th>Data</th>
                                        <th>Ação</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {schedules.map((item, i) => {
                                        return (
                                            <tr key={i}>
                                                <td>{item.userName}</td>
                                                <td>{item.restaurantName}</td>
                                                <td>{item.date}</td>
                                                <td>
                                                    <ButtonCustom
                                                        label={'Excluir'}
                                                        type={'button'}
                                                        color="secondary"
                                                        onClick={() => deleteSchedule(item.userName, item.restaurantName, item.date)}
                                                    />
                                                </td>
                                            </tr>
                                        )
                                    })}
                                </tbody>
                            </Table>
                        </>
                    }
                </Grid>
                <Grid item xs={4}>
                </Grid>
            </Grid>
        </>
    )
}

FacilitatorCalendarPage.defaultProps = {
}

FacilitatorCalendarPage.propTypes = {

}

export default FacilitatorCalendarPage;