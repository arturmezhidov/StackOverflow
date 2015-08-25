define(["knockout", "models/AnswerPostModel", "models/LikePostModel"],
	function (ko, AnswerPostModel, LikePostModel) {

		function AnswersViewModel(dataContext) {

			var self = this;
			self.dataContext = dataContext;
			self.answers = ko.observableArray();
			self.newAnswer = ko.observable();
			self.update = function (id) {
				self.questionId = id;
				self.answers.destroyAll();
				self
					.dataContext
					.answers
					.getById(id, function (response) {
						self.answers(response.map(function (item) {
							item.LikesCount = ko.observable(item.LikesCount);
							item.Liked = ko.observable(item.Liked);
							return ko.observable(item);
						}));
					});
			}
			self.add = function () {

				var text = self.newAnswer();

				if (!text) {
					return;
				}

				self
					.dataContext
					.answers
					.post(new AnswerPostModel(self.questionId, text), function (response) {
						if (response) {
							response.LikesCount = ko.observable(response.LikesCount);
							response.Liked = ko.observable(response.Liked);
							self.answers.push(ko.observable(response));
						}
					});

				self.newAnswer("");
			}
			self.liking = function (answer) {
				self
					.dataContext
					.likes
					.post(new LikePostModel(answer.Id), function (response) {
						if (response.Success) {
							answer.LikesCount(response.LikesCount);
							answer.Liked(response.Liked);
						}
					});
			}
		}

		return AnswersViewModel;
	});