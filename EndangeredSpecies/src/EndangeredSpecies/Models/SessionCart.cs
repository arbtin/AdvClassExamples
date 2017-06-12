using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using EndangeredSpecies.Infrastructure;

namespace EndangeredSpecies.Models
{
    public class SessionCart : CartList
    {
        public static CartList GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart cartlist = session?.GetJson<SessionCart>("CartList") ?? new SessionCart();
            cartlist.Session = session;
            return cartlist;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Species species)
        {
            base.AddItem(species);
            Session.SetJson("CartList", this);
        }

        public override void RemoveItem(Species species)
        {
            base.RemoveItem(species);
            Session.SetJson("CartList", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("CartList");
        }
    }
}