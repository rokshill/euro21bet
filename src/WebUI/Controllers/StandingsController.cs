using System.Threading.Tasks;
using Euro21bet.Application.Standings.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Euro21bet.WebUI.Controllers
{
    public class StandingsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<StandingsPageVm> GetAll()
        {
            return await Mediator.Send(new GetStandingsQuery());
        }
    }
}