var map;
function initMap() {
    var phpStringForStationMarker = window.location.href;
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
var markers = new Array();
var currentId = 0;
window.setInterval(
    function () {
        var phpStringForStationMarker;
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
                        if (result[key].PrevLat != result[key].Lat && result[key].PrevLng != result[key].Lng) {
                            createMarker(result[key].Lat, result[key].Lng);
                        }
                    });
                }
            });
    }, 5000);
var fab = new Fab({
    selector: "#cont",
    button: {
        style: "large teal",
        html: ""
    },
    icon: {
        style: "list icon",
        html: ""
    },
    // "top-left" || "top-right" || "bottom-left" || "bottom-right"
    position: "bottom-left",
    // "horizontal" || "vertical"
    direction: "vertical",
    buttons: [
        {
            button: {
                style: "small yellow",
                html: ""
            },
            icon: {
                style: "map marker alternate icon",
                html: ""
            },
            onClick: function () {
                alert("GPS DEVICES");
            }
        },
        {
            button: {
                style: "small red",
                html: ""
            },
            icon: {
                style: "road icon",
                html: ""
            },
            onClick: function () {
                alert("LINES");
            }
        },
        {
            button: {
                style: "small blue",
                html: ""
            },
            icon: {
                style: "user icon",
                html: ""
            },
            onClick: function () {
              alert("DRIVERS");
            }
        },
        {
            button: {
                style: "small green",
                html: ""
            },
            icon: {
                style: "chart line icon",
                html: ""
            },
            onClick: function () {
                alert("REPORTS");
            }
        }
    ],
    onOpen: function () {

    },
    onClose: function () {

    }
});

