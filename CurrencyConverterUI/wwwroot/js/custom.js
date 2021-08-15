$(document).ready(function () {
    $('#btnConvert').click(function () {
        const amount = $('#amount').val();
        const currentCurrency = $('#currentCurrency').val();
        const targetCurrency = $('#targetCurrency').val();

        if (amount.length == 0 || currentCurrency.length == 0 || targetCurrency.length == 0) {
            $('#validationMessage').removeClass('fade');
            return false;
        }
        else {
            $('#validationMessage').addClass('fade');
        }
    });
})