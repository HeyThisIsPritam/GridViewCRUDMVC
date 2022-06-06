using MachineTestMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineTest.Services
{
    public interface IHomeService
    {
        IEnumerable<UserDetail> GetAllAsync();
        Task AddAsync(UserDetail user);
        bool Delete(int id);
        bool DeleteAll();
        IEnumerable<UserDetail> ShowAll();
    }
}
