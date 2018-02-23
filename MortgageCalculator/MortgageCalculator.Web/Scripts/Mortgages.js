$(document).ready(function () {
    $('input[name="MortageRate"]:radio').on('change', function (e) {
            $.ajax({
                url: "/Mortgage/LoanRepaymentDetails?intertestRate=" + $(this).val(), success: function (result) {
                    $("#calculateinerest").html(result);
                }
            });          
        });
     $('#calculate').click(function () {
            var intertestRate = $("Input[name='MortageRate']:checked").val();
            if (intertestRate)
            {
                $.ajax({
                    url: "/Mortgage/LoanRepaymentDetails?intertestRate=" + intertestRate, success: function (result) {
                        $("#calculateinerest").html(result);
                    }
                });
            }
            else 
                return;
        });
     $('#formsubmit').click(function (e) {
                        e.preventDefault();
            var loan_amount =$('.loan_amount ').val(),
                 no_0fyear = $('.no_0fyear').val();
            if ((loan_amount == "0" || loan_amount== 'undefind') || (no_0fyear == "0" || no_0fyear== 'undefind')) {
                alert("Load amount and no of year fields to be entered");
                return false;
            }
            $.ajax({
                url: "/Mortgage/GetLoanRepaymentDetails",
                data: $("#loanForm").serialize(),
                type: 'post',
                success: function (result) {
                    $("#calculateinerest").html(result);
                }
            });

        });
    });