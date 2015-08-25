define(["knockout", "config", "dataContext", "AnswersViewModel", "customBindings/identific"],
	function (ko, config, dataContext, AnswersViewModel) {

		function initialize() {

			var viewModel = new AnswersViewModel(dataContext);

			ko.applyBindings(viewModel);
		};

		return {
			initialize: initialize
		};
});