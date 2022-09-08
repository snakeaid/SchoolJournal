using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolJournal.BusinessLogic.Queries;
using SchoolJournal.Primitives;

namespace SchoolJournal.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClassesController : ControllerBase
{
    private readonly ISender _sender;

    public ClassesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ClassModel>))]
    public async Task<IActionResult> Get()
    {
        var result = await _sender.Send(new GetAllClassesQuery());
        return Ok(result);
    }
}