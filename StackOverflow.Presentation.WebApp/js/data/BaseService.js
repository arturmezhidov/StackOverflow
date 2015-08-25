define(function () {

	function BaseService(url) {

		var self = this;
		this.baseUrl = url;
		this.getAll = getAll;
		this.getById = getById;
		this.post = post;

		function getAll(callback) {

			$.ajax({
				url: self.baseUrl,
				dataType: "json",
				async: false,
				success: callback
			});
		}

		function getById(id, callback) {

			var url = self.baseUrl + '/' + id;

			$.ajax({
				url: url,
				dataType: "json",
				async: false,
				success: callback
			});
		}

		function post(data, callback) {

			$.ajax({
				url: self.baseUrl,
				type: 'POST',
				data: JSON.stringify(data),
				contentType: "application/json;charset=utf-8",
				async: false,
				success: callback
			});
		}

	}

	return BaseService;
});