using EndangeredSpecies.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndangeredSpecies.Services
{
    public class CartService
    {
        private readonly EsDbContext _context;

        public CartService(EsDbContext context)
        {
            _context = context;
        }

        public int GetCartCount(System.Security.Claims.Claim user)
        {
            //var user = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            var user_id = user.Value;

            var c_count = _context.Cart.Where(c => c.UserId == user_id).Select(c => c).Count();

            return c_count;
        }
    }
}