using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolJournal.BusinessLogic.Commands;
using SchoolJournal.BusinessLogic.Queries;
using SchoolJournal.Primitives;

namespace SchoolJournal.API.Controllers;

/// <summary>
/// API controller class which controls all HTTP requests related to operations with subject journals.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SubjectJournalsController : ControllerBase
{
    private readonly ISender _sender;

    /// <summary>
    /// Constructs an instance of <see cref="SubjectJournalsController"/> using the specified sender.
    /// </summary>
    /// <param name="sender">An instance of <see cref="ISender"/>.</param>
    public SubjectJournalsController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Handles the HTTP GET request to get all subject journals, invoked at /api/subject journals route.
    /// </summary>
    /// <returns><see cref="List{T}"/> for <see cref="SubjectJournalViewModel"/></returns>
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<SubjectJournalViewModel>))]
    public async Task<IActionResult> Get()
    {
        var result = await _sender.Send(new GetAllSubjectJournalsQuery());
        return Ok(result);
    }

    /// Handles the HTTP GET request to get the subject journal with the specified identifier, invoked at
    /// /api/subject journals/id route.
    /// <param name="id">The identifier of the subject journal.</param>
    /// <returns><see cref="SubjectJournalViewModel"/></returns>
    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SubjectJournalViewModel))]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _sender.Send(new GetSubjectJournalQuery { Id = id });
        return Ok(result);
    }

    /// Handles the HTTP DELETE request to delete a subject journal, invoked at
    /// /api/subject journals/ route.
    /// <param name="id">The identifier of the subject journal.</param>
    /// <returns><see cref="SubjectJournalViewModel"/></returns>
    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SubjectJournalViewModel))]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _sender.Send(new DeleteSubjectJournalCommand
            { Model = new SubjectJournalDeleteModel { Id = id } });
        return Ok(result);
    }

    /// Handles the HTTP POST request to add a new subject journal, invoked at
    /// /api/subject journals/ route.
    /// <param name="model">Create model of the subject journal to be added.</param>
    /// <returns><see cref="SubjectJournalViewModel"/></returns>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SubjectJournalViewModel))]
    public async Task<IActionResult> Post(SubjectJournalCreateModel model)
    {
        var result = await _sender.Send(new CreateSubjectJournalCommand { Model = model });
        return Ok(result);
    }

    /// Handles the HTTP POST request to update a subject journal, invoked at
    /// /api/subject journals/ route.
    /// <param name="model">Create model of the subject journal to be added.</param>
    /// <returns><see cref="SubjectJournalViewModel"/></returns>
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SubjectJournalViewModel))]
    public async Task<IActionResult> Put(SubjectJournalUpdateModel model)
    {
        var result = await _sender.Send(new UpdateSubjectJournalCommand { Model = model });
        return Ok(result);
    }
}