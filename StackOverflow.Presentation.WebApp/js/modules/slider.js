$(function () {

	var slider = $(".question-contant-container");

	slider.children(".question-contant").hide();

	slider.children(".show-btn").click(function (item) {
		$(item.toElement).parent().prev().slideToggle();
	});

});