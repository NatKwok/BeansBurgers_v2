using Microsoft.AspNetCore.Mvc.RazorPages;
using BeansBurgers_v2.Data;
using BeansBurgers_v2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BeansBurgers_v2.Pages
{
    public class MenuModel : PageModel
    {
        public ApplicationDbContext db;
        public MenuModel(ApplicationDbContext db) => this.db = db;

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>(); 
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>(); 

        
        public async Task OnGetAsync(this ISession session){
            Ingredients = await db.Ingredients.ToListAsync();
            MenuItems = await db.MenuItems.ToListAsync();
            //OrderItems = await db.OrderItems.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(){
            string itemIndex = Request.Form["Order"];
            int itemInt = Int32.Parse(itemIndex);
            MenuItem add = db.MenuItems.ToList().ElementAt(itemInt - 1);
/*
            OrderItem cartItem = new OrderItem { Id = db.OrderItems.Count() + 1, MenuItem = add };
            Console.WriteLine(db.OrderItems.Count());
            await db.OrderItems.AddAsync(cartItem);
            Console.WriteLine(db.OrderItems.Count());
*/
            Ingredients = await db.Ingredients.ToListAsync();
            MenuItems = await db.MenuItems.ToListAsync();
            OrderItems = await db.OrderItems.ToListAsync();
            return Page();
        }
    }
}
