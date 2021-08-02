using System.Collections.Generic;

namespace CQRSwithCDC.Logic.Dtos
{
	public record CoursesToRegisterDto(long CourseId, byte Grade);
	public record RegisterDto(string Name, string Email, List<CoursesToRegisterDto> Courses);
}
