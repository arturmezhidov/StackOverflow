define(["knockout", "models/Answer", "models/Like"],
	function (ko, Answer, Like) {

		function AnswersViewModel(dataContext) {

			var self = this;
			this.dataContext = dataContext;
			this.answers = ko.observableArray();
			this.newAnswer = ko.observable();
			this.isClosed = ko.observable(false);
			this.update = function (id) {
				self.questionId = id;
				self.answers.destroyAll();
				self
					.dataContext
					.answers
					.getById(id, function (response) {
						self.answers(response.map(function (item) {
							item.LikesCount = ko.observable(item.LikesCount);
							item.Liked = ko.observable(item.Liked);
							item.IsAccepted = ko.observable(item.IsAccepted);
							return ko.observable(item);
						}));
					});
			}
			this.add = function () {

				var text = self.newAnswer();

				if (!text) {
					return;
				}

				self
					.dataContext
					.answers
					.post(new Answer(self.questionId, text), function (response) {
						if (response) {
							response.LikesCount = ko.observable(response.LikesCount);
							response.Liked = ko.observable(response.Liked);
							response.IsAccepted = ko.observable(response.IsAccepted);
							self.answers.push(ko.observable(response));
						}
					});

				self.newAnswer("");
			}
			this.liking = function (answer) {
				self
					.dataContext
					.likes
					.post(new Like(answer.Id), function (response) {
						if (response.Success) {
							answer.LikesCount(response.LikesCount);
							answer.Liked(response.Liked);
						}
					});
			}
			this.accept = function (answer) {
				self
					.dataContext
					.answers
					.put(answer.Id, null, function (response) {
						self.answers().forEach(function(item) {
							item().IsAccepted(false);
						});
						answer.IsAccepted(response);
						self.isClosed(response);
					});
			}
		}

		return AnswersViewModel;
	});