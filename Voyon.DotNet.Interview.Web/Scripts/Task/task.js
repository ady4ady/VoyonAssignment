$(".editTask").click(function () {

   var dataId = $(this).attr("data-id");
    var dataAssignedUserId = $(this).attr("data-assigneduserid");


    $('#assignedUserId').val(dataAssignedUserId);


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

function OnSuccess(data) {
    location.reload();
}