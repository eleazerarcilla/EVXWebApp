var GlobalManageModalSelectedLineName;
var fab = new Fab({
    selector: "#fab",
    button: {
        style: "large teal",
        html: ""
    },
    icon: {
        style: "list icon",
        html: ""
    },
    // "top-left" || "top-right" || "bottom-left" || "bottom-right"
    position: "bottom-right",
    // "horizontal" || "vertical"
    direction: "vertical",
    buttons: [
        {
            button: {
                style: "large yellow",
                html: "GPS"
            },
            icon: {
                style: "map marker alternate icon",
                html: ""
            },
            onClick: function () {
                Manage('Devices', $("#AdminID").val());
            }
        },
        {
            button: {
                style: "large red",
                html: "Lines"
            },
            icon: {
                style: "road icon",
                html: ""
            },
            onClick: function () {
                Manage('Lines', $("#AdminID").val());
            }
        },
        {
            button: {
                style: "large blue",
                html: "Drivers"
            },
            icon: {
                style: "user icon",
                html: ""
            },
            onClick: function () {
                Manage('Drivers', $("#AdminID").val());
            }
        },
        {
            button: {
                style: "large green",
                html: "Reports"
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
function Manage(type, dynamicVar1, dynamicVar2) {
    ClearManageModalContents();
    $("#ManageModal").modal('show');
    switch (type) {
        case 'Lines':
            $("#ManageModalTitle").text("Lines");
            $.get("/api/line/ViewLines/" + dynamicVar1, function (result) {
                ToggleLoader();
                $('#DynamicContent').html(result);
            });
            break;
        case 'Drivers':
            $("#ManageModalTitle").text("Drivers");
            $.get("/api/driver/ViewDrivers/" + dynamicVar1, function (result) {
                ToggleLoader();
                $('#DynamicContent').html(result);
            });
            break;
        case 'Devices':
            $("#ManageModalTitle").text("GPS Devices");
            $.get("/api/device/", function (result) {
                ToggleLoader();
                $('#DynamicContent').html(result);
            });
            break;
        case 'Stations':
            $("#ManageModalTitle").text("Stations under " + dynamicVar2);
            $("#ManageModalBackButton").attr('onclick', "ManageModalBackButtonClicked('Routes');");
            $('#ManageModalBackButton').css('display', 'block');
            $.get("/api/station/ViewStations/" + dynamicVar1, function (result) {
                ToggleLoader();
                $('#DynamicContent').html(result);
            });
            break;
        case 'Routes':

            $("#ManageModalTitle").text("Routes under " + dynamicVar2);
            $("#ManageModalBackButton").attr('onclick', "ManageModalBackButtonClicked('Lines');");
            $('#ManageModalBackButton').css('display', 'block');
            $.get("/api/route/ViewRoutes?LineID=" + dynamicVar1, function (result) {
                ToggleLoader();
                $('#DynamicContent').html(result);
            });
            break;
        case 'DevicesForm':
            //0 - Add, 1 - Update
            $("#ManageModalBackButton").attr('onclick', "ManageModalBackButtonClicked('Devices');");
            $('#ManageModalBackButton').css('display', 'block');
            var device = null, deviceOBJ = null;
            if (dynamicVar1 != 0) {
                device = dynamicVar1;
                deviceOBJ = JSON.parse(dynamicVar1);
                $("#ManageModalTitle").text(deviceOBJ.name);
                $("#DeleteItem").css("display", "block");
                $("#DeleteItem").attr('onclick', "ModalDeleteItem('Devices','" + deviceOBJ.id + "');");
              
           
            } else {
                $("#ManageModalTitle").text('Add new GPS device');
                $("#ManageModalBackButton").attr('onclick', "ManageModalBackButtonClicked('Devices');");
                $('#ManageModalBackButton').css('display', 'block');
            }
            $.ajax({
                url: "/api/Device/GPSFormPartial",
                method: "post",
                contentType: "application/json; charset=utf-8",
                data: device === null ? null : device,
                success: function (result) {
                    ToggleLoader();
                    $('#DynamicContent').html(result);
                    $('#btnSaveGPS').attr('onclick', 'AddUpdateDevice('+(dynamicVar1 != 0 ? 1 : 0)+')');
                },
                error: function (request, status, error) {
                    console.log(request.responseText);
                }
            });

         
            break;
        case 'StationForm':

            var station = dynamicVar1;
            $("#ManageModalTitle").text(dynamicVar1.Name);
            $("#ManageModalBackButton").attr('onclick', "ManageModalBackButtonClicked('Stations');");
            $('#ManageModalBackButton').css('display', 'block');
            $.ajax({
                url: "/api/Station/StationFormPartial",
                method: "post",
                contentType: "application/json; charset=utf-8",
                data: station,
                success: function (result) {
                    ToggleLoader();
                    $('#DynamicContent').html(result);
                },
                error: function (request, status, error) {
                    console.log(request.responseText);
                }
            });

            break;
        case 'LineForm':
            var line = dynamicVar1;
            $("#ManageModalTitle").text(dynamicVar1.Name);
            $("#ManageModalBackButton").attr('onclick', "ManageModalBackButtonClicked('Lines');");
            $('#ManageModalBackButton').css('display', 'block');
            $.ajax({
                url: "/api/Line/LineFormPartial",
                method: "post",
                contentType: "application/json; charset=utf-8",
                data: line,
                success: function (result) {
                    ToggleLoader();
                    $('#DynamicContent').html(result);
                },
                error: function (request, status, error) {
                    console.log(request.responseText);
                }
            });

            break;
        case 'RouteForm':

            var line = dynamicVar1;
            $("#ManageModalTitle").text(dynamicVar1.routeName);
            $("#ManageModalBackButton").attr('onclick', "ManageModalBackButtonClicked('Routes');");
            $('#ManageModalBackButton').css('display', 'block');
            $.ajax({
                url: "/api/Route/RouteFormPartial",
                method: "post",
                contentType: "application/json; charset=utf-8",
                data: line,
                success: function (result) {
                    ToggleLoader();
                    $('#DynamicContent').html(result);
                },
                error: function (request, status, error) {
                    console.log(request.responseText);
                }
            });

            break;
        case 'StationForm':

            var station = dynamicVar1;
            $("#ManageModalTitle").text(dynamicVar1.Description);
            $("#ManageModalBackButton").attr('onclick', "ManageModalBackButtonClicked('Stations');");
            $('#ManageModalBackButton').css('display', 'block');
            $.ajax({
                url: "/api/Station/StationFormPartial",
                method: "post",
                contentType: "application/json; charset=utf-8",
                data: line,
                success: function (result) {
                    ToggleLoader();
                    $('#DynamicContent').html(result);
                },
                error: function (request, status, error) {
                    console.log(request.responseText);
                }
            });

            break;
    }
}

function ManageModalBackButtonClicked(type) {
    switch (type) {
        case 'Lines':
            Manage('Lines', $("#AdminID").val()); break;
        case 'Routes':
            Manage('Routes', $("#HiddenDynamicLineID").val()); break;
        case 'Devices':
            Manage('Devices', $("#AdminID").val()); break;
        case 'Stations':
            Manage('Stations', $("#HiddenDynamicRouteId").val()); break;
    }
}
function ModalDeleteItem(type, Id) {
    switch (type) {
        case 'Devices':
            confirm("Are you sure you want to delete this device?") ?
                $.get('/api/device/deleteDevice/' + Id, function (result) {
                    if (result) {
                        alert("Succesfully deleted GPS device!");
                        Manage('Devices');
                    }
                    else
                        alert("Unable to delete GPS device. " + result.message);
                }) : null;
            break;
    }
}
