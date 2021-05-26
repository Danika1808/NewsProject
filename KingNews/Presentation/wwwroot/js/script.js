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