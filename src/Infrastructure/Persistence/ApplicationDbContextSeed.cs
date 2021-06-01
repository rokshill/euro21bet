using System;
using System.Linq;
using System.Threading.Tasks;
using Euro21bet.Domain.Entities;
using Euro21bet.Domain.Enums;

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

                var ita = new Team("Włochy", "ITA", "euro2021/flags/italy.png", groupA);
                var swi = new Team("Szwajcaria", "SWI", "euro2021/flags/switzerland.png", groupA);
                var tur = new Team("Turcja", "TUR", "euro2021/flags/turkey.png", groupA);
                var wal = new Team("Walia", "WAL", "euro2021/flags/wales.png", groupA);
                await context.Teams.AddRangeAsync(ita, swi, tur, wal);
                
                var bel = new Team("Belgia", "BEL", "euro2021/flags/belgium.png", groupB);
                var den = new Team("Dania", "DEN", "euro2021/flags/denmark.png", groupB);
                var fin = new Team("Finlandia", "FIN", "euro2021/flags/finland.png", groupB);
                var rus = new Team("Rosja", "RUS", "euro2021/flags/russia.png", groupB);
                await context.Teams.AddRangeAsync(bel, den, fin, rus);
                
                var aut = new Team("Austria", "AUT", "euro2021/flags/austria.png", groupC);
                var nld = new Team("Holandia", "NLD", "euro2021/flags/netherlands.png", groupC);
                var mkd = new Team("Macedonia Płn.", "MKD", "euro2021/flags/north-macedonia.png", groupC);
                var ukr = new Team("Ukraina", "UKR", "euro2021/flags/ukraine.png", groupC);
                await context.Teams.AddRangeAsync(aut, nld, mkd, ukr);
                
                var cro = new Team("Chorwacja", "CRO", "euro2021/flags/croatia.png", groupD);
                var cze = new Team("Czechy", "CZE", "euro2021/flags/czech-republic.png", groupD);
                var eng = new Team("Anglia", "ENG", "euro2021/flags/england.png", groupD);
                var sco = new Team("Szkocja", "SCO", "euro2021/flags/scotland.png", groupD);
                await context.Teams.AddRangeAsync(cro, cze, eng, sco);
                
                var pol = new Team("Polska", "POL", "euro2021/flags/poland.png", groupE);
                var svk = new Team("Słowacja", "SVK", "euro2021/flags/slovakia.png", groupE);
                var esp = new Team("Hiszpania", "ESP", "euro2021/flags/spain.png", groupE);
                var swe = new Team("Szwecja", "SWE", "euro2021/flags/sweden.png", groupE);
                await context.Teams.AddRangeAsync(pol, svk, esp, swe);
                
                var fra = new Team("Francja", "FRA", "euro2021/flags/france.png", groupF);
                var ger = new Team("Niemcy", "GER", "euro2021/flags/germany.png", groupF);
                var hun = new Team("Węgry", "HUN", "euro2021/flags/hungary.png", groupF);
                var prt = new Team("Portugalia", "PRT", "euro2021/flags/portugal.png", groupF);
                await context.Teams.AddRangeAsync(fra, ger, hun, prt);
                
                var roundGroupStage1 = new Round("Faza grupowa - Kolejka 1 z 3", RoundMatchType.Group);
                await context.Rounds.AddAsync(roundGroupStage1);

                var tur_ita = new Match(new DateTime(2021, 6, 11, 21, 0, 0), tur, ita);
                groupA.AddMatch(tur_ita);
                
                var wal_swi = new Match(new DateTime(2021, 6, 12, 15, 0, 0), wal, swi);
                groupA.AddMatch(wal_swi);

                var den_fin = new Match(new DateTime(2021, 6, 12, 18, 0, 0), den, fin);
                groupB.AddMatch(den_fin);
                var bel_rus = new Match(new DateTime(2021, 6, 12, 21, 0, 0), bel, rus);
                groupB.AddMatch(bel_rus);

                var eng_cro = new Match(new DateTime(2021, 6, 13, 15, 0, 0), eng, cro);
                groupD.AddMatch(eng_cro);
                var aut_mkd = new Match(new DateTime(2021, 6, 13, 18, 0, 0), aut, mkd);
                groupC.AddMatch(aut_mkd);

                var nld_ukr = new Match(new DateTime(2021, 6, 13, 21, 0, 0), nld, ukr);
                groupC.AddMatch(nld_ukr);
                var sco_cze = new Match(new DateTime(2021, 6, 14, 15, 0, 0), sco, cze);
                groupD.AddMatch(sco_cze);

                var pol_svk = new Match(new DateTime(2021, 6, 14, 18, 0, 0), pol, svk);
                groupE.AddMatch(pol_svk);
                var esp_swe = new Match(new DateTime(2021, 6, 14, 21, 0, 0), esp, swe);
                groupE.AddMatch(esp_swe);

                var hun_prt = new Match(new DateTime(2021, 6, 15, 18, 0, 0), hun, prt);
                groupF.AddMatch(hun_prt);
                var fra_ger = new Match(new DateTime(2021, 6, 15, 21, 0, 0), fra, ger);
                groupF.AddMatch(fra_ger);

                roundGroupStage1.AddMatch(tur_ita);
                roundGroupStage1.AddMatch(wal_swi);
                roundGroupStage1.AddMatch(den_fin);
                roundGroupStage1.AddMatch(bel_rus);
                roundGroupStage1.AddMatch(eng_cro);
                roundGroupStage1.AddMatch(aut_mkd);
                roundGroupStage1.AddMatch(nld_ukr);
                roundGroupStage1.AddMatch(sco_cze);
                roundGroupStage1.AddMatch(pol_svk);
                roundGroupStage1.AddMatch(esp_swe);
                roundGroupStage1.AddMatch(hun_prt);
                roundGroupStage1.AddMatch(fra_ger);

                var roundGroupStage2 = new Round("Faza grupowa - Kolejka 2 z 3", RoundMatchType.Group);
                await context.Rounds.AddAsync(roundGroupStage2);

                var fin_rus = new Match(new DateTime(2021, 6, 16, 15, 0, 0), fin, rus);
                groupB.AddMatch(fin_rus);
                var tur_wal = new Match(new DateTime(2021, 6, 16, 18, 0, 0), tur, wal);
                groupA.AddMatch(tur_wal);

                var ita_swi = new Match(new DateTime(2021, 6, 16, 21, 0, 0), ita, swi);
                groupA.AddMatch(ita_swi);
                var ukr_mkd = new Match(new DateTime(2021, 6, 17, 15, 0, 0), ukr, mkd);
                groupC.AddMatch(ukr_mkd);

                var den_bel = new Match(new DateTime(2021, 6, 17, 18, 0, 0), den, bel);
                groupB.AddMatch(den_bel);
                var nld_aut = new Match(new DateTime(2021, 6, 17, 21, 0, 0), nld, aut);
                groupC.AddMatch(nld_aut);

                var swe_svk = new Match(new DateTime(2021, 6, 18, 15, 0, 0), swe, svk);
                groupE.AddMatch(swe_svk);
                var cro_cze = new Match(new DateTime(2021, 6, 18, 18, 0, 0), cro, cze);
                groupD.AddMatch(cro_cze);

                var eng_sco = new Match(new DateTime(2021, 6, 18, 21, 0, 0), eng, sco);
                groupD.AddMatch(eng_sco);
                var hun_fra = new Match(new DateTime(2021, 6, 19, 15, 0, 0), hun, fra);
                groupF.AddMatch(hun_fra);

                var prt_ger = new Match(new DateTime(2021, 6, 19, 18, 0, 0), prt, ger);
                groupF.AddMatch(prt_ger);
                var esp_pol = new Match(new DateTime(2021, 6, 19, 21, 0, 0), esp, pol);
                groupE.AddMatch(esp_pol);

                roundGroupStage2.AddMatch(fin_rus);
                roundGroupStage2.AddMatch(tur_wal);
                roundGroupStage2.AddMatch(ita_swi);
                roundGroupStage2.AddMatch(ukr_mkd);
                roundGroupStage2.AddMatch(den_bel);
                roundGroupStage2.AddMatch(nld_aut);
                roundGroupStage2.AddMatch(swe_svk);
                roundGroupStage2.AddMatch(cro_cze);
                roundGroupStage2.AddMatch(eng_sco);
                roundGroupStage2.AddMatch(hun_fra);
                roundGroupStage2.AddMatch(prt_ger);
                roundGroupStage2.AddMatch(esp_pol);

                var roundGroupStage3 = new Round("Faza grupowa - Kolejka 3 z 3", RoundMatchType.Group);
                await context.Rounds.AddAsync(roundGroupStage3);

                var ita_wal = new Match(new DateTime(2021, 6, 20, 18, 0, 0), ita, wal);
                groupA.AddMatch(ita_wal);
                var swi_tur = new Match(new DateTime(2021, 6, 20, 18, 0, 0), swi, tur);
                groupA.AddMatch(swi_tur);

                var ukr_aut = new Match(new DateTime(2021, 6, 21, 18, 0, 0), ukr, aut);
                groupC.AddMatch(ukr_aut);
                var mkd_nld = new Match(new DateTime(2021, 6, 21, 18, 0, 0), mkd, nld);
                groupC.AddMatch(mkd_nld);

                var rus_den = new Match(new DateTime(2021, 6, 21, 21, 0, 0), rus, den);
                groupB.AddMatch(rus_den);
                var fin_bel = new Match(new DateTime(2021, 6, 21, 21, 0, 0), fin, bel);
                groupB.AddMatch(fin_bel);

                var cro_sco = new Match(new DateTime(2021, 6, 22, 21, 0, 0), cro, sco);
                groupD.AddMatch(cro_sco);
                var cze_eng = new Match(new DateTime(2021, 6, 22, 21, 0, 0), cze, eng);
                groupD.AddMatch(cze_eng);

                var swe_pol = new Match(new DateTime(2021, 6, 23, 18, 0, 0), swe, pol);
                groupE.AddMatch(swe_pol);
                var svk_esp = new Match(new DateTime(2021, 6, 23, 18, 0, 0), svk, esp);
                groupE.AddMatch(svk_esp);

                var prt_fra = new Match(new DateTime(2021, 6, 23, 21, 0, 0), prt, fra);
                groupF.AddMatch(prt_fra);
                var ger_hun = new Match(new DateTime(2021, 6, 23, 21, 0, 0), ger, hun);
                groupF.AddMatch(ger_hun);

                roundGroupStage3.AddMatch(ita_wal);
                roundGroupStage3.AddMatch(swi_tur);
                roundGroupStage3.AddMatch(ukr_aut);
                roundGroupStage3.AddMatch(mkd_nld);
                roundGroupStage3.AddMatch(rus_den);
                roundGroupStage3.AddMatch(fin_bel);
                roundGroupStage3.AddMatch(cro_sco);
                roundGroupStage3.AddMatch(cze_eng);
                roundGroupStage3.AddMatch(swe_pol);
                roundGroupStage3.AddMatch(svk_esp);
                roundGroupStage3.AddMatch(prt_fra);
                roundGroupStage3.AddMatch(ger_hun);

                context.SaveChangesAsync();
            }
        }
    }
}
