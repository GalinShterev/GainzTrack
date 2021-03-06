﻿// Write your JavaScript code.
let acc = document.getElementsByClassName("accordion");

for (let i = 0; i < acc.length; i++) {
    acc[i].addEventListener("click", function () {
        this.classList.toggle("active");
        var panel = this.nextElementSibling;
        if (panel.style.maxHeight) {
            panel.style.maxHeight = null;
        } else {
            panel.style.maxHeight = "100vh";
        }
    });
}

//jQuery time
var current_fs, next_fs, previous_fs; //fieldsets
var left, opacity, scale; //fieldset properties which we will animate
var animating; //flag to prevent quick multi-click glitches

$(".next").click(function () {
    if (animating) return false;
    animating = true;

    current_fs = $(this).parent();
    next_fs = $(this).parent().next();

    //activate next step on progressbar using the index of next_fs
    $("#progress-bar li").eq($("fieldset").index(next_fs)).addClass("active-bar");

    //show the next fieldset
    next_fs.show();
    //hide the current fieldset with style
    current_fs.animate({ opacity: 0 }, {
        step: function (now, mx) {
            //as the opacity of current_fs reduces to 0 - stored in "now"
            //1. scale current_fs down to 80%
            scale = 1 - (1 - now) * 0.2;
            //2. bring next_fs from the right(50%)
            left = (now * 50) + "%";
            //3. increase opacity of next_fs to 1 as it moves in
            opacity = 1 - now;
            current_fs.css({
                'transform': 'scale(' + scale + ')',
                'position': 'relative',
                'display': 'none'
            });
            next_fs.css({ 'left': left, 'opacity': opacity });
        },
        duration: 500,
        complete: function () {
            current_fs.hide();

            animating = false;

        },

    });
});

$(".previous").click(function () {
    if (animating) return false;
    animating = true;

    current_fs = $(this).parent();
    previous_fs = $(this).parent().prev();

    //de-activate current step on progressbar
    $("#progress-bar li").eq($("fieldset").index(current_fs)).removeClass("active-bar");

    //show the previous fieldset
    previous_fs.show();
    //hide the current fieldset with style
    current_fs.animate({ opacity: 0 }, {
        step: function (now, mx) {
            //as the opacity of current_fs reduces to 0 - stored in "now"
            //1. scale previous_fs from 80% to 100%
            scale = 0.8 + (1 - now) * 0.2;
            //2. take current_fs to the right(50%) - from 0%
            left = ((1 - now) * 50) + "%";
            var newLeft = ((1 - now) * 50) - 50 + '%';
            //3. increase opacity of previous_fs to 1 as it moves in
            opacity = 1 - now;
            current_fs.css({ 'left': left, 'display': 'none' });
            previous_fs.css({ 'left': newLeft, 'transform': 'scale(' + scale + ')', 'opacity': opacity, 'position': 'relative' });
        },
        duration: 800,
        complete: function () {
            current_fs.hide();
            animating = false;
        },


    });
});


var id = 0;
$('.days-dropdown').on('click', '#add-day', function () {

    id++;

    $('.add-day-style').remove();

    $.ajax({

        url: '/Workout/AddExercise',
        dataType: "html",
        success: function (data) {
            $('.days-dropdown').append(data);

            $('.days-dropdown').append('<h4 id="add-day" class="add-day-style">Add day</h4>');
        }
    });

});

var triggered = true;

if (triggered) {

    $('.days-dropdown').on('click', '.add-exercise-button', function () {
        var exercisesAddDiv = $(this).parents().eq(5).children().eq(2);
        var selectedExerciseName = $(this).parents().eq(0).children().eq(1).text();

        $.ajax({
            url: '/Workout/GetSingleExercise',
            type: "POST",
            data: { Name: selectedExerciseName},
            dataType: "html",
            success: function (data) {
                exercisesAddDiv.append(data);
                $('.remove-exercise-button').on('click', function () {
                    $(this).parent().remove();
                });
            }
        });
    });
    triggered = false;
}


//allExercises - var b = $('div[id=exercise]').toArray();
//day - b[0].parentElement.parentElement.children[1].value
//exerciseName - b[0].children[0].children[0].value

function addExercisesToDays() {
    var allExercises = $('div[id=onPost]').toArray();
    for (var i = 0; i < allExercises.length; i++) {
        var day = allExercises[i].parentElement.parentElement.children[1].value;
        var exerciseName = allExercises[i].children[0].value;

        $('.days-dropdown').append('<input value="' + exerciseName + '-' + day + '" readonly="readonly" style="display:none;" type="text" id = "ExerciseName" name = "ExerciseName" />')
    }
}

$('.edit').on('click', function () {
    addExercisesToDays();
});

$('.submit').on('click', function () {
    addExercisesToDays();
});



$('.remove-exercise-button').on('click', function () {
    $(this).parent().remove();
});

$('.days-dropdown').on('click', '.remove-day-style', function () {
    //var button_id = $(this).attr("id");

    $(this).parent().remove()

    //$('#' + button_id).remove();
    //$('#add-day').remove();

    if ($('.days-dropdown').has('select').length === 0) {
        id = 0;
    }
});

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

$('.dashboard-toggle-btn').on('click', function () {

    if ($('.dashboard-sidebar').hasClass('dashboard-sidebar--active')) {
        setTimeout(function () {
            $('.navbar-item-text').toggleClass('hide-opacity');
        }, 500);
        $('.dashboard-sidebar').toggleClass('dashboard-sidebar--active');
        $('.dashboard-content-wrapper').toggleClass('dashboard-content-wrapper--active');
        $('.dashboard-logo').toggleClass('dashboard-logo--active');
        $('.dashboard-toggle-btn').toggleClass('dashboard-toggle-btn--active');
    }
    else {
        setTimeout(function () {
            $('.dashboard-sidebar').toggleClass('dashboard-sidebar--active');
            $('.dashboard-content-wrapper').toggleClass('dashboard-content-wrapper--active');
            $('.dashboard-logo').toggleClass('dashboard-logo--active');
            $('.dashboard-toggle-btn').toggleClass('dashboard-toggle-btn--active');
        }, 500);

        $('.navbar-item-text').toggleClass('hide-opacity');
    }
});

$('.dashboard-list-img').on('click', function () {
    $('.dashboard-dropmenu-item').toggleClass('dashboard-dropmenu-item--active');
});

jQuery(document).ready(function ($) {

    $('#checkbox').change(function () {
        setInterval(function () {
            moveRight();
        }, 3000);
    });

    var slideCount = $('#slider ul li').length;
    var slideWidth = $('#slider ul li').width();
    var slideHeight = $('#slider ul li').height();
    var sliderUlWidth = slideCount * slideWidth;

    $('#slider').css({ width: slideWidth, height: slideHeight });

    $('#slider ul').css({ width: sliderUlWidth, marginLeft: - slideWidth });

    $('#slider ul li:last-child').prependTo('#slider ul');

    function moveLeft() {
        $('#slider ul').animate({
            left: + slideWidth
        }, 200, function () {
            $('#slider ul li:last-child').prependTo('#slider ul');
            $('#slider ul').css('left', '');
        });
    };

    function moveRight() {
        $('#slider ul').animate({
            left: - slideWidth
        }, 200, function () {
            $('#slider ul li:first-child').appendTo('#slider ul');
            $('#slider ul').css('left', '');
        });
    };

    $('a.control_prev').click(function () {
        moveLeft();
    });

    $('a.control_next').click(function () {
        moveRight();
    });

});  

$('.workout-create-btn').on('click', function () {
    var dropmenu = $('.workout-dropmenu-item').toggleClass('workout-dropmenu-item--active');
    var menuWidth = 0;
    if (dropmenu.hasClass('workout-dropmenu-item--active')) {
        menuWidth = $('.workout-dropmenu-item').width() + 5;
    }
    var style = $('<style>.workout-create-btn{ margin-right:' + menuWidth+'px; }</style>');
    $('html > head').append(style);
});

$('.workouts-selector-item').on('click', function () {
    $('.workouts-selector-item').removeClass('workouts-selector-item--active');
    var spanValue = $(this).children().eq(0).text();
    $(this).addClass('workouts-selector-item--active');

        $.ajax({
            url: '/Workout/GetWorkoutsByAvailability',
            dataType: "html",
            data: { availability: spanValue},
            success: function (data) {
                $('.workouts-list').html("");
                $('.workouts-list').append(data);

            }
        });
});


$('#logout-btn').on('click', function () {
    $('#logout-form').submit();
});


$('.achievements-menu-item').on('click', function () {

    var activeItemClass = 'achievements-menu-item--active';

    $('.achievements-menu-item').removeClass(activeItemClass);
    $(this).addClass(activeItemClass)
});

$(".show").on("click", function () {

    var achievementId = $(this).parents().eq(1).children().eq(0).text();

    $.ajax({
        url: '/Moderation/GetAchievementUserModal',
        dataType: "html",
        data: { achievementUserId: achievementId },
        success: function (data) {
            $('.custom-modal-content').append(data);
            $(".mask").addClass("active");
        }
    }); 
});

$(".profile-workout-item").on('click', function () {

    var workoutName = $(this).find('.profile-workout-name').text();
    var username = $(this).find('.workout-user-information-username').text();
    $.ajax({
        url: '/Workout/GetWorkoutModal',
        dataType: "html",
        data: { workoutName: workoutName, username : username },
        success: function (data) {
            $('.custom-modal-content').append(data);
            $(".mask").addClass("active");
        }
    }); 

    $('.mask').addClass("active");
    
});

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
                $('#click-custom-modal').prop('checked', false);
                $('#custom-exercise-error').css('display', 'block');
                $('#custom-exercise-error').append(response.responseText);
                setTimeout(function () {
                    $('#custom-exercise-error').css('display', 'none');
                    $('#custom-exercise-error').html("");
                }, 3000);
            } else {
                $.ajax({
                    url: '/Exercises/AddExercisesToModal',
                    type: "GET",
                    dataType: "html",
                    success: function (data) {
                        var g = $('.exercises-modal-item').toArray();
                        for (var i = 0; i < g.length; i++) {
                            g[i].children[1].innerHTML = ""
                            g[i].children[1].innerHTML = data;
                        }                  
                    }
                });  
                $('#click-custom-modal').prop('checked', false);
                $('#custom-exercise-success').css('display', 'block');
                $('#custom-exercise-success').append(response.responseText);
                setTimeout(function () {
                    $('#custom-exercise-success').css('display', 'none');
                    $('#custom-exercise-success').html("");
                }, 3000);

            }   
        }
    });
   
});

// Function for close the Modal

function closeModal() {
    $(".mask").removeClass("active");
    $('.custom-modal-content').html("");
    $('.loading-bro').removeClass('loading-bro--active');
}

// Call the closeModal function on the clicks/keyboard

$(".close, .mask").on("click", function () {
    closeModal();
});

$(document).keyup(function (e) {
    if (e.keyCode === 27) {
        closeModal();
    }
});


$('.profile-workout-delete-btn').on('click', function () {
    $('.profile-workout-hidden-option').toggleClass('profile-workout-hidden-option--deactivate');
});

$('#submit-achievement').on('click', function () {
    $('.mask').addClass('active');
    $('.loading-bro').addClass('loading-bro--active');
});