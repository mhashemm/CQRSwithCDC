using CQRSwithCDC.Logic.Dtos;
using CQRSwithCDC.Logic.Handlers;
using MediatR;


namespace CQRSwithCDC.Logic.Commands
{
	public record UnregisterCommand(UnregisterDto UnregisterDto) : IRequest<Result>;
}
