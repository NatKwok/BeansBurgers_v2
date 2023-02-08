using Microsoft.AspNetCore.Mvc.RazorPages;
using BeansBurgers_v2.Data;
using BeansBurgers_v2.Models;
using Microsoft.EntityFrameworkCore;

namespace BeansBurgers_v2.Pages
{
    public class MenuModel : PageModel
    {
        private ApplicationDbContext db;
        public MenuModel(ApplicationDbContext db) => this.db = db;

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();        
        
        public async Task OnGetAsync(){
            Ingredients = await db.Ingredients.ToListAsync();
        }
    }
}
