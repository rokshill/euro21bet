using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TournamentForm.Application.Items.Queries;

namespace TournamentForm.WebUI.Controllers
{
    public class ItemController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ItemsPageVm> GetAll()
        {
            return await Mediator.Send(new GetItemsQuery());
        }

        [HttpGet("anonymous")]
        public ActionResult AnonymousPage()
        {
            return Ok("Hello Anonymous!");
        }

        [Authorize]
        [HttpGet("user")]
        public ActionResult UserPage()
        {
            return Ok("Hello User!");
        }

        [Authorize]
        [HttpGet("admin")]
        public ActionResult AdminPage()
        {
            return Ok("Hello Admin!");
        }
    }
}