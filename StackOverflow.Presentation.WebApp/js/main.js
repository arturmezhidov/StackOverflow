require.config({
	paths: {
		"knockout": "../../Scripts/knockout-3.3.0",
		"jquery": "../../Scripts/jquery-1.10.2.min",

		"BaseService": "../../js/data/BaseService",
		"dataContext": "../../js/data/dataContext",
		"AnswersViewModel": "../../js/viewModels/AnswersViewModel",
		"config": "../../js/config"
	}
});

require(["app"], function (app) {
	app.initialize();
});
