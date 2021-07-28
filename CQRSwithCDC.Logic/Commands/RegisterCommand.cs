using CQRSwithCDC.Logic.Dtos;
using CQRSwithCDC.Logic.Handlers;
using MediatR;


namespace CQRSwithCDC.Logic.Commands
{
	public record RegisterCommand(RegisterDto RegisterDto) : IRequest<Result>;
}
