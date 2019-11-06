var routelist;
$(document).ready(function () {
    ProcessRouteDD();
});

function InitiateLogin(url) {
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
                alert('Login success!');
                $('#LoginModal').modal('hide');
                ClearTextboxes($('#LoginCredentials').children().toArray());
            }
        },
        type: 'POST'
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

function ProcessSelectedRoute(elem) {
    alert($(elem).find(':selected').attr('data-RouteName'));
}

function ClearTextboxes(textboxesArray) {
    $.each(textboxesArray, function (index, entry) {
        $(entry).val('');
    });
}