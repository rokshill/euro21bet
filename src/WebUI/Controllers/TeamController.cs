using System.Collections.Generic;
using System.Threading.Tasks;
using Euro21bet.Application.Teams.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Euro21bet.WebUI.Controllers
{
    public class TeamController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IReadOnlyCollection<TeamDto>> GetAll()
        {
            var user = this.HttpContext.User;
                return await Mediator.Send(new GetAllTeamsQuery());
        }
    }
}
