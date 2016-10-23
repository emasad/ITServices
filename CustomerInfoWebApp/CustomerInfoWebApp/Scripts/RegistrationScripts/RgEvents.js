var isSaveButton = false;
var isUpdate = false;
$(document).ready(function () {

    $(".new").click(function () {
        if (isSaveButton) {
            //if is update


            //new data inserted



            //$(this).val("Update");
            //$("#Delete").prop("disabled", false);
            //$("#Preview").prop("disabled", false);
            //if all valid then save 
            //if (confirm('Are you sure you want to submit?'))
            if ($("#formID").validationEngine('validate')) {
               // alert("Are you sure.");
                //save informationData
                if (isUpdate) {
                    confirm('Are you sure you want to update?');

                }

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
    
    
    //textbox focusout
    $("#Code").focusout(function () {
        //Get Selected User Id
        if (isSaveButton) {
            var code = $("#Code").val();
            var jsonData = { code: code };
            $.ajax({
                type: "POST",
                url: "../Home/GetUserByCode",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(jsonData),
                success: function (data) {
                    $("#Name").val(data.Name);
                    $("#Address").val(data.Address);
                    $("#Email").val(data.Email);
                    $("#PostCode").val(data.PostCode);
                    $("#Telephone").val(data.Telephone);
                    $("#ContactPersonName").val(data.ContactPersonName);
                    $("#ContactPersonPositionId").val(data.ContactPersonPositionId);
                    $("#RegionId").val(data.RegionId);
                    $("#CategoryId").val(data.CategoryId);
                    $(".new").val("Update");
                    isSaveButton = true;
                    isUpdate = true;
                    $("#Delete").prop("disabled", false);
                    $("#Preview").prop("disabled", false);

                },
                error: function (data) {
                    alert('request failed');
                }
            });

        } else {
            return;
        }
    });


    //delete action
    $("#Delete").click(function () {
        confirm('Are you sure you want to submit?');
        var code = $("#Code").val();
        var jsonData = { code: code };
        $.ajax({
            type: "POST",
            url: "../Home/DeleteByCode",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jsonData),
            success: function () {
                $("#Name").val("");
                $("#Address").val("");
                $("#Email").val("");
                $("#PostCode").val("");
                $("#Telephone").val("");
                $("#ContactPersonName").val("");
                $("#ContactPersonPositionId").val("");
                $("#RegionId").val("");
                $("#CategoryId").val("");
                $(".new").val("Save");
                isSaveButton = true;
                isUpdate = false;
                $("#Delete").prop("disabled", true);
                $("#Preview").prop("disabled", true);
            },
            error: function (data) {
                alert('request failed');
            }
        });
    });

    //Preview action
    $("#Preview").click(function () {
        $('#myModal').modal({
            show: 'false'
        });
    });


    //Filter User Data
    $("#Show").click(function () {
        //Get Selected User Id
        var rId = $("#rId").val();
        var catId = $("#catId").val();

        if ($("#selectCP").is(':checked')) {
            // Code in the case checkbox is checked.
            rId = null;
        }

        if ($("#selectC").is(':checked')) {
            // Code in the case checkbox is checked.
            catId = null;
        }


        var jsonData1 = { rId: rId, catId: catId };

        $.ajax({
            type: "POST",
            url: "../Home/GetUserFiltered",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jsonData1),
            success: function (data) {
                
                //$("#providersFormElementsTable").html("<tr><td>Nickname</td><td><input type='text' id='nickname' name='nickname'></td></tr><tr><td>CA Number</td><td><input type='text' id='account' name='account'></td></tr>");
                var tableMarkup = "<thead><tr><th>Code</th><th>Name</th></tr></thead>";
                tableMarkup += "<tbody>";
                $.each(data, function (i, val) {
                    tableMarkup += "<tr><td>" + val.Code + "</td><td>" + val.Name + "</td></tr>";
                });
                tableMarkup += "</tbody>";
                $("#tblOrderList").html(tableMarkup);
            },
            error: function (err) {
                var v = err;
            }
        });

    });
    //
    
});