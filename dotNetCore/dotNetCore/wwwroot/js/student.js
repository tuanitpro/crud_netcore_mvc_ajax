/* FileName: student.js
Project Name: AjaxDemo
Date Created: 5/10/2015 8:49:08 AM
Description: Auto-generated
Version: 1.0.0.0
Author:	Lê Thanh Tuấn - Khoa CNTT
Author Email: tuanitpro@gmail.com
Author Mobile: 0976060432
Author URI: http://tuanitpro.com
License: 

*/


$(document).ready(function () {
    _getAll();
});

function _getAll() {
    $.ajax({
        url: "/api/student",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.StudentId + '</td>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.Status + '</td>';
                html += '<td><a href="#" onclick="return _getById(' + item.StudentId + ')">Edit</a> | <a href="#" onclick="return _delete(' + item.StudentId + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('#list tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

    $('#btnUpdate').hide();
    $('#btnAdd').show();
    return false;
}
function _getById(id) {
    $.ajax({
        url: '/api/student/' + id,
        // data: JSON.stringify(dto),
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#StudentId').val(result.StudentId);
            $('#Name').val(result.Name);
            $('#Status').val(result.Status);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
function _add() {
    var obj = {
        StudentId: $('#StudentId').val(),
        Name: $('#Name').val(),
        Status: $('#Status').val(),
    }
    $.ajax({
        url: '/api/student',
        data: JSON.stringify(obj),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        statusCode: {
            200: function () {
                _getAll();
                $('#myModal').modal('hide');
            }
        }
    });
}
function _edit() {
    var obj = {
        StudentId: $('#StudentId').val(),
        Name: $('#Name').val(),
        Status: $('#Status').val(),
    }
    $.ajax({
        url: '/api/student',
        data: JSON.stringify(obj),
        type: "PUT",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        statusCode: {
            200: function () {
                _getAll();
                $('#myModal').modal('hide');
            }
        }        
    });
}
function _delete(id) {
    var cf = confirm('Are you sure want to permanently delete this row?');
    if (cf) {
        $.ajax({
            url: '/api/student/' + id,
            type: "DELETE",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            statusCode: {
                200: function () {
                    _getAll();                    
                }
            }
            
        });
    }
}