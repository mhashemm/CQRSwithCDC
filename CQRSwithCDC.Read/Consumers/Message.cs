namespace CQRSwithCDC.Read.Consumers
{
	public class Message<T> where T : class
	{
		public T before { get; set; }
		public T after { get; set; }
		public char op { get; set; }
		public long ts_ms { get; set; }
		public Sourse source { get; set; }
	}
	public class Sourse
	{
		public string table { get; set; }
	}
}
