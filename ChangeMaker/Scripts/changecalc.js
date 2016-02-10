$(document).ready(function () {

    $("#change_result").hide();
    //$(".error_message").hide();


    $("#submit_purchase_calc").click(function (event) {

        event.preventDefault();
        var changeItems;
        var purchaseEntry;
        var tenderEntry;
        var notEnoughMoneyError = "";
        var purchFormatError = "";
        var tenderFormatError = "";
        var isError;
        isError === false;

        
        //$("#change-calc-form").validate({

        //    rules: {
        //        price_of_item: {
        //            required: true,
        //            number: true
        //        },
        //        amount_tendered: {
        //            required: true,
        //            number: true

        //        }
        //    },

            
        //submitHandler: function (form) {


        purchaseEntry = $("#price_of_item").val();
        tenderEntry = $("#amount_tendered").val();
        
        if (!purchaseEntry || (/[^0-9.]/.test(purchaseEntry))){
            purchFormatError = purchFormatError + "Please enter only numbers, with a period between dollars and cents.";
            $("#price_of_item").addClass("error-boxed");
            isError = true;
        }
        if (/\.[0-9]{3,}/.test(purchaseEntry)){
            purchFormatError = purchFormatError + "Please enter only two digits after the decimal point.";
            $("#price_of_item").addClass("error-boxed");
            isError = true;
        }
        if (/[^0-9.]/.test(tenderEntry)) {
            tenderFormatError = tenderFormatError + "Please enter only numbers, with a period between dollars and cents.";
            $("#amount_tendered").addClass("error-boxed");
            isError = true;
        }
        if (/\.[0-9]{3,}/.test(tenderEntry)) {
            tenderFormatError = tenderFormatError + "Please enter only two digits after the decimal point.";
            $("#amount_tendered").addClass("error-boxed");
            isError = true;
        }
        if (!isNaN(tenderEntry)&& !isNaN(purchaseEntry) && tenderEntry < purchaseEntry) {
            notEnoughMoneyError = "Must be at least the purchase price.";
            $("#amount_tendered").addClass("error-boxed");
            isError = true;
        }
        if (isError === true) {
            //$(".error_message").show();
            $("#purch_format_error").html(purchFormatError);
            $("#tender_format_error").html(tenderFormatError);
            $("#not_enough_error").html(notEnoughMoneyError);
        }

        else {

            //$(".error_message").hide();
            $(this).prop("disabled", true);
            $("#purch_format_error").text("");
            $("#tender_format_error").text("");
            $("#not_enough_error").text("");
            $("#amount_tendered").removeClass("error-boxed");
            $("#price_of_item").removeClass("error-boxed");

            $.ajax({
                type: 'POST',
                url: '/calcAJAX/calc',
                data: JSON.stringify({
                    purchasePriceString: $('#price_of_item').val(),
                    amountTenderedString: $('#amount_tendered').val(),
                    amountChangeString: $('#amount_change').val()
                }),
                headers:
                    {
                        'Accept': 'application/JSON',
                        'Content-Type': 'application/JSON'
                    },
                dataType: 'json'
            

                
            })
            .success(function (response) {

                $("#change_result").show();
                changeItems = response.ChangeItems;
                $("#submit_purchase_calc").prop("disabled", false);
                
           
                $("#change_total").text("$" + changeItems[8] + "." + changeItems[9]);

                $("#twenties").text(changeItems[0]);
                $("#tens").text(changeItems[1]);
                $("#fives").text(changeItems[2]);
                $("#ones").text(changeItems[3]);
                $("#quarters").text(changeItems[4]);
                $("#dimes").text(changeItems[5]);
                $("#nickels").text(changeItems[6]);
                $("#pennies").text(changeItems[7]);



            })
            .error(function(response){
            
                $("#submit_purchase_calc").prop("disabled", false);
                $("#change_result").hide();

            
            
            });
        }




            })
    })
//})




    

     //<p id="change_result" class="hidden">Change is: <span id="change_total"></span><br />
     //       <span id="twenties"></span> twenties, <span id="tens"></span> tens, <span id="fives"></span> fives, and <span id="ones"></span>ones.
     //       <br /> <span id="quarters"></span> quarters, <span id="dimes"></span> dimes, <span id="nickels"></span> nickels, and <span id="pennies"></span> pennies.</p>







    