using MediatR;
using ProductMS.Commons.Dtos.Request;

namespace ProductMS.Application.Commands
{
    public class ChangeProductStateCommand : IRequest<string>
    {
        public ChangeProductStateDto ChangeProductStateDto { get; }

        public ChangeProductStateCommand(ChangeProductStateDto changeProductStateDto)
        {
            ChangeProductStateDto = changeProductStateDto;
        }
    }
}
