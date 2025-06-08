using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductMS.Domain.Entities;

namespace ProductMS.Commons.Dtos.Request
{
    public class ChangeProductStateDto
    {
        public Guid ProductId { get; set; }
        public ProductState NewState { get; set; }
    }
}
