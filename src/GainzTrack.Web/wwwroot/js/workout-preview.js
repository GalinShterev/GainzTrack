$('.workout-func-btn').on('click', function () {
    $('.preview-container').html("");
    var workoutName = $(this).attr('id');
    $.ajax({
        url: '/Workout/WorkoutPreview',
        dataType: "html",
        data: { Workoutname: workoutName },
        success: function (data) {
            $('.preview-container').append(data);
        }
    });
});