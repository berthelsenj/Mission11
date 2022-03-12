using System;
using Microsoft.AspNetCore.Mvc;
using Bookstore.Models;

namespace Bookstore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket basket;
        public CartSummaryViewComponent(Basket temp)
        {
            basket = temp;
        }
        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}