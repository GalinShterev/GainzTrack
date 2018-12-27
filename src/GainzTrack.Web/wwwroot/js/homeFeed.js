var animating = false;

//$('#home-feed').on('click', function () {
//    if (animating) { return false; }
//    animating = true;
//    $.ajax({
//        url: '/Home/GetHomeFeed',
//        dataType: "html",
//        success: function (data) {
//            $('.dashboard-content').html("");
//            $('.dashboard-content').append(data);
//            animating = false;
//        }
//    });
//});

//$('#workouts-feed').on('click', function () {
//    if (animating) { return false; }
//    animating = true;
//    $.ajax({
//        url: '/Workout/WorkoutFeed',
//        dataType: "html",
//        success: function (data) {
//            $('.dashboard-content').html("");
//            $('.dashboard-content').append(data);         
//            animating = false;
//        }
//    });
//});

//$('#athletes-feed').on('click', function () {
//    if (animating) { return false; }
//    animating = true;
//    $.ajax({
//        url: '/Users/GetAllUsers',
//        dataType: "html",
//        success: function (data) {
//            $('.dashboard-content').html("");
//            $('.dashboard-content').append(data);
//            animating = false;
//        }
//    });
//});

//$('#administration-feed').on('click', function () {
//    if (animating) { return false; }
//    animating = true;
//    $.ajax({
//        url: '/Administration/Index',
//        dataType: "html",
//        success: function (data) {
//            $('.dashboard-content').html("");
//            $('.dashboard-content').append(data);
//            animating = false;
//        }
//    });
//});


//$('#create-workout').on('click', function () {
//    $.ajax({
//        url: '/Workout/Create',
//        dataType: "html",
//        success: function (data) {
//            $('.dashboard-content').html("");
//            $('.dashboard-content').append(data);
//        }
//    });
//});

(function () {
    $('.dashboard-nav__item').on('click', function (e) {
        var itemId;
        $('.dashboard-nav__item').removeClass('dashboard-nav__item--selected');
        $(this).addClass('dashboard-nav__item--selected');
        itemId = $(this).attr('id');
        $('.dashboard-content__panel').hide();
        $('.dashboard-content__panel[data-panel-id=' + itemId + ']').show();
        if (itemId === 'workouts-feed') {
            $('.dashboard-preview').show();
        } else {
            $('.dashboard-preview').hide();
        }
        return console.log(itemId);
    });

    $('.dashboard-list__item').on('click', function (e) {
        var itemId;
        e.preventDefault();
        $('.dashboard-list__item').removeClass('dashboard-list__item--active');
        $(this).addClass('dashboard-list__item--active');
        itemId = $(this).attr('data-item-id');
        $('.dashboard-preview__panel').hide();
        $('.dashboard-preview__panel[data-panel-id=' + itemId + ']').show();
        return console.log(itemId);
    });

}).call(this);

$('.workout-item').on('click', function () {
    $('.dashboard-preview').html("");
    var workoutName = $(this).children().eq(1).text();
    $.ajax({
        url: '/Workout/WorkoutPreview',
        dataType: "html",
        data: {Workoutname: workoutName},
        success: function (data) {
            $('.dashboard-preview').append(data);
        }
    });
});