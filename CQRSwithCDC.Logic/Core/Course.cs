namespace CQRSwithCDC.Logic.Core
{
	public class Course : Entity
	{
		public string Name { get; protected set; }
		public byte Credits { get; protected set; }
		public Course(string name, byte credits)
		{
			Name = name;
			Credits = credits;
		}
	}
}
