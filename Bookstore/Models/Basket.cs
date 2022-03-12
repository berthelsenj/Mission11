using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public virtual void AddItem (Book books, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Books.BookId == books.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Books = books,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveItem (Book books)
        {
            Items.RemoveAll(x => x.Books.BookId == books.BookId);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Books.Price);

            return sum;
        }
    }

    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Books { get; set; }
        public int Quantity { get; set; }
    }
}
