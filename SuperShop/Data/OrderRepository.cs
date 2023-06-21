﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperShop.Data.Entities;
using SuperShop.Helpers;

namespace SuperShop.Data
{
    public class OrderRepository : GenericReposotory<Order>, IOrderRepository 
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public OrderRepository(DataContext context, IUserHelper userHelper) : base(context) 
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task<IQueryable<OrderDetailTemp>> GetDetailTempsAsync(string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);

            if (user == null)
            {
                return null;
            }

            return _context.OrderDetailsTemp
                .Include(p => p.Product)
                .Where(o => o.User == user)
                .OrderBy(o => o.Product.Name);
        }

        public async Task<IQueryable<Order>> GetOrderAsync(string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);

            if(user == null)
            {
                return null;
            }

            if (await _userHelper.IsUserInRoleAsync(user, "Admin"))
            {
                return _context.Orders
                    .Include(o => o.Items)
                    .ThenInclude(p => p.Product)
                    .OrderByDescending(o => o.OrderDate);
            }

            return _context.Orders
                .Include(o => o.Items)
                .ThenInclude(p => p.Product)
                .Where(o => o.User == user)
                .OrderByDescending (o => o.OrderDate);  
        }
    }
}
