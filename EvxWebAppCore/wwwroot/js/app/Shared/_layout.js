$(document).ready(function () {
  
});

function InitiateLogin(url) {
    var loginObject = {
        uname: $('#username').val(),
        pword: $('#password').val()
    };
    BuildAjax(url, 'json', 'POST', JSON.stringify(loginObject))
}

function BuildAjax(url, format, method, object) {
    $.ajax({
        url: url,
        cache: false,
        contentType: 'application/json',
        dataType: 'json',
        data: object,
        success: function (data) {
            alert(data);
        },
        type: method
    });
}