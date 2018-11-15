var openRegisterRight = document.querySelector('.register-button');
var openLoginRight = document.querySelector('.login-button');
var loginWrapper = document.querySelector('.login-wrapper');

openRegisterRight.addEventListener('click', function () {
    loginWrapper.classList.toggle('open');

});

openLoginRight.addEventListener('click', function () {
    loginWrapper.classList.toggle('open-l');

});

