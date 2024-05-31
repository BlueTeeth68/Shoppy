// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

(function ($) {
    "use strict";

    // Dropdown on mouse hover
    $(document).ready(function () {
        function toggleNavbarMethod() {
            if ($(window).width() > 992) {
                $('.navbar .dropdown').on('mouseover', function () {
                    $('.dropdown-toggle', this).trigger('click');
                }).on('mouseout', function () {
                    $('.dropdown-toggle', this).trigger('click').blur();
                });
            } else {
                $('.navbar .dropdown').off('mouseover').off('mouseout');
            }
        }

        toggleNavbarMethod();
        $(window).resize(toggleNavbarMethod);
    });


    // Back to top button
    $(window).scroll(function () {
        if ($(this).scrollTop() > 100) {
            $('.back-to-top').fadeIn('slow');
        } else {
            $('.back-to-top').fadeOut('slow');
        }
    });
    $('.back-to-top').click(function () {
        $('html, body').animate({scrollTop: 0}, 1500, 'easeInOutExpo');
        return false;
    });


    // Vendor carousel
    $('.vendor-carousel').owlCarousel({
        loop: true,
        margin: 29,
        nav: false,
        autoplay: true,
        smartSpeed: 1000,
        responsive: {
            0: {
                items: 2
            },
            576: {
                items: 3
            },
            768: {
                items: 4
            },
            992: {
                items: 5
            },
            1200: {
                items: 6
            }
        }
    });


    // Related carousel
    $('.related-carousel').owlCarousel({
        loop: true,
        margin: 29,
        nav: false,
        autoplay: true,
        smartSpeed: 1000,
        responsive: {
            0: {
                items: 1
            },
            576: {
                items: 2
            },
            768: {
                items: 3
            },
            992: {
                items: 4
            }
        }
    });


    // Product Quantity
    $('.quantity button').on('click', function () {
        const button = $(this);
        const oldValue = button.parent().parent().find('input').val();
        let newVal;
        if (button.hasClass('btn-plus')) {
            newVal = parseFloat(oldValue) + 1;
        } else {
            if (oldValue > 0) {
                newVal = parseFloat(oldValue) - 1;
            } else {
                newVal = 0;
            }
        }
        button.parent().parent().find('input').val(newVal);
    });

})(jQuery);


function addToCart(event, productId) {
    event.preventDefault();

    fetch('/Cart/AddToCart', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        body: 'productId=' + encodeURIComponent(productId)
    })
        .then(response => {
            return response.json();
        })
        .then(data => {
            if (data.success) {
                alert("Add product to cart successfully");
                $('.cart-total-item').html(data?.totalItem);
            } else {
                if (data?.redirectUrl != null) {
                    window.location.href = data.redirectUrl;
                } else {
                    alert('Error adding product to cart:\n ' + data.error);
                }
            }
        })
        .catch(error => {
            alert('Error adding product to cart:\n ' + error);
        });
}

function loadProductRatings(productId, page, size) {
    console.log("Call Ajax");
    debugger
    fetch('/Books/Rating?ProductId=' + productId + '&Page=' + page + '&Size=' + size)
        .then(response => {
            debugger
            if (response.ok) {
                return response.json();
            } else {
                throw new Error('Network response was not ok');
            }
        })
        .then(data => {
            debugger
            if (data.success) {
                renderProductRatings(data.data);
            } else {
                console.error(data.error);
            }
        })
        .catch(error => {
            debugger
            console.error('There has been a problem with your fetch operation:', error);
        });
}

async function renderProductRatings(data) {
    debugger;
    $('#product-ratings').empty();

    try {
        const response = await fetch('/Books/_RatingPartial', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (response.ok) {
            const fullView = await response.text();
            $('#product-ratings').html(fullView);
            $('#review').html(`Review (${data.totalRecords})`);
            $('#totalReview').html(`(${data.totalRecords} reviews)`);
        } else {
            console.error('Network response was not ok');
        }
    } catch (error) {
        console.error('There has been a problem with your fetch operation:', error);
    }
}


