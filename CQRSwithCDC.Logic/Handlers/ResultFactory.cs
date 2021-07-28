namespace CQRSwithCDC.Logic.Handlers
{
	public static class ResultFactory
	{
		public static Result Fail(string error)
		{
			return new Result(true, error);
		}

		public static Result Ok()
		{
			return new Result(false, string.Empty);
		}
	}
}
