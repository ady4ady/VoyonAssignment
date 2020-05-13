var dataId = 0;
$(".editTask").click(function () {

    dataId = $(this).attr("data-id");

    $('#taskid').val(dataId);
    var url = "/Task/GetTaskJson";
    
    $.ajax({
        url: url,
        data: { taskId: dataId },
        success: function (result) {
            console.log(result)

            $('#tasktitle').val(result.Title);
            $('#taskdescr').val(result.Description);

        }
    });
});