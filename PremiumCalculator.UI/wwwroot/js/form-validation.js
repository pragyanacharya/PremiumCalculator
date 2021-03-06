$(function () {

    $('#Calculate').attr('autocomplete', 'off');

    // Initialize form validation on the CalculateForm.
    $("#Calculate").validate({
        errorClass: "badge badge-danger",
        errorElement: "span",
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            Name: "required",
            SumInsured: {
                required: true,
                number: true,
                min: 100,
                dollarsscents: true
            },
            DateOfBirth: "required",
            FactorRating: {
                required: {
                    depends: function (element) {
                        return $("#Occupation").val() == "";
                    }
                }
            }
        },
        // Specify validation error messages
        messages: {
            Name: "Please enter your Name",
            SumInsured: {
                required: "Enter Amount",
                number: "Decimal Numbers Only",
                min:"Minimum value should be $100"
            },
            DateOfBirth: "Please enter your Date Of Birth",
            FactorRating: "Please select an occupation"

        },
        highlight: function (element, errorClass) {
            $(element).removeClass(errorClass);
        }
    });

    $.validator.addMethod("dollarsscents", function (value, element) {
        return this.optional(element) || /^\d{0,4}(\.\d{0,2})?$/i.test(value);
    }, "Enter only 2 decimal places");


    $("#DateOfBirth").datepicker({
        autoclose: true,
        format: 'dd/mm/yyyy',
        endDate: '-1y -0m',
        startDate: '-100y -0m'
    });

    $("#DateOfBirth").on("keydown", function (e) {
        e.preventDefault();
    });

    $("#DateOfBirth").change(function (e) {
        var today = new Date();
        var dateParts = $(this).val().split("/");
        var birthDate = new Date(+dateParts[2], dateParts[1] - 1, +dateParts[0]);
        $("#DateOfBirth-error").hide();
        var age = today.getFullYear() - birthDate.getFullYear();
        var m = today.getMonth() - birthDate.getMonth();
        var ageValue = 0;
        if (age == NaN)
            ageValue = 0;
        if (age != 0) {
            if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
                age--;
            }
            ageValue = age;
        }

        return $('#Age').val(ageValue);
    });

    $('.txtOnly').bind('keypress', function (e) {
        var regex = new RegExp("^[a-zA-Z]+$");
        var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (regex.test(str)) {
            return true;
        }
        else {
            e.preventDefault();
            return false;
        }
    });

    $("#btnClear").click(function (ev) {
        ev.preventDefault();
        $(this).closest('form').find("input:text , select").each(function (i, v) {
            $(this).val("");
        });
        $("#result").hide();
    });

    $("#Occupation").on("change", function () {
        if ($('#Calculate').valid()) {
            $.ajax({
                url: '/home/indexpartial',
                type: 'POST',
                data: $('#Calculate').serialize(),
                contentType: 'application/x-www-form-urlencoded; charset=utf-8',
                success: function (data) {
                    $("#divResult").html(data);
                },
                error: function (error) {
                    alert(error);
                }
            });
        }
    });
});

$.validator.setDefaults({
    submitHandler: function () {
        form.submit();
        return false;
    }
});