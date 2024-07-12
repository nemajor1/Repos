using BackendForClub.Data;
using BackendForClub.DataModels;
using Microsoft.EntityFrameworkCore;

namespace BackendForClub.Controllers.Registration
{
    public static class RegController
    {
        public static void Registration(this WebApplication app)
        {
            app.MapPost("/api/reg/Registration", RegistrUser);
        }
        private static async Task<IResult> RegistrUser(RegModel regModel, ApplicationContext db)
        {
            var existingUser = await db.UserModel.FirstOrDefaultAsync(u => u.Login == regModel.Login || u.Email == regModel.Email);
            if (existingUser != null)
            {
                return Results.Conflict(new { message = "Пользователь с таким логином или почтой уже существует" });
            }
            var user = new UserModel
            {
                Login = regModel.Login,
                Password = regModel.Password,
                Email = regModel.Email,
                Role = regModel.Role,
                Status = regModel.Status,
                DateRegistration = regModel.DateRegistration,
                Balance = regModel.Balance
            };
            await db.UserModel.AddAsync(user);
            await db.SaveChangesAsync();
            return Results.Json(user);
        }
    }
}
