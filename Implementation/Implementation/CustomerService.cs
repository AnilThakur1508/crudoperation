using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Repository;
using DTO;
using Services.Data;
using Microsoft.EntityFrameworkCore;

namespace Implementation.Implementation
{

        public class CustomerService : ICustomerService
        {
            private readonly IRepository<Customer> _customerRepository;
            private readonly IMapper _mapper;

        public CustomerService(IRepository<Customer> customerRepository, IMapper mapper)
            {
                _customerRepository = customerRepository;
                   _mapper = mapper;
            }

            public async Task<IEnumerable<CustomerDto>> GetAllAsync()
            {
            var customers = await _customerRepository.GetAllAsync();
            var maps = _mapper.Map<IEnumerable<CustomerDto>>(customers);


            return (maps);
        }

            public async Task<CustomerDto> GetByIdAsync(int id)
            {
                var customer  = await _customerRepository.GetByIdAsync(id);
                return _mapper.Map<CustomerDto>(customer);
        }

        public async Task AddAsync(CustomerDto customer)
        {
            var entity = _mapper.Map<Customer>(customer);
            await _customerRepository.AddAsync(entity);

            
        }

        public async Task<bool> UpdateAsync(int id, CustomerDto customer)
        {
            var Customers = _mapper.Map<Customer>(customer);
            Customers.Id = id;
            try { await _customerRepository.UpdateAsync(Customers); } catch (Exception ex) { return false; }

            return true;
        }
        

        public async Task DeleteAsync(int id)
            {
                await _customerRepository.DeleteAsync(id);
            }
        }

}

