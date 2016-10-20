﻿var isSaveButton = false;
var isUpdate = false;
$(document).ready(function () {

    $(".new").click(function () {
        if (isSaveButton) {
            //$(this).val("Update");
            //$("#Delete").prop("disabled", false);
            //$("#Preview").prop("disabled", false);

            //if all valid then save 
            //if (confirm('Are you sure you want to submit?'))
            if ($("#formID").validationEngine('validate')) {
               // alert("Are you sure.");



                //save informationData
                var code = $('#Code').val();
                var name = $('#Name').val();
                var address = $('#Address').val();
                var postCode = $('#PostCode').val();
                var telephone = $('#Telephone').val();
                var email = $('#Email').val();
                var contactPersonName = $('#ContactPersonName').val();
                var contactPersonPositionId = $('#ContactPersonPositionId').val();
                var regionId = $('#RegionId').val();
                var categoryId = $('#CategoryId').val();
                var jsonData = {
                    code: code, name: name, address: address, postCode:postCode, telephone: telephone, email: email, contactPersonName: contactPersonName,
                    contactPersonPositionId: contactPersonPositionId, regionId: regionId, categoryId: categoryId};

                if (code != "" && name != "" & address != "" && postCode != "" && telephone != "" & email != "" && contactPersonName != "" && contactPersonPositionId != "" & regionId != "" && categoryId != "") {
                    $.ajax({
                        type: "POST",
                        url: "../Home/SaveUser",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(jsonData),
                        success: function () {
                            alert("Save succed.");
                            var url = $("#RedirectTo").val();
                            location.href = url;
                        },
                        
                        error: function (data) {
                            alert('request failed');
                        }
                    });
                }
                else {
                    alert('Enter all informations');
                }
            }
            return;
        }
        $(this).val("Save");
        $(this).attr("id", "Save");
        isSaveButton = true;
        $("#Delete").prop("disabled", true);
        $("#Preview").prop("disabled", true);
    });
    
    $("#Code").change(function () {
        //Get Selected User Id
        var id = $("#FoodNameId").val();
        var jsonData1 = { id: id };

        $.ajax({
            type: "POST",
            url: "../Order/GetFoodById",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jsonData1),
            success: function (data) {
                $("#UnitPrice").val(data.UnitPrice);
            }
        });

    });
    

});



