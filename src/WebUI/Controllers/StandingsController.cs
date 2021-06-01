using System.Collections.Generic;
using System.Threading.Tasks;
using Euro21bet.Application.Standings.Queries;
using Euro21bet.Application.Teams.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Euro21bet.WebUI.Controllers
{
    public class StandingsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<StandingsPageViewModel> GetAll()
        {
            return await Mediator.Send(new GetStandingsQuery());
        }
    }
}