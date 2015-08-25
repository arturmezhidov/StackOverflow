define(["BaseService", "config"], function (BaseService, config) {

	var dataContext = { };

	dataContext.answers = new BaseService(config.ANSWER_URL);
	dataContext.likes = new BaseService(config.LIKE_URL);

	return dataContext;
});