var routelist;
var stationList = new Array();
//map related
var map;
var markers = new Array();
var currentId = 0;
var phpStringForStationMarker = window.location.href;

$(document).ready(function () {
    ProcessNavBar();
    ProcessLinesDD();
    ProcessStationList();
    //allow login using enter key
    $("#username").keyup(function (event) {
        if (event.keyCode === 13) {
            $("#LoginButton").click();
        }
    });
    $("#password").keyup(function (event) {
        if (event.keyCode === 13) {
            $("#LoginButton").click();
        }
    });
  
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
    $.get("/home/_NavBarPartial", function (result) {
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
    $.get(window.location.href + "api/station/getstations", function (result) {
        stationList = result;
        initMap();
    });
}

function InitiateLogout() {
    $.get(window.location.href + "home/Logout", function (result) {
        if (result)
            location.reload();
    });
}

function ToggleLoader() {
    $('#Loader').css('display', ($('#Loader').css('display') === "block" ? "none" : "block"));
}
function ClearManageModalContents() {
    $("#Loader").css('display', 'block');
    $('#ManageModalBackButton').css('display', 'none');
    $("#DynamicContent").text('');
    $("#DeleteItem").css("display", "none");
}
function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 15,

    });
    initialLocation = new google.maps.LatLng(14.42576, 121.03898);
    map.setCenter(initialLocation);
    //    if (navigator.geolocation) {
    //  navigator.geolocation.getCurrentPosition(function (position) {
    //      initialLocation = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
    //      map.setCenter(initialLocation);
    //  });
    // }

    var icons = {
        station: {
            icon: phpStringForStationMarker + 'images/stationmarker.png'
        }
    };
    for (var i = 0; i < stationList.length; i++) {
      
        marker = new google.maps.Marker({
            position: new google.maps.LatLng(stationList[i].Lat, stationList[i].Lng),
            icon: icons['station'].icon,
            map: map
        });
        var stationDescription = stationList[i].Description;
        addClickHandler(marker, stationDescription);
    }
    var card = document.getElementById('pac-card');
    var input = document.getElementById('pac-input');
    var input_d = document.getElementById('pac-input-d');
    map.controls[google.maps.ControlPosition.TOP_RIGHT].push(card);

    function setupClickListener(id) {
        var radioButton = document.getElementById(id);
    }

    setupClickListener('changetype-all', []);
    setupClickListener('changetype-address', ['address']);
    setupClickListener('changetype-establishment', ['establishment']);
    setupClickListener('changetype-geocode', ['geocode']);
}
function addClickHandler(stationMarker, stationDescription) {
    google.maps.event.addListener(stationMarker, 'click', function () {
        alert(stationDescription);
    });
}
window.setInterval(
    function () {
        var icons = {
            vehicle: {
                icon: phpStringForStationMarker + 'images/vehiclemarker.png'
            }
        };

        var uniqueId = function () {
            return ++currentId;
        };

        var createMarker = function (latitude, longitude) {
            
            var id = uniqueId(); // get new id
            var marker = new google.maps.Marker({ // create a marker and set id
                id: id,
                position: new google.maps.LatLng(latitude, longitude),
                map: map,
                icon: icons['vehicle'].icon
            });
            var icon = marker.getIcon();
            icon.rotation = 10;
            marker.setIcon(icon);
            console.log(marker);


            markers[id] = marker; // cache created marker to markers object with id as its key
            return marker;
        };
        var clearVehicleMarker = function () {

            markers.forEach(function (marker) {
                marker.setMap(null);
            });


        }


        $.ajax(
            {
                type: "GET",
                beforeSend: function (xhr) {
                    /* Authorization header */
                    xhr.setRequestHeader("Authorization", "Basic " + btoa("meadumandal@yahoo.com:password"));
                },
                url: "https://samm-6bab0.firebaseio.com/drivers.json",
                success: function (result) {
                    
                    clearVehicleMarker();

                    Object.keys(result).forEach(function (key) {
                        //if (result[key].PrevLat != result[key].Lat && result[key].PrevLng != result[key].Lng) {
                            createMarker(result[key].Lat, result[key].Lng);
                        //}
                    });
                },
                error: function (request, status, error) {
                    
                }
            });
    }, 5000);