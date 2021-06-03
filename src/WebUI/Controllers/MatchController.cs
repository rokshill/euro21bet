using System.Threading.Tasks;
using Euro21bet.Application.Matches.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Euro21bet.WebUI.Controllers
{
    public class MatchController : ApiControllerBase
    {
        [HttpGet]
        public async Task<MatchesPageVm> GetAll()
        {
            return await Mediator.Send(new GetMatchesQuery());
        }
    }
}