using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Services.Interface
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task<CustomerDto> GetByIdAsync(int id);
        Task AddAsync(CustomerDto customer);
        Task<bool> UpdateAsync(int id, CustomerDto customer);
        Task DeleteAsync(int id);
    }
}
