// It's using: npm install compare-week.
const compareWeek = require('compare-week');

function isSameWeek(datesArray, dateToCompare) {
    for (var i = 0; i < datesArray.length; i++) {
        const dateItemAsDate = stringToDate(datesArray[i].date, 'dd/MM/yyyy', "/");
        const dateToCompareAsDate = stringToDate(dateToCompare, 'dd/MM/yyyy', "/");

        const isSameWeek = compareWeek(dateItemAsDate, dateToCompareAsDate);

        if (isSameWeek)
            return true;
    }
    return false;
}

function stringToDate(_date, _format, _delimiter) {
    // Samples to call this funcion.
    /*stringToDate("17/9/2014","dd/MM/yyyy","/");
    stringToDate("9/17/2014","mm/dd/yyyy","/");
    stringToDate("9-17-2014","mm-dd-yyyy","-"); */

    var formatLowerCase = _format.toLowerCase();
    var formatItems = formatLowerCase.split(_delimiter);
    var dateItems = _date.split(_delimiter);
    var monthIndex = formatItems.indexOf("mm");
    var dayIndex = formatItems.indexOf("dd");
    var yearIndex = formatItems.indexOf("yyyy");
    var month = parseInt(dateItems[monthIndex]);
    month -= 1;
    var formatedDate = new Date(dateItems[yearIndex], month, dateItems[dayIndex]);
    return formatedDate;
}



export { isSameWeek };