function AddUpdateDevice(method) {
    //0 - Add, 1 - Update
    if (ValidateGPSDetails()) {
        var DevicePHPObject = {
            deviceID: $("#txtDeviceID").val(),
            name: $("#txtDeviceName").val(),
            uniqueId: $("#txtIMEI").val(),
            phoneNo: $("#txtMobileNumber").val(),
            model: $("#Network").val(),
            plateNumber: $("#txtPlateNumber").val(),
            tblRoutesID: 0,
            tblUsersID: $('#Drivers').val(),
            tblLineID: $("#Lines").val()
        };
        $.ajax({
            url: "/api/Device/" + (method === 0 ? "AddDevice" : "UpdateDevice"),
            method: "POST",
            contentType: "application/json",
            data: JSON.stringify(DevicePHPObject),
            success: function (result) {
                if (result.status === "true") {
                    alert(result.message);
                    Manage('Devices');
                }
                else
                    alert(result.message === null ? "Unable to save GPS. Please verify if GPS information are all correct." : result.message);

            },
            error: function (request, status, error) {
                console.log(request.responseText);
            }
        });
    }
    else {
        alert("Unable to save GPS. Please verify if GPS information are all correct.");
    }
 
}
function ValidateGPSDetails() {
    if ($("#txtIMEI").val().trim() === '')
        return false;
    if ($("#txtMobileNumber").val().trim() === '')
        return false;
    if ($("#Network").val().trim() === '')
        return false;
    if ($("#Lines").val().trim() === '')
        return false;
    return true;
}