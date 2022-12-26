using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MitasovASP.Data;
using MitasovASP.Data.Models;

namespace MitasovASP.Controllers
{
    public class CatalogController : Controller
    {

        private AppDBContent db;
        public CatalogController(AppDBContent context)
        {
            this.db = context;
        }
        public async Task<IActionResult> Products()
        {
            return View(await db.Brick.ToListAsync());
        }

        public IActionResult Cart()
        {
            Cart cart = new Cart();
            if (HttpContext.Session.Keys.Contains("Cart")) cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart"));
            return View(cart);
        }

        public IActionResult Pay()
        {
            return View();
        }

        public IActionResult AddToCart()
        {
            int ID = Convert.ToInt32(Request.Query["ID"]);
            Cart cart = new Cart();
            if (HttpContext.Session.Keys.Contains("Cart")) cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart"));
            cart.CartLines.Add(db.Brick.Find(ID));
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<Cart>(cart));
            return Redirect("/");
        }

        public IActionResult RemoveFromCart()
        {
            int number = Convert.ToInt32(Request.Query["Number"]);
            Cart cart = new Cart();
            if (HttpContext.Session.Keys.Contains("Cart")) cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart"));
            cart.CartLines.RemoveAt(number);
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<Cart>(cart));
            return Redirect("/Cart");
        }

        public IActionResult BrickPayed()
        {
            using (MailMessage testMessage = new MailMessage("test.user.talyan@gmail.com",User.Identity.Name))
            {
                using (SmtpClient testClient = new SmtpClient("smpt.gmail.com", 587))
                {
                    testMessage.Subject = "Ваш заказ в KirpichLand!";
                    testMessage.Body = "Ваш заказ оплачен и скоро будет собран!";
                    testClient.EnableSsl = true;
                    testClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    testClient.UseDefaultCredentials = false;
                    testClient.Timeout = 3000;
                    testClient.Credentials = new NetworkCredential("test.user.talyan@gmail.com", "qwedcsxazqwedcsxaz");
                    testClient.Send(testMessage);
                }
            }
            return(Redirect("/"));
        }
    }
}
