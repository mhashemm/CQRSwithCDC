using CQRSwithCDC.Logic.Dtos;
using CQRSwithCDC.Logic.Handlers;
using MediatR;

namespace CQRSwithCDC.Logic.Commands
{
	public record EditPersonalInfoCommand(PersonalInfoDto PersonalInfoDto) : IRequest<Result>;
}
