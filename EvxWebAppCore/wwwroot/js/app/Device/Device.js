function AddUpdateDevice() {
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
    console.log(DevicePHPObject);
    $.ajax({
        url: "/api/Device/UpdateDevice",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(DevicePHPObject),
        success: function (result) {
            if (result.status === "false")
                alert(result.message === null ? "Unable to update GPS info. Please verify if GPS information are all correct.");
        },
        error: function (request, status, error) {
            console.log(request.responseText);
        }
    });
}