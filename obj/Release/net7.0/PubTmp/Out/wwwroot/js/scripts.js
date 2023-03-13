$(document).ready(() => {
    $('.service-card').on('click', function () {
        $.ajax({
            method: "POST",
            url: `/services/detail/${$(this).attr('sid')}`,
            success: (html) => {
                $('#serviceModal .modal-content').html($(html));
            },
            error: (data) => {
                console.log(data)
            }
        })
    })
    $('input[name="Phone"]').inputmask("+7 (999) 999-99-99", { showMaskOnHover: false })
    $("form#orderCallForm").submit(function (e) {
        e.preventDefault();
        let phone = $(this).find('input[name="Phone"]');
        if (phone.val() == "" || phone.val().indexOf('_') > 0) {
            phone.addClass('is-invalid');
            return;
        }
        else {
            phone.removeClass('is-invalid')
        }
        $.ajax({
            url: "/api/ajax/request-call",
            type: "POST",
            //dataType: 'application/json',
            data: $(this).serialize(),
            success: function (data) {
                $('#orderCall .alert-danger').addClass('d-none');
                $('#orderCall .alert-success').removeClass('d-none');
                $('#orderCall [type="submit"]').attr('disabled', true);                
            },
            error: function (data) {
                $('#orderCall .alert-danger').removeClass('d-none');
                console.log(data);
            },
        })

        return false;
    });
    $('.images-container .owl-carousel').owlCarousel({
        items: 1,
        loop: true,
        autoplay: true,
        dots: true,
    });
})