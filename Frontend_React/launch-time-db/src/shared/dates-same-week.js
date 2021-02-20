const compareWeek = require('compare-week');



function getMinAndMax(dates) {
    var result = {};
    for (var index in dates) {
        var thisDate = dates[index]
            , dateParts = thisDate.split(/\//)
            , fullDate = new Date(dateParts[2], dateParts[0] - 1, dateParts[1]);
        if (!result['max'] || fullDate > result['max']) {
            result['max'] = fullDate;
        }
        if (!result['min'] || fullDate < result['min']) {
            result['min'] = fullDate
        }
    }
    return result;
}
function isSameWeek(datesArray, newDate) {

    debugger;
    for (var i = 0; i < datesArray.length; i++) {
        debugger;
        const dateItem = stringToDate(datesArray[i], 'dd/MM/yyyy', "/");
        let newDateDate = stringToDate(newDate[i], 'dd/MM/yyyy', "/");

        const isSameWeek = compareWeek(dateItem, newDateDate);

        if (isSameWeek)
            return true;
    }
    return false;

    /* debugger;
 
     var minAndMax = getMinAndMax(dates)
         , dayOfWeek = {}
     dayOfWeek['min'] = minAndMax['min'].getDay();
     dayOfWeek['max'] = minAndMax['max'].getDay();
     debugger;
     
     if (minAndMax['max'] - minAndMax['min'] > 518400000 || dayOfWeek['min'] > dayOfWeek['max']) {
         return false;
     }
     return true; */
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