using System;
using System.Linq;
using System.Threading.Tasks;
using TournamentForm.Domain.Entities;

namespace TournamentForm.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!context.Items.Any())
            {
                var item1 = new Item("Item 1", "Item 1 description");
                var item2 = new Item("Item 2", "Item 2 description");
                var item3 = new Item("Item 3", "Item 3 description");
                var item4 = new Item("Item 4", "Item 4 description");
                var item5 = new Item("Item 5", "Item 5 description");
                var item6 = new Item("Item 6", "Item 6 description");
                var item7 = new Item("Item 7", "Item 7 description");

                await context.Items.AddRangeAsync(item1, item2, item3, item4, item5, item6, item7);

                await context.SaveChangesAsync();
            }
        }
    }
}
