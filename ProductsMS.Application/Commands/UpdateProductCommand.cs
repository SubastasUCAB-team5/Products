using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductMS.Commons.Dtos.Request;


namespace ProductMS.Application.Commands
{
    public class UpdateProductCommand : IRequest<string>
    {
        public UpdateProductDto UpdateProductDto { get; set; }

        public UpdateProductCommand(UpdateProductDto dto)
        {
            UpdateProductDto = dto;
        }
    }
}
