using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using DTO;
using Services.Interface;
namespace Services.Implementation
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
            var products = await _productRepository.GetAllAsync();
            var maps = _mapper.Map<IEnumerable<ProductDto>>(products);


            return (maps);
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task AddAsync(ProductDto product)
        {
            var entity = _mapper.Map<Product>(product);
            await _productRepository.AddAsync(entity);


        }

        public async Task<bool> UpdateAsync(int id, ProductDto product)
        {
            var products = _mapper.Map<Product>(product);
            products.Id = id;
            try { await _productRepository.UpdateAsync(products); } catch (Exception ex) { return false; }

            return true;
        }


        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }

}

