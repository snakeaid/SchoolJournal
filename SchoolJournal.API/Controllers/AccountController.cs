using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolJournal.BusinessLogic.Queries;
using SchoolJournal.Primitives;

namespace SchoolJournal.API.Controllers;

/// <summary>
/// API controller class which controls all HTTP requests related to operations with account.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly ISender _sender;

    /// <summary>
    /// Constructs an instance of <see cref="AccountController"/> using the specified sender.
    /// </summary>
    /// <param name="sender">An instance of <see cref="ISender"/>.</param>
    public AccountController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Handles the HTTP POST request to log in, invoked at /api/account route.
    /// </summary>
    /// <returns><see cref="ClassViewModel"/></returns>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ClassViewModel>))]
    public async Task<IActionResult> Login()
    {
        var result = await _sender.Send(new GetAllClassesQuery());
        return Ok(result);
    }
}