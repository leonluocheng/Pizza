﻿
$(document).ready(function () {
    document.getElementById("login-btn-reset").onclick = resetLoginBox;
    document.getElementById("login-btn-submit").onclick = submitLoginBox;

    function resetLoginBox() {
        event.preventDefault();
        $('#login-role').val(1);
        $('#login-id').val("");
    }

    function submitLoginBox() { //Temporary. Link to actual function later
        event.preventDefault();
        var role = parseInt($('#login-role').val());

        if ($('#login-id').val() != "") {
            if (role == 3) getAdmin();
            else if (role == 2) getManager();
            else getProvider();
        } else {
            $('#login-error').slideToggle(400).delay(3000).slideToggle(400);
        }

        //if ($('#login-id').val() != "") {
        //    if (role == 3) window.location = login.adminPath;
        //    else if (role == 2) window.location = login.managerPath;
        //    else window.location = login.providerPath;
        //} else {
        //    $('#login-error').slideToggle(400).delay(3000).slideToggle(400);
        //}
    }

    function getAdmin() {
        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/account/get/admin' + '/' + $('#login-id').val(),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#login-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                window.location = login.adminPath + "?username=" + data.Name.toString() + "&id=" + data.ID.toString();
            },
            error: function (error) {
                $('#login-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#login-loader').addClass("visibility-hidden");
            }
        });
    }

    function getManager() {
        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/account/get/manager' + '/' + $('#login-id').val(),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#login-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                window.location = login.managerPath + "?username=" + data.Name.toString() + "&id=" + data.ID.toString();
            },
            error: function (error) {
                $('#login-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#login-loader').addClass("visibility-hidden");
            }
        });
    }

    function getProvider() {
        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/account/get/provider' + '/' + $('#login-id').val(),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#login-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                window.location = login.providerPath + "?username=" + data.Name.toString() + "&id=" + data.ID.toString();
            },
            error: function (error) {
                $('#login-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#login-loader').addClass("visibility-hidden");
            }
        });
    }
});