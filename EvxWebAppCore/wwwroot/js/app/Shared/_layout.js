var routelist;
var stationList = [];
$(document).ready(function () {
    ProcessNavBar();
    ProcessLinesDD();
    ProcessStationList();
});

function InitiateLogin(url) {
    if ($('#username').val().trim() == '' || $('#password').val().trim() == '') {
        alert('Login failed! Username and password are required!'); return false;
    }
    var loginObject = {
        uname: $('#username').val(),
        pword: $('#password').val()
    };
    $.ajax({
        url: url,
        cache: false,
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify(loginObject),
        success: function (data) {
            if (!data)
                alert('Login failed! Please check your credentials!');
            else {
                $('#LoginModal').modal('hide');
                ClearTextboxes($('#LoginCredentials').children().toArray());
                location.reload();
            }
        },
        type: 'POST'
    });
}

function ProcessNavBar() {
    $.get(window.location.href + "/home/_NavBarPartial", function (result) {
        $('#navbarContent').html(result);
    });
}
function ProcessRouteDD() {
    $.get(window.location.href + "api/route/getroutes", function (result) {
        routelist = result;
        $.each(result, function (index, entry) {
            $('#MainRouteSelect').append($('<option>', {
                value: entry.ID,
                text: entry.routeName,
                'data-StationCount': entry.noOfStations,
                'data-RouteName': entry.routeName
            }));
        });
    });
}

function ProcessLinesDD() {
    $.get(window.location.href + "api/line/GetLines", function (result) {
        routelist = result;
        $.each(result, function (index, entry) {
            $('#MainRouteSelect').append($('<option>', {
                value: entry.ID,
                text: entry.Name,
                'data-LineName': entry.Name
            }));
        });
    });
}


function ProcessSelectedRoute(elem) {
    alert($(elem).find(':selected').attr('data-LineName'));
}

function ClearTextboxes(textboxesArray) {
    $.each(textboxesArray, function (index, entry) {
        $(entry).val('');
    });
}

function ProcessStationList() {
    $.get(window.location.href + "api/destination/getdestinations", function (result) {
        $.each(result, function (index, entry) {
            stationList[index] = entry;
        });
    });
}

function InitiateLogout() {
    $.get(window.location.href + "home/Logout", function (result) {
        if (result)
            location.reload();
    });
}