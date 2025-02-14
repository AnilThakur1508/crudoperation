using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Place { get; set; }
        public int Price { get; set; }
    }
    public class ProductResponseDto: ProductDto
    {
        public int Id { get; set; }
    }
}
