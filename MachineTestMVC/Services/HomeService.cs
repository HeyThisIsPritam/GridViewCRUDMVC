
using MachineTestMVC.Data;
using MachineTestMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineTest.Services
{
    public class HomeService : IHomeService
    {
        private readonly MachineTestMVCContext _context;
        public HomeService(MachineTestMVCContext mvccontext)
        {
            _context = mvccontext;
        }
        public async Task AddAsync(UserDetail user)   
        {
            int H = Int32.Parse(DateTime.Now.ToString("HH"));
            int M = Int32.Parse(DateTime.Now.ToString("mm"));
            int S = Int32.Parse(DateTime.Now.ToString("ss")); 
            user.Time = new TimeSpan(H, M, S );
            user.IsActive = true;
            user.Status = "Active";
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        

        public bool Delete(int Id)
        {
            var st = false;
            var result = _context.UserDetails.Where(x => x.Id == Id).SingleOrDefault();
            if (result != null)
            {
                result.IsActive = false;
                result.Status = "Deactive";
                _context.SaveChanges();
                st = true;
            }
            return st;
            
        }
        public bool DeleteAll()
        {
            var st = false;
            IEnumerable<UserDetail> user = _context.UserDetails.Where(x => x.IsActive == true);
            
            
            if (user != null)
            {
                foreach (var item in user)
                {
                    item.IsActive = false;
                   item.Status = "Deactive";
                }
                _context.SaveChanges();
                st = true;
            }
            return st;

        }
        public IEnumerable<UserDetail> ShowAll()
        {
            var st = false;
            IEnumerable<UserDetail> user = _context.UserDetails.ToList();


            return user;

        }

        public IEnumerable<UserDetail> GetAllAsync()
        {
            var userAll = _context.UserDetails.Where(x => x.IsActive==true).ToList();
            return userAll;
        }

        
    }
}
