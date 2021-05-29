using System.Linq;
using System.Threading.Tasks;
using Euro21bet.Domain.Entities;

namespace Euro21bet.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!context.Groups.Any())
            {
                var groupA = new Group("Grupa A");
                var groupB = new Group("Grupa B");
                var groupC = new Group("Grupa C");
                var groupD = new Group("Grupa D");
                var groupE = new Group("Grupa E");
                var groupF = new Group("Grupa F");

                await context.Groups.AddRangeAsync(groupA, groupB, groupC, groupD, groupE, groupF);

                await context.Teams.AddRangeAsync(
                    new Team("Włochy", "ITA", "euro2021/flags/italy.png", groupA),
                    new Team("Szwajcaria", "SWI", "euro2021/flags/switzerland.png", groupA),
                    new Team("Turcja", "TUR", "euro2021/flags/turkey.png", groupA),
                    new Team("Walia", "WAL", "euro2021/flags/wales.png", groupA)
                );

                await context.Teams.AddRangeAsync(
                    new Team("Belgia", "BEL", "euro2021/flags/belgium.png", groupB),
                    new Team("Dania", "DEN", "euro2021/flags/denmark.png", groupB),
                    new Team("Finlandia", "FIN", "euro2021/flags/finland.png", groupB),
                    new Team("Rosja", "RUS", "euro2021/flags/russia.png", groupB)
                );

                await context.Teams.AddRangeAsync(
                    new Team("Austria", "AUT", "euro2021/flags/austria.png", groupC),
                    new Team("Holandia", "NLD", "euro2021/flags/netherlands.png", groupC),
                    new Team("Macedonia Płn.", "MKD", "euro2021/flags/north-macedonia.png", groupC),
                    new Team("Ukraina", "UKR", "euro2021/flags/ukraine.png", groupC)
                );

                await context.Teams.AddRangeAsync(
                    new Team("Chorwacja", "CRO", "euro2021/flags/croatia.png", groupD),
                    new Team("Czechy", "CZE", "euro2021/flags/czech-republic.png", groupD),
                    new Team("Anglia", "ENG", "euro2021/flags/england.png", groupD),
                    new Team("Szkocja", "SCO", "euro2021/flags/scotland.png", groupD)
                );

                await context.Teams.AddRangeAsync(
                    new Team("Polska", "POL", "euro2021/flags/poland.png", groupE),
                    new Team("Słowacja", "SVK", "euro2021/flags/slovakia.png", groupE),
                    new Team("Hiszpania", "ESP", "euro2021/flags/spain.png", groupE),
                    new Team("Szwecja", "SWE", "euro2021/flags/sweden.png", groupE)
                );

                await context.Teams.AddRangeAsync(
                    new Team("Francja", "FRA", "euro2021/flags/france.png", groupF),
                    new Team("Niemcy", "GER", "euro2021/flags/germany.png", groupF),
                    new Team("Węgry", "HUN", "euro2021/flags/hungary.png", groupF),
                    new Team("Portugalia", "PRT", "euro2021/flags/portugal.png", groupF)
                );

                context.SaveChangesAsync();
            }
        }
    }
}
