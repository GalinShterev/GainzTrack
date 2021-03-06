﻿function closeModal() {
    $(".mask").removeClass("active");
    $('.custom-modal-content').html("");
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

$('#control-button-approve').on('click', function () {
    var achievementUserId = $(this).parent().attr('id');

    $.ajax({
        url: '/Achievements/ApproveAchievement',
        dataType: "html",
        data: { achievementUserId: achievementUserId },
        success: function (data) {
            closeModal();
        }
    });
    closeModal();
});

$('#control-button-deny').on('click', function () {
    var achievementUserId = $(this).parent().attr('id');

    $.ajax({
        url: '/Achievements/DenyAchievement',
        dataType: "html",
        data: { achievementUserId: achievementUserId },
        success: function (data) {
            location.reload();
        }
    });
});