using FastResults.Controllers;
using MediatR;

namespace TicketProject.Presentation.Abstractions;

public class BaseApiController(ISender sender) : BaseController
{
}