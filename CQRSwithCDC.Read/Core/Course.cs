namespace CQRSwithCDC.Read.Core
{
	public class Course
	{
		public long Id { get; init; }
		public string Name { get; protected set; }
		public byte Credits { get; protected set; }
		public Course(long id, string name, byte credits)
		{
			Id = id;
			Name = name;
			Credits = credits;
		}
	}
}
