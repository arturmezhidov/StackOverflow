using System;
using System.Collections;
using System.Collections.Generic;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Business.BusinessModels
{
	public class QuestionCollection : IEnumerable<Question>
	{
		private IList<Question> questions;

		public QuestionCollection()
		{
			questions = new List<Question>();
		}

		public void Add(Question question)
		{
			questions.Add(question);
		}

		public IEnumerator<Question> GetEnumerator()
		{
			return questions.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
