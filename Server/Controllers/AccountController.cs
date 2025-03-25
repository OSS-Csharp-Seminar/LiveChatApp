using ChatApp.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ChatContext _chatContext;

        public AccountController(ChatContext chatContext)
        {
            _chatContext = chatContext;
        }

        public async Task<IActionResult> Register(RegisterDTO dto, CancellationToken cancellationToken)
        {

        }

    }
}
