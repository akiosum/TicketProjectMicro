using System.Net;
using FastResults.Enums;
using FastResults.Errors;

namespace TicketProject.Shared.Errors;

public partial class TicketError
{
    public class Common
    {
        public static Error ErrorInternal => new(
            HttpStatusCode.InternalServerError,
            "Internal error, please contact support!",
            TypeError.InternalError);

        public static Error AccessDenied => new(
            HttpStatusCode.Unauthorized,
            "Access denied. The user does not have permission for this action.",
            TypeError.Unauthorized);

        public static Error Validation(string mensagem) => new(
            HttpStatusCode.BadRequest,
            mensagem,
            TypeError.Validation);
    }
}