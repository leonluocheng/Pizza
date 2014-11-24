﻿
$(document).ready(function () {
    document.getElementById("update-service-reset").onclick = updateServiceReset;
    document.getElementById("update-service-submit").onclick = updateServiceSubmit;

    function updateServiceReset() {
        event.preventDefault();
        $('#update-service-code').val("");
        $('#update-service-name').val("");
        $('#update-service-fee').val("");
    }

    function updateServiceSubmit() {
        event.preventDefault();

        $.ajax({
            type: 'PUT',
            crossDomain: true,
            url: 'http://localhost:49890/api/servicemanager/services/',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                ServiceName: $('#update-service-name').val(),
                ServiceCode: $('#update-service-code').val(),
                ServiceFee: $('#update-service-fee').val()
            }),
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#update-service-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#update-service-success').slideToggle(400).delay(3000).slideToggle(400);
                updateServiceReset();
            },
            error: function (error) {
                $('#update-service-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#update-service-loader').addClass("visibility-hidden");
            }
        });
    }
});