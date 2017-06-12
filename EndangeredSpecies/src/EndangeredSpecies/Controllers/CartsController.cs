using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EndangeredSpecies.Data;
using EndangeredSpecies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections;
using EndangeredSpecies.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using EndangeredSpecies.Infrastructure;

namespace EndangeredSpecies.Controllers
{
    public class CartsController : Controller
    {
        private readonly EsDbContext _context;

        public CartsController(EsDbContext context)
        {
            _context = context;    
        }

        private readonly UserManager<ApplicationUser> _userManager;
        private object cart;

        // GET: Carts
        [Authorize(Roles ="User")]
        public async Task<IActionResult> Index(string Type = "Cart")
        {
            var user = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            //.Where(c => c.Type == "email").Select(c => c.Value).SingleOrDefault(); 
            //            var user_x = _userManager.GetUserAsync(user);

            var user_id = user.Value;
            decimal AmountTotal = 0;
            IQueryable<CartDonationViewModel> cart_donateView;
            Type = Type.ToLower();
            ViewBag.Type = Type;

            if (Type == "donation")
            {
                if (String.IsNullOrEmpty(user_id))
                {
                    return RedirectToAction("Error");
                }
                else
                {
                    var cart_donateVM = _context.Donation.Select(c => new CartDonationViewModel()
                    {
                        Id = c.Id,
                        SpeciesId = c.SpeciesId,
                        Species = c.Species,
                        UserId = c.UserId,
                        Amount = c.Amount
                    }).Where(c => c.UserId == user_id);

                    AmountTotal = cart_donateVM.Sum(s => s.Amount);

                    cart_donateView = cart_donateVM.Select(s => s);
                }

                ViewBag.Title = "Donations";
            }
            else
            {
                if (String.IsNullOrEmpty(user_id))
                {
                    return RedirectToAction("Error");
                }
                else
                {
                    var cart_donateVM = _context.Cart.Select(c => new CartDonationViewModel()
                    {
                        Id = c.Id,
                        SpeciesId = c.SpeciesId,
                        Species =c.Species,
                        UserId = c.UserId,
                        Amount = c.Amount
                    }).Where(c => c.UserId == user_id);

                    AmountTotal = cart_donateVM.Sum(s => s.Amount);

                    cart_donateView = cart_donateVM.Select(s => s);
                }

                ViewBag.Title = "Cart";
            }

            ViewBag.AmountTotal = AmountTotal;
            return View(await cart_donateView.ToListAsync());
        }

        // Donate
        public async Task<IActionResult> Donate()
        {
            var user = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

            var user_id = user.Value;

            var cart = _context.Cart.Where(c => c.UserId == user_id);

            if (String.IsNullOrEmpty(user_id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in cart)
                {
                    Donation donation = new Donation();
                    donation.Amount = item.Amount;
                    donation.SpeciesId = item.SpeciesId;
                    donation.UserId = item.UserId;
                    _context.Add(donation);
                }

                await _context.SaveChangesAsync();
            }

            //await RemoveFromCartByUser(user_id);
            // var donate = _context.Donation.Where(c => c.UserId == user_id);
            return RedirectToAction("Index", "type=donation");
            // View(await donate.ToListAsync());
        }

        // GET: Carts/Create
        public IActionResult Create(int SpeciesId = 0)
        {
            if(SpeciesId <= 0)
            {
                //return RedirectToAction
            }

            ViewBag.SpeciesId = SpeciesId;

            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cart);
        }

        // GET: Carts/Delete/5
        [Route("Carts/Remove")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart.SingleOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }
            else
            {
                _context.Cart.Remove(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }

        public void RemoveFromCart(int id)
        {
            var cart = _context.Cart.SingleOrDefault(m => m.Id == id);
            _context.Cart.Remove(cart);
            _context.SaveChanges();

            return;
        }
        public async Task<IActionResult> RemoveFromCartByUser(string user_id)
        {
            var cart = _context.Cart.Where(c => c.UserId == user_id);

            if (cart == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // remove all items from cart
                foreach (var item in cart)
                {
                    RemoveFromCart(item.Id);
                }

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Type=Donation");
        }

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.Id == id);
        }

        [Authorize(Roles = "User")]
        public IActionResult AddToCart(int Id)
        {
            // User is not logged in
            if (!User.Identity.IsAuthenticated)
            {
                string return_url = "/Cart/AddToCart?Id=" + Id;
                return Content("<form action='login' id='cart_frm' method='post'><input type='hidden' name='ReturnUrl' value='" + return_url + "' /></form><script>document.getElementById('cart_frm').submit();</script>");
            }
            else
            {
                var user = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                //.Where(c => c.Type == "email").Select(c => c.Value).SingleOrDefault(); 
                //            var user_x = _userManager.GetUserAsync(user);

                var user_id = user.Value;

                // Add to cart for user
                Cart cart = new Models.Cart();

                cart.Amount = 100;
                cart.SpeciesId = Id;
                cart.UserId = user_id;


                //cart. = 
                _context.Add(cart);
                _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
        }


        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> EditAmount(int Id, decimal Amount)
        {
            if (CartExists(Id))
            {
                var cart = await _context.Cart.SingleOrDefaultAsync(m => m.Id == Id);
                cart.Amount = Amount;
                _context.Cart.Update(cart);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        
    }
}