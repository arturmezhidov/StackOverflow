define(function() {

	function AnswerPostModel(questionId, description) {
		this.Description = description;
		this.QuestionId = questionId;
	}

	return AnswerPostModel;
});