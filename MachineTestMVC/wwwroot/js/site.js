﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function() {
    var PlaceHolderElement = $('#PlaceHolderHere');
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        var decodedurl = decodeURIComponent(url);
        $.get(decodedurl).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        })
    })
    PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {
        /*event.preventDefault();*/
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var url = "/Home/Edit/" + actionUrl;
        var sendData = form.serialize();
        $.post(url, sendData).done(function (data) {
            PlaceHolderElement.find('.modal').modal('hide');
            location.reload();
        })
    })
})
