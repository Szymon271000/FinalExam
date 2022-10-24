// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function() {
    $("#lawEnforcementIdInput").on("input", function () {
        var searchValue = $(this).val()
        var table = $("#crimeTable")
        table.find("td[name='lawEnforcementId']").each((index, td) => {
            var tr = $(td).closest("tr")
            if ($(td).html().includes(searchValue)) {
                tr.show()
            }
            else {
                tr.hide()
            }
        });
    });
});