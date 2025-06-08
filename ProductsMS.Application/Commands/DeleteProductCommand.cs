using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductMS.Commons.Dtos.Request;

namespace ProductMS.Application.Commands
{
    public class DeleteProductCommand : IRequest<string>
    {
        public DeleteProductDto DeleteProductDto { get; set; }

        public DeleteProductCommand(DeleteProductDto dto)
        {
            DeleteProductDto = dto;
        }
    }
}
