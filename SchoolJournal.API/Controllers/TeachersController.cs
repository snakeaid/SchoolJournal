using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolJournal.BusinessLogic.Commands;
using SchoolJournal.BusinessLogic.Queries;
using SchoolJournal.Primitives;

namespace SchoolJournal.API.Controllers;

/// <summary>
/// API controller teacher which controls all HTTP requests related to operations with teachers.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class TeachersController : ControllerBase
{
    private readonly ISender _sender;

    /// <summary>
    /// Constructs an instance of <see cref="TeachersController"/> using the specified sender.
    /// </summary>
    /// <param name="sender">An instance of <see cref="ISender"/>.</param>
    public TeachersController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Handles the HTTP GET request to get all teachers, invoked at /api/teachers route.
    /// </summary>
    /// <returns><see cref="List{T}"/> for <see cref="TeacherViewModel"/></returns>
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<TeacherViewModel>))]
    public async Task<IActionResult> Get()
    {
        var result = await _sender.Send(new GetAllTeachersQuery());
        return Ok(result);
    }

    /// Handles the HTTP GET request to get the teacher with the specified identifier, invoked at
    /// /api/teachers/id route.
    /// <param name="id">The identifier of the teacher.</param>
    /// <returns><see cref="TeacherViewModel"/></returns>
    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(TeacherViewModel))]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _sender.Send(new GetTeacherQuery { Id = id });
        return Ok(result);
    }

    /// Handles the HTTP DELETE request to delete a teacher, invoked at
    /// /api/teachers/ route.
    /// <param name="id">The identifier of the teacher.</param>
    /// <returns><see cref="TeacherViewModel"/></returns>
    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(TeacherViewModel))]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _sender.Send(new DeleteTeacherCommand { Model = new TeacherDeleteModel { Id = id } });
        return Ok(result);
    }

    /// Handles the HTTP POST request to add a new teacher, invoked at
    /// /api/teachers/ route.
    /// <param name="model">Create model of the teacher to be added.</param>
    /// <returns><see cref="TeacherViewModel"/></returns>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(TeacherViewModel))]
    public async Task<IActionResult> Post(TeacherCreateModel model)
    {
        var result = await _sender.Send(new CreateTeacherCommand { Model = model });
        return Ok(result);
    }

    /// Handles the HTTP POST request to update a teacher, invoked at
    /// /api/teachers/ route.
    /// <param name="model">Create model of the teacher to be added.</param>
    /// <returns><see cref="TeacherViewModel"/></returns>
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(TeacherViewModel))]
    public async Task<IActionResult> Put(TeacherUpdateModel model)
    {
        var result = await _sender.Send(new UpdateTeacherCommand { Model = model });
        return Ok(result);
    }
}