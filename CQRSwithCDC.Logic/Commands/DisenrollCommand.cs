using CQRSwithCDC.Logic.Dtos;
using CQRSwithCDC.Logic.Handlers;
using MediatR;

namespace CQRSwithCDC.Logic.Commands
{
	public record DisenrollCommand(DisenrollDto DisenrollDto) : IRequest<Result>;
}
