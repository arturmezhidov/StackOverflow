﻿using StackOverflow.Data.DataAccess.DataContexts;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Data.DataAccess.Repositories
{
	public class LikeRepository : BaseRepository<Like>
	{
		public LikeRepository(DataContext context)
			: base(context, context.Likes)
		{
		}
	}
}
