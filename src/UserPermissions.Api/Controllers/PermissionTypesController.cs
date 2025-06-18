using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserPermissions.Application.Permissions.Queries;


namespace UserPermissions.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PermissionTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public PermissionTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllPermissionTypesQuery());
        return Ok(result);
    }
}
