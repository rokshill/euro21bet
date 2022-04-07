using System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace TournamentForm.WebUI.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender? _mediator;

        protected ISender Mediator => (_mediator ??= HttpContext.RequestServices.GetService<ISender>()) ?? throw new InvalidOperationException("Mediator not found");
    }
}
