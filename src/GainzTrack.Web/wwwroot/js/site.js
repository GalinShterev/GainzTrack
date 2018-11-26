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
            var newLeft = ((1-now)*50) - 50 + '%';
            //3. increase opacity of previous_fs to 1 as it moves in
            opacity = 1 - now;
            current_fs.css({ 'left': left, 'display':'none' });
            previous_fs.css({ 'left':newLeft,'transform': 'scale(' + scale + ')', 'opacity': opacity,'position': 'relative' });
        },
        duration: 800,
        complete: function () {
            current_fs.hide();
            animating = false;
        },
        
        
    });
});


$('.days-dropdown').on('click', '#add-day', function () {
    var id = 1;
    $('.days-dropdown').append('<h4 id="'+id +'" class="remove-day-style">Remove</h4>');
    $('.days-dropdown').append('<select id="remove-'+id+'" class="select-dropdown" name="days">' +
        '<option value = "1">Monday</option>' +
        '<option value = "2">Tuesday</option>' +
        '<option value = "3">Wednesday</option>' +
        '<option value = "4">Thursday</option>' +
        '<option value = "5">Friday</option>' +
        '<option value = "6">Saturday</option>' +
        '<option value = "0">Sunday</option>' +
        '</select>');

    $('.days-dropdown').append('<div id="remove-ex-' + id +'" class="add-exercise-style">' +
        '<input type = "checkbox" id = "click" class= "hide-it" />' +
        '<label for="click"><a>Add Exercise</a></label>' +
        '<div class="modal-item">' +
        '<div class="exercises-modal">' +
        '<label class="open-button" for="click"><a>Close</a></label>' +
        '</div>' +
        '</div>' +
        '<div class="overlay"></div>' +
        '</div >' +
        '<hr id="hr-'+id+'"/>');

    $('.add-day-style').css('display', 'none');
    $('.days-dropdown').append('<h4 id="add-day" class="add-day-style">Add day</h4>');
});

$('.days-dropdown').on('click', '.remove-day-style', function () {
    var button_id = $(this).attr("id");

    $('#remove-' + button_id).remove();
    $('#remove-ex-' + button_id).remove();
    $('#hr-' + button_id).remove();
    $('#' + button_id).remove();
});