using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolJournal.BusinessLogic.Commands;
using SchoolJournal.BusinessLogic.Queries;
using SchoolJournal.Primitives;

namespace SchoolJournal.API.Controllers;

/// <summary>
/// API controller subject which controls all HTTP requests related to operations with subjects.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SubjectsController : ControllerBase
{
    private readonly ISender _sender;

    /// <summary>
    /// Constructs an instance of <see cref="SubjectsController"/> using the specified sender.
    /// </summary>
    /// <param name="sender">An instance of <see cref="ISender"/>.</param>
    public SubjectsController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Handles the HTTP GET request to get all subjects, invoked at /api/subjects route.
    /// </summary>
    /// <returns><see cref="List{T}"/> for <see cref="SubjectViewModel"/></returns>
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<SubjectViewModel>))]
    public async Task<IActionResult> Get()
    {
        var result = await _sender.Send(new GetAllSubjectsQuery());
        return Ok(result);
    }

    /// Handles the HTTP GET request to get the subject with the specified identifier, invoked at
    /// /api/subjects/id route.
    /// <param name="id">The identifier of the subject.</param>
    /// <returns><see cref="SubjectViewModel"/></returns>
    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SubjectViewModel))]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _sender.Send(new GetSubjectQuery { Id = id });
        return Ok(result);
    }

    /// Handles the HTTP DELETE request to delete a subject, invoked at
    /// /api/subjects/ route.
    /// <param name="id">The identifier of the subject.</param>
    /// <returns><see cref="SubjectViewModel"/></returns>
    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SubjectViewModel))]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _sender.Send(new DeleteSubjectCommand { Model = new SubjectDeleteModel { Id = id } });
        return Ok(result);
    }

    /// Handles the HTTP POST request to add a new subject, invoked at
    /// /api/subjects/ route.
    /// <param name="model">Create model of the subject to be added.</param>
    /// <returns><see cref="SubjectViewModel"/></returns>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SubjectViewModel))]
    public async Task<IActionResult> Post(SubjectCreateModel model)
    {
        var result = await _sender.Send(new CreateSubjectCommand { Model = model });
        return Ok(result);
    }

    /// Handles the HTTP POST request to update a subject, invoked at
    /// /api/subjects/ route.
    /// <param name="model">Create model of the subject to be added.</param>
    /// <returns><see cref="SubjectViewModel"/></returns>
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SubjectViewModel))]
    public async Task<IActionResult> Put(SubjectUpdateModel model)
    {
        var result = await _sender.Send(new UpdateSubjectCommand { Model = model });
        return Ok(result);
    }
}