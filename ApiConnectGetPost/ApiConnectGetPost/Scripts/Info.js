$(document).ready(function () {
    loadData();
});
function loadData() {
    $.ajax({
        url: "/Home/View",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.Id + '</td>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.Address + '</td>';
                html += '<td>' + item.Mobile + '</td>';
                html += '<td>' + item.Email + '</td>';
                html += '<td><a href="#" onclick="Update(' + item.Id + ')">Update</a> | <a href="#" onclick="Delete(' + item.Id + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Add() {
    //debugger;
   // var res = validate();
    //if (res == false) {
    //    return false;
    //}
    var IObj = {
        Id: $('#Id').val(),
        Name: $('#Name').val(),
        Address: $('#Address').val(),
        Mobile: $('#Mobile').val(),
        Email: $('#Email').val()
    };
    $.ajax({
        url: "/Home/Create",
        data: JSON.stringify(IObj),
        type: "POST",
       contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            //debugger;
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Update() {
   // var res = validate();
    //if (res == false) {
     //   return false;
    //}
    var empObj = {
        Id: $('#Id').val(),
        Name: $('#Name').val(),
        Address: $('#Address').val(),
        Mobile: $('#Mobile').val(),
        Email: $('#Email').val()
    };
    $('#UpdateModal').modal('show');
    $.ajax({
        url: "/Home/Update",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#UpdateModal').modal('hide');
            $('#EmployeeID').val("");
            $('#Name').val("");
            $('#Address').val("");
            $('#Mobile').val("");
            $('#Email').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Delete(Id) {
    debugger;
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Home/Delete/",
            type: "POST",
            data: JSON.stringify({ Id }),
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                $('#btnDelete').show();
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
