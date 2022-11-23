// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('.open-btn').on('click', function () {
    $('.sidebar').addClass('active');
})

$('.close-btn').on('click', function () {
    $('.sidebar').removeClass('active');
})