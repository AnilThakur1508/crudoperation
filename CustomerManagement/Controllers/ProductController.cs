using AutoMapper;
using DataAccessLayer.Repository;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Services.Data;
using Implementation.Implementation.Productservice;


namespace CustomerManagement.Controllers
{
   
        [ApiController]
        [Route("api/[controller]")]
        public class ProductController : ControllerBase
        {
            private readonly IProductService _productServices;
            private readonly IMapper _mapper;

            public ProductController(IProductService productServices, IMapper mapper)
            {
            _productServices = productServices;
                _mapper = mapper;
            }

            [HttpGet("GetAll")]
            public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
            {
                var products = await _productServices.GetAllAsync();
                return Ok(products);
            }

            [HttpGet("GetById/{id}")]
            public async Task<ActionResult<ProductDto>> GetById(int id)
            {
                var product = await _productServices.GetByIdAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                _mapper.Map<ProductDto>(product);
                return Ok(product);
            }

            [HttpPost("Add")]
            public async Task<ActionResult> AddAsync(ProductDto productDto)
            {
              
                try { await _productServices.AddAsync(productDto); } catch (Exception ex) { return BadRequest(ex.Message); }

                return Ok("Product is Created");
            }

            [HttpPut("Update")]
            public async Task<ActionResult> UpdateAsync(int id, ProductDto productDto)
            {
            try { await _productServices.UpdateAsync(id,productDto); } catch (Exception ex) { return BadRequest(ex.Message); }

                return Ok("Product is Updated");
            }

            [HttpDelete("Delete/{id}")]
            public async Task<ActionResult> DeleteAsync(int id)
            {
                await _productServices.DeleteAsync(id);
                return Ok("Product is Deleted");
            }
        }
}

