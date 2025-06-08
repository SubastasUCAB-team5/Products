using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductMS.Commons.Dtos.Request;

namespace ProductMS.Application.Commands
{
    public class CreateProductCommand : IRequest<string>
    {
        public CreateProductDto CreateProductDto { get; set; }

        public CreateProductCommand(CreateProductDto dto)
        {
            CreateProductDto = dto;
        }
    }
}
