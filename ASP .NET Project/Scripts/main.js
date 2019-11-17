$(document).ready(function () {
    // ReSharper disable once CoercedEqualsUsing
    $("#advanceCheckValue").val(0);

    $(`.search-option-select`).on(`change`, function () {
        const optionSelected = $(`option:selected`, this);
        const valueSelected = this.value;
        console.log(valueSelected);
        console.log(optionSelected);
        // ReSharper disable once CoercedEqualsUsing
        if (valueSelected == 0) {
            $(`.search-form`).attr(`action`, `/Customers`);
            // ReSharper disable once CoercedEqualsUsing
        } else if (valueSelected == 1) {
            $(`.search-form`).attr(`action`, `/Products`);
        }
    });
    var searchForm = document.getElementById("search-form");
    document.getElementById("search-form-submit").addEventListener("click", function () {
        searchForm.submit();
    });
    $("form").attr("novalidate", "novalidate");
    const parentRemove = document.querySelector(`#remove-html`);
    parentRemove.removeChild(document.querySelector(`.remove-inner`));
    parentRemove.removeAttribute(`id`);
    $("select.form-selectpicker").attr("data-style", "select-option-btn");
    $("#advanceCheck").click(function () {
        if ($(this).prop("checked") === true) {
            $("#advanceCheckValue").val(1);
        }
        else if ($(this).prop("checked") === false) {
            $("#advanceCheckValue").val(0);
        }
    });


    $("#clearFilterCustomer").click(function () {
        $("#advanceCheck").prop("checked", false);
        $("#advanceCheckValue").val(0);
        $("input[name = 'advanceFullname']").val(null);
        $("input[name = 'advanceEmail']").val(null);
        $("input[name = 'advanceAge']").val(null);
    });
    $("#clearFilterProduct").click(function () {
        $(".form-check-label-price").prop("checked", false);
        $(".formCheckPrice").val(0);
    });


    $("#AdvanceSearchFormCustomer").on("submit", function (e) {
        e.preventDefault();
        const advanceFullname = $("input[name = 'advanceFullname']").val();
        const advanceEmail = $("input[name = 'advanceEmail']").val();
        const advanceAge = $("input[name = 'advanceAge']").val();
        const advanceCheckValue = $("#advanceCheckValue").val();
        $.ajax({
            url: "/Customers/AjaxCustomers",
            type: "GET",
            data: {
                advanceFullname: advanceFullname,
                advanceEmail: advanceEmail,
                advanceAge: advanceAge,
                advanceCheckValue: advanceCheckValue
            },
            success: function(res) {
                $("#update-customer").html(res);
            },
            error: function(xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(thrownError);
            }
        });
    });

    $("#AdvanceSearchFormProduct").on("submit", function (e) {
        e.preventDefault();
        const advanceName = $("input[name = 'advanceName']").val();
        const advancePriceFrom = $("select[name = 'advancePriceFrom']").val();
        const advancePriceTo = $("select[name = 'advancePriceTo']").val();
        const advanceCheckValue = $("#advanceCheckValue").val();
        $.ajax({
            url: "/Products/AjaxProducts",
            type: "GET",
            data: {
                advanceName: advanceName,
                advancePriceFrom: advancePriceFrom,
                advancePriceTo: advancePriceTo,
                advanceCheckValue: advanceCheckValue
            },
            success: function(res) {
                $("#update-product").html(res);
            },
            error: function(xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(thrownError);
            }
        });
    });
});