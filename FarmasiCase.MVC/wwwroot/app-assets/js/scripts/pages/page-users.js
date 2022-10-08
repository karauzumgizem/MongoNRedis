/*=========================================================================================
    File Name: page-users.js
    Description: Users page
    --------------------------------------------------------------------------------------
    Item Name: Modern Admin - Clean Bootstrap 4 Dashboard HTML Template
    Author: PIXINVENT
    Author URL: http://www.themeforest.net/user/pixinvent
==========================================================================================*/
$(document).ready(function () {

  // variable declaration
  var usersTable;
  var usersDataArray = [];
  // datatable initialization
  if ($("#users-list-datatable").length > 0) {
    usersTable = $("#users-list-datatable").DataTable({
      'columnDefs': [{
        "orderable": false,
        "targets": [4]
      }]
    });
  };
  // on click selected users data from table(page named page-users-list)
  // to store into local storage to get rendered on second page named page-users-view
  $(document).on("click", "#users-list-datatable tr", function () {
    $(this).find("td").each(function () {
      usersDataArray.push($(this).text().trim())
    })
    localStorage.setItem("Id", usersDataArray[0]);
    localStorage.setItem("CompanyName", usersDataArray[1]);
    localStorage.setItem("CompanyCode", usersDataArray[2]);
    //localStorage.setItem("usersVerified", usersDataArray[4]);
    //localStorage.setItem("usersRole", usersDataArray[5]);
    //localStorage.setItem("usersStatus", usersDataArray[6]);
  })
  // render stored local storage data on page named page-users-view
  if (localStorage.usersId !== undefined) {
      $(".users-view-id").html(localStorage.getItem("Id"));
      $(".users-view-username").html(localStorage.getItem("CompanyName"));
      $(".users-view-name").html(localStorage.getItem("CompanyCode"));
    //$(".users-view-verified").html(localStorage.getItem("usersVerified"));
    //$(".users-view-role").html(localStorage.getItem("usersRole"));
    //$(".users-view-status").html(localStorage.getItem("usersStatus"));
    // update badge color on status change

  }

});
