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
    position: "bottom-left",
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
                html:"Reports"
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
            $.get("/api/device/ViewDevices/", function (result) {
                ToggleLoader();
                $('#DynamicContent').html(result);
            });
            break;
        case 'Stations':
            $("#ManageModalTitle").text("Stations under " + dynamicVar2);
            $("#ManageModalBackButton").attr('onclick', "ManageModalBackButtonClicked('Routes');");
            $('#ManageModalBackButton').css('display', 'block');
            $.get("/api/destination/ViewStations/" + dynamicVar1, function (result) {
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
    }
}
function ClearManageModalContents() {
    $("#Loader").css('display', 'block');
    $('#ManageModalBackButton').css('display', 'none');
    $("#DynamicContent").text('');
}
function ManageModalBackButtonClicked(type) {
    switch (type) {
        case 'Lines':
            Manage('Lines', $("#AdminID").val()); break;
        case 'Routes':
            Manage('Routes', $("#HiddenDynamicLineID").val()); break;
    }
}