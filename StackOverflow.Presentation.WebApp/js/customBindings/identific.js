define(["knockout"], function (ko) {
	ko.bindingHandlers.identific = {
		init: function (element, valueAccessor, allBindings, viewModel) {
			var id = ko.unwrap(valueAccessor());
			viewModel.update(id);

		},
		update: function (element, valueAccessor, allBindings, viewModel) {
			var id = ko.unwrap(valueAccessor());
			viewModel.update(id);
		}
	};
});