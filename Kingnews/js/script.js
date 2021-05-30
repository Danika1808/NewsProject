$(document).ready(function () {
    $(".popular-news").on("click", ".nav-item", function() {
        $(".popular-news .nav-item").removeClass("active");
        $(".popular-news .nav-link").removeClass("active");
        $(".popular-news .tab-form").removeClass("active-form");
        
        console.log($(this).index());
        
        $(this).addClass("active");
        $(".popular-news .nav-link").eq($(this).index()).addClass("active");
        $(".popular-news .tab-form").eq($(this).index()).addClass("active-form");
    });
});
 
$(document).ready(function() {
    $("#contact-name").on("focus", function () {
        $("#contact-name-label").addClass("focus");
        $(this).removeClass("invalid");
    });
    
});

$(document).ready(function() {
    $("#contact-name").blur(function() {
        if(!$(this).val()) {
            $("#contact-name-label").removeClass("focus");
            $(this).addClass("invalid");
        } else {
            $(this).removeClass("invalid");
        }
    });
});

$(document).ready(function() {
    $("#phone").on("focus", function () {
        $("#phone-label").addClass("focus");
        $(this).removeClass("invalid");
    });

});

$(document).ready(function() {
    $("#phone").blur(function() {
        if(!$(this).val()) {
            $("#phone-label").removeClass("focus");
            $(this).addClass("invalid");
        } else {
            $(this).removeClass("invalid");
        }
    });
});

$(document).ready(function() {
    $("#contact-lastname").on("focus", function () {
        $("#contact-lastname-label").addClass("focus");
        $(this).removeClass("invalid");
    });

});

$(document).ready(function() {
    $("#contact-lastname").blur(function() {
        if(!$(this).val()) {
            $("#contact-lastname-label").removeClass("focus");
            $(this).addClass("invalid");
        } else {
            $(this).removeClass("invalid");
        }
    });
});

$(document).ready(function() {
    $("#your-password").on("focus", function () {
        $("#your-password-label").addClass("focus");
        $(this).removeClass("invalid");
    });

});

$(document).ready(function() {
    $("#your-password").blur(function() {
        if(!$(this).val()) {
            $("#your-password-label").removeClass("focus");
            $(this).addClass("invalid");
        } else {
            $(this).removeClass("invalid");
        }
    });
});

$(document).ready(function() {
    $("#your-password-confirm").on("focus", function () {
        $("#your-password-confirm-label").addClass("focus");
        $(this).removeClass("invalid");
    });

});

$(document).ready(function() {
    $("#your-password-confirm").blur(function() {
        if(!$(this).val()) {
            $("#your-password-confirm-label").removeClass("focus");
            $(this).addClass("invalid");
        } else {
            $(this).removeClass("invalid");
        }
    });
});

$(document).ready(function() {
    $("#contact-email").on("focus", function () {
        $("#contact-email-label").addClass("focus");
        $(this).removeClass("invalid");
    });

});

$(document).ready(function() {
    $("#contact-email").blur(function() {
        if(!$(this).val()) {
            $("#contact-email-label").removeClass("focus");
            $(this).addClass("invalid");
        } else {
            $(this).removeClass("invalid");
        }
    });
});

$(document).ready(function() {
    $("#your-website").on("focus", function () {
        $("#your-website-label").addClass("focus");
        $(this).removeClass("invalid");
    });

});

$(document).ready(function() {
    $("#your-website").blur(function() {
        if(!$(this).val()) {
            $("#your-website-label").removeClass("focus");
            $(this).addClass("invalid");
        } else {
            $(this).removeClass("invalid");
        }
    });
});

$(document).ready(function() {
    $("#message").on("focus", function () {
        $("#message-label").addClass("focus");
        $(this).removeClass("invalid");
    });

});

$(document).ready(function() {
    $("#message").blur(function() {
        if(!$(this).val()) {
            $("#message-label").removeClass("focus");
            $(this).addClass("invalid");
        } else {
            $(this).removeClass("invalid");
        }
    });
});



$(document).ready(function () {
   $(".carousel-control-prev").click(function () {
       $("#carousel").carousel('prev');
   });
    $(".carousel-control-next").click(function () {
        $("#carousel").carousel('next');
    });
});

