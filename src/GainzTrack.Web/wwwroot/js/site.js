// Write your JavaScript code.
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

var triggered = false;
var id = 0;
$('.days-dropdown').on('click', '#add-day', function () {

    id++;

    $('.days-dropdown').append('<div id="' + id + '"></div>')
    $('#' + id + '').append('<h4 id="' + id + '" class="remove-day-style">Remove</h4>');


    $('#' + id + '').append('<select id="remove-' + id + '" class="select-dropdown" name="days">' +
        '<option value = "1">Monday</option>' +
        '<option value = "2">Tuesday</option>' +
        '<option value = "3">Wednesday</option>' +
        '<option value = "4">Thursday</option>' +
        '<option value = "5">Friday</option>' +
        '<option value = "6">Saturday</option>' +
        '<option value = "0">Sunday</option>' +
        '</select>');

    $('#' + id + '').append('<div id="remove-ex-' + id + '" class="add-exercise-style">' +
        '<div id="exercises-' + id + '">' +
        '</div>' +
        '<input type = "checkbox" id="click-'+id+'" class= "hide-it" />' +
        '<label for="click-'+id+'" id="add-exercise-' + id + '"><a>Add Exercise</a></label>' +
        '<div id="modal-item-' + id + '" class="exercises-modal-item">' +
        '<div id="items-'+id+'"></div>' +
        '<div class="close-button-wraper">' +
        '<label for="click-'+id+'" class="exercises-modal-close">Close</label>' +
        '</div >' +
        '</div>' +
        '<div class="overlay"></div>' +
        '</div >' +      
        '<hr />');


    $.ajax({

        url: '/Workout/GetExercises',
        data: { Id: id },
        dataType: "html",
        success: function (data) {
            $('#items-' + id + '').append(data);
        }
    });



    $('.days-dropdown').on('click', '#exercise-'+id+'', function () {
        var exercisesAddDiv = $(this).parents().eq(4).children().eq(0);
        var selectedExerciseName = $(this).parents().eq(0).children().eq(1).text();
        var selectedDay = $(this).parents().eq(5).children().eq(1).val();
        $.ajax({
            url: '/Workout/GetSingleExercise',
            type: "POST",
            data: { Name: selectedExerciseName,Day: selectedDay},
            dataType: "html",
            success: function (data) {
                exercisesAddDiv.append(data);
                $('.remove-exercise-button').on('click', function () {
                    $(this).parent().remove();
                });
            }
        });      
    });





    $('.add-day-style').css('display', 'none');
    $('.days-dropdown').append('<h4 id="add-day" class="add-day-style">Add day</h4>');


});


//$('#submit-workout').on('click', function () {
//    var data = $('.days-dropdown').children('form').toArray();
//    var result;
//    for (var i = 0; i < data.length; i++) {
//        result+= 
//    }
//    $.ajax({
//        url: '/Workout/Create',
//        method: 'post',
//        data: data
//    });
//});



$('.days-dropdown').on('click', '.remove-day-style', function () {
    var button_id = $(this).attr("id");



    $('#' + button_id).remove();
    $('#add-day').remove();

    if ($('.days-dropdown').has('select').length == 0) {
        id = 0;
    }
});

