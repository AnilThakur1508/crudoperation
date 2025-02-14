
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Repository;
using DTO;
using Services.Data;

namespace Implementation.Implementation.Productservice
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var Products = await _productRepository.GetAllAsync();
            var entity = _mapper.Map<IEnumerable<ProductDto>>(Products);
            return (entity);
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var Product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(Product);
        }

        public async Task AddAsync(ProductDto Product)
        {
            var entity = _mapper.Map<Product>(Product);
            await _productRepository.AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(int id,ProductDto Product)
        {
            var entity = _mapper.Map<Product>(Product);
            entity.Id = id;
             
            await _productRepository.UpdateAsync(entity);
            return true;

        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}
