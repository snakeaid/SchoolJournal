using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolJournal.BusinessLogic.Commands;
using SchoolJournal.BusinessLogic.Queries;
using SchoolJournal.Primitives;

namespace SchoolJournal.API.Controllers;

/// <summary>
/// API controller class which controls all HTTP requests related to operations with classes.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ClassesController : ControllerBase
{
    private readonly ISender _sender;

    /// <summary>
    /// Constructs an instance of <see cref="ClassesController"/> using the specified sender.
    /// </summary>
    /// <param name="sender">An instance of <see cref="ISender"/>.</param>
    public ClassesController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Handles the HTTP GET request to get all classes, invoked at /api/classes route.
    /// </summary>
    /// <returns><see cref="List{T}"/> for <see cref="ClassViewModel"/></returns>
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ClassViewModel>))]
    public async Task<IActionResult> Get()
    {
        var result = await _sender.Send(new GetAllClassesQuery());
        return Ok(result);
    }

    /// Handles the HTTP GET request to get the class with the specified identifier, invoked at
    /// /api/classes/id route.
    /// <param name="id">The identifier of the class.</param>
    /// <returns><see cref="ClassViewModel"/></returns>
    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ClassViewModel))]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _sender.Send(new GetClassQuery { Id = id });
        return Ok(result);
    }

    /// Handles the HTTP DELETE request to delete a class, invoked at
    /// /api/classes/ route.
    /// <param name="id">The identifier of the class.</param>
    /// <returns><see cref="ClassViewModel"/></returns>
    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ClassViewModel))]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _sender.Send(new DeleteClassCommand { Model = new ClassDeleteModel { Id = id } });
        return Ok(result);
    }

    /// Handles the HTTP POST request to add a new class, invoked at
    /// /api/classes/ route.
    /// <param name="model">Create model of the class to be added.</param>
    /// <returns><see cref="ClassViewModel"/></returns>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(ClassViewModel))]
    public async Task<IActionResult> Post(ClassCreateModel model)
    {
        var result = await _sender.Send(new CreateClassCommand { Model = model });
        return Ok(result);
    }

    /// Handles the HTTP POST request to update a class, invoked at
    /// /api/classes/ route.
    /// <param name="model">Create model of the class to be added.</param>
    /// <returns><see cref="ClassViewModel"/></returns>
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ClassViewModel))]
    public async Task<IActionResult> Put(ClassUpdateModel model)
    {
        var result = await _sender.Send(new UpdateClassCommand { Model = model });
        return Ok(result);
    }
}