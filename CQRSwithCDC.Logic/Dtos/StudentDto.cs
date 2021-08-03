namespace CQRSwithCDC.Logic.Dtos
{
	public record StudentDto(
		long Id,
		string Name,
		string Email,
		byte NumberOfEnrollments,
		string FirstCourseName,
		byte FirstCourseCredits,
		byte FirstCourseGrade,
		string SecondCourseName,
		byte SecondCourseCredits,
		byte SecondCourseGrade);
}
