using System.Threading.Tasks;
using APP.DB;
using APP.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace APP.Common.Helpers
{
    /// <summary>
    /// Пока не рабочий сервис для записи аудитов. Надо решить вопрос с жизнью сервиса, т.к. он использует контекст БД, у которого время жизни синглтон.
    /// </summary>
    public class AuthHelper
    {
        private readonly PanelContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthHelper(IHttpContextAccessor httpContextAccessor, PanelContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<User> GetCurrentUser()
        {
            var httpUser = _httpContextAccessor.HttpContext.User;
            var user = _context.Users.FirstOrDefaultAsync(x => x.Login == httpUser.Identity.Name);

            return new User();
        }
    }
}