using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolJournal.BusinessLogic.Commands;
using SchoolJournal.BusinessLogic.Queries;
using SchoolJournal.Primitives;

namespace SchoolJournal.API.Controllers;

/// <summary>
/// API controller student which controls all HTTP requests related to operations with students.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly ISender _sender;

    /// <summary>
    /// Constructs an instance of <see cref="StudentsController"/> using the specified sender.
    /// </summary>
    /// <param name="sender">An instance of <see cref="ISender"/>.</param>
    public StudentsController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Handles the HTTP GET request to get all students, invoked at /api/students route.
    /// </summary>
    /// <returns><see cref="List{T}"/> for <see cref="StudentViewModel"/></returns>
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<StudentViewModel>))]
    public async Task<IActionResult> Get()
    {
        var result = await _sender.Send(new GetAllStudentsQuery());
        return Ok(result);
    }

    /// Handles the HTTP GET request to get the student with the specified identifier, invoked at
    /// /api/students/id route.
    /// <param name="id">The identifier of the student.</param>
    /// <returns><see cref="StudentViewModel"/></returns>
    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(StudentViewModel))]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _sender.Send(new GetStudentQuery { Id = id });
        return Ok(result);
    }

    /// Handles the HTTP DELETE request to delete a student, invoked at
    /// /api/students/ route.
    /// <param name="id">The identifier of the student.</param>
    /// <returns><see cref="StudentViewModel"/></returns>
    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(StudentViewModel))]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _sender.Send(new DeleteStudentCommand { Model = new StudentDeleteModel { Id = id } });
        return Ok(result);
    }

    /// Handles the HTTP POST request to add a new student, invoked at
    /// /api/students/ route.
    /// <param name="model">Create model of the student to be added.</param>
    /// <returns><see cref="StudentViewModel"/></returns>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(StudentViewModel))]
    public async Task<IActionResult> Post(StudentCreateModel model)
    {
        var result = await _sender.Send(new CreateStudentCommand { Model = model });
        return Ok(result);
    }

    /// Handles the HTTP POST request to update a student, invoked at
    /// /api/students/ route.
    /// <param name="model">Create model of the student to be added.</param>
    /// <returns><see cref="StudentViewModel"/></returns>
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(StudentViewModel))]
    public async Task<IActionResult> Put(StudentUpdateModel model)
    {
        var result = await _sender.Send(new UpdateStudentCommand { Model = model });
        return Ok(result);
    }
}