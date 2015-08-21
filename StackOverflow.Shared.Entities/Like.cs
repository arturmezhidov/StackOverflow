namespace StackOverflow.Shared.Entities
{
	public class Like
	{
		public int Id { get; set; }

		public int AnswerId { get; set; }
		public virtual Answer Answer { get; set; }

		public string UserId { get; set; }
		public virtual User User { get; set; }
	}
}
