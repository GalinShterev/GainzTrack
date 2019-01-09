$('.custom-exercise-submit').on('click', function () {

    var exerciseName = $('#custom-exercise-name').val();
    var videoUrl = $('#custom-exercise-videoUrl').val();

    $.ajax({
        url: '/Exercises/AddNewExercise',
        type: "POST",
        data: { exerciseName: exerciseName, videoUrl: videoUrl },
        dataType: "json",
        success: function (response) {
            if (!response.success) {
                $('.custom-exercises-modal-item').append(response.responseText);
            } else {
                $.ajax({
                    url: '/Exercises/AddExercisesToModal',
                    type: "GET",
                    dataType: "html",
                    success: function (data) {
                        $('.exercises-modal-item').children().eq(1).html("");
                        $('.exercises-modal-item').children().eq(1).append(data);
                    }
                });  
            }   
        }
    });
   
});