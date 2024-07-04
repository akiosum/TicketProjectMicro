using FastResults.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketProject.Application.Requests.Ticket;
using TicketProject.Presentation.Abstractions;

namespace TicketProject.Presentation.Controllers;

[Route("[controller]")]
public class TicketController(ISender sender) : BaseApiController(sender)
{
    [HttpPost]
    public async Task<ActionResult> Create(
        [FromBody] CreateTicketRequest request, 
        CancellationToken cancellationToken)
    {
        BaseResult result = await sender.Send(request, cancellationToken);
        return Response(result);
    }
}