$(document).ready(function () {
var date_load = new Date().toUTCString()
var wl = window.location;
var path_url = wl.protocol + '//' + wl.host + wl.pathname;

$.getJSON('/Home/GetPageData', { index_path: path_url, time_load: date_load }, function (data) {
    //var long = (data.measure_server / 100000000).toFixed(3);
    $('#message-info').append(data.result + '%');
    $('#message-info-page').append(data.path);
    $('#base-div').css('height', '17px');
    $('#inner-div').css('width', data.result + '%');
}).fail(function (jqxhr, settings, ex) { alert('The request is not processed: ' + ex); });
});
//$('#btn-dontshow').click(function () {
//    $('#shell-div').css('display', 'none');
//});
$('#btn-close').click(function () {
    $('#shell-div').toggle();
});