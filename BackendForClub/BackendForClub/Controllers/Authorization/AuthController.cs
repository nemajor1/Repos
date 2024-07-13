using BackendForClub.Data;
using Microsoft.EntityFrameworkCore;

namespace BackendForClub.Controllers.Authorization
{
    public static class AuthController
    {
        public static void Authorization(this WebApplication app)
        {
            app.MapPost("/api/auth/Authorization", AuthorizeUser);
        }
        private static async Task<IResult> AuthorizeUser(AuthModel authModel, ApplicationContext db)
        {
            if (authModel == null || string.IsNullOrEmpty(authModel.Login) || string.IsNullOrEmpty(authModel.Password))
            {
                return Results.BadRequest(new { message = "Неверные учетные данные" });
            }
            var user = await db.UserModel.FirstOrDefaultAsync(u => u.Login == authModel.Login
                                                            && u.Password == authModel.Password);
            if (user == null)
            {
                return Results.NotFound(new { message = "Пользователь не найден или неверный пароль" });
            }
            return Results.Json(user);
        }
    }
}
