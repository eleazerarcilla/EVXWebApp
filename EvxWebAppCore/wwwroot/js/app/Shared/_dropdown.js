
var clickevents = new Array(2);
var indexctr = 0;
$(".btnOpenDropdown").off().on('click', function (e) {
    
    $(".dropdown").hide();
    
    var dropdownID = $(this)[0].dataset.dropdownid;
    var modalTop = $("#ManageModal>.modal-dialog.modal-lg>.modal-content>.modal-body").offset().top;
    var modalLeft = $("#ManageModal>.modal-dialog.modal-lg>.modal-content>.modal-body").offset().left;
    $("#" + dropdownID).css({ top: e.pageY - modalTop, left: e.pageX - modalLeft, display: "block" });
    $("#" + dropdownID).show();
    if (indexctr % 2 == 0)
        clickevents[0] = "btnOpenDropdown";
    else
        clickevents[1] = "btnOpenDropdown"
    indexctr++;
})
$("body").off().on('click', function (e) {
    
    if (indexctr % 2 == 0) {
        clickevents[0] = "body";
        if (clickevents[1] != "btnOpenDropdown") {
            $(".dropdown").hide();
        }
    }
    else {
        clickevents[1] = "body";
        if (clickevents[0] != "btnOpenDropdown") {
            $(".dropdown").hide();
        }
    }
    indexctr++;



})
function Delete(id, recordtype) {
    
    var url;
    if (confirm("Are you sure you want to delete this " + recordtype + "?")) {
        if (recordtype == 'Line')
            url = window.location.href + "api/Line/DeleteLine?lineID=" + id;

        $.ajax({
            url: url,
            method: "GET",
            beforeSend: function () {
                //show loading gif here
            },
            success: function (result) {
                
                alert(recordtype + " successfully deleted");
                Manage('Lines', $("#AdminID").val());

            },
            error: function (result) {

            }

        });
    }
}