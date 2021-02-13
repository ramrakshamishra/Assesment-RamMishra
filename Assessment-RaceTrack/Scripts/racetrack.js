
    var totalCount = 0;
    $(document).ready(function () {
        //Load vehicle list
        LoadList();
        $('#btnAdd').on("click", function () {
        location.href = "/Vehicle/Create";
        });
    });
    function RemoveVehicle(vehicleId) {
        if (confirm('Are you sure want to delete?')) {
        $.ajax({
            type: "POST",
            dataType: 'TEXT',
            url: "/Track/RemoveVehicleFromTrack",
            data: { "vehicleId": vehicleId },
            success: function () {
                LoadList();
            },
            error: function () {
                alert("Error");
            }
        });

        }
    }
    function LoadList() {
        $.ajax({
            type: "GET",
            url: "/Track/GetVehicle",
            contentType: 'application/html; charset=utf-8',
            dataType: 'html',
            success: function (result) {
                $('#dvList').html(result);
                //Enable/disable add button
                EnableDisableAddButon();
            }
        });
    }
    function EnableDisableAddButon() {
        var total = parseInt($('#rowCount').text());
        if (isNaN(total))
            total = 0;
        //Enable disable the add button
        if (total ==5)
            $('#btnAdd').attr('disabled', 'disabled');
        else
            $('#btnAdd').removeAttr('disabled');
    }
