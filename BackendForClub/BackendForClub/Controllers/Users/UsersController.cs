using BackendForClub.Controllers.Users;
using BackendForClub.Data;
using BackendForClub.DataModels;
using Microsoft.EntityFrameworkCore;

namespace BackendForClub.Controllers.UsersModel
{
    public static class UsersModelController
    {
        public static void Users(this WebApplication app)
        {
            app.MapGet("/api/users/GetUsers", GetUsers);
            app.MapGet("/api/users/GetUserById", GetUserById);
            app.MapDelete("/api/users/DeleteUserById", DeleteUserById);
            app.MapPut("/api/users/UpdateUserLogin", UpdateUserLogin);
            app.MapPut("/api/users/UpdateUserPassword", UpdateUserPassword);
            app.MapPut("/api/users/UpdateUserEmail", UpdateUserEmail);
            app.MapPut("/api/users/UpdateUserStatus", UpdateUserStatus);
            app.MapPut("/api/users/UpdateUserRole", UpdateUserRole);
        }
        private static async Task<IResult> GetUsers(ApplicationContext db)
        {
            var UsersModel = await db.UserModel.ToListAsync();
            return Results.Json(UsersModel);
        }
        private static async Task<IResult> GetUserById(int Id, ApplicationContext db)
        {
            var user = await db.UserModel.FirstOrDefaultAsync(u => u.Id == Id);
            if (user == null)
            {
                return Results.NotFound(new { message = "Пользователь не найден" });
            }
            return Results.Json(user);
        }
        private static async Task<IResult> DeleteUserById(int Id, ApplicationContext db)
        {
            var user = await db.UserModel.FirstOrDefaultAsync(u => u.Id == Id);
            if (user == null)
            {
                return Results.NotFound(new { message = "Пользователь не найден" });
            }
            db.UserModel.Remove(user);
            await db.SaveChangesAsync();
            return Results.Json(user);
        }
        private static async Task<IResult> UpdateUserLogin(UserLoginModel userData, ApplicationContext db)
        {
            var user = await db.UserModel.FirstOrDefaultAsync(u => u.Id == userData.Id);
            if (user == null)
            {
                return Results.NotFound(new { message = "Пользователь не найден" });
            }
            user.Login = userData.Login;
            await db.SaveChangesAsync();
            return Results.Json(user);
        }
        private static async Task<IResult> UpdateUserPassword(UserPasswordModel userData, ApplicationContext db)
        {
            var user = await db.UserModel.FirstOrDefaultAsync(u => u.Id == userData.Id);
            if (user == null)
            {
                return Results.NotFound(new { message = "Пользователь не найден" });
            }
            user.Password = userData.Password;
            await db.SaveChangesAsync();
            return Results.Json(user);
        }
        private static async Task<IResult> UpdateUserEmail(UserEmailModel userData, ApplicationContext db)
        {
            var user = await db.UserModel.FirstOrDefaultAsync(u => u.Id == userData.Id);
            if (user == null)
            {
                return Results.NotFound(new { message = "Пользователь не найден" });
            }
            user.Email = userData.Email;
            await db.SaveChangesAsync();
            return Results.Json(user);
        }
        private static async Task<IResult> UpdateUserStatus(UserStatusModel userData, ApplicationContext db)
        {
            var user = await db.UserModel.FirstOrDefaultAsync(u => u.Id == userData.Id);
            if (user == null)
            {
                return Results.NotFound(new { message = "Пользователь не найден" });
            }
            user.Status = userData.Status;
            await db.SaveChangesAsync();
            return Results.Json(user);
        }
        private static async Task<IResult> UpdateUserRole(UserRoleModel userData, ApplicationContext db)
        {
            var user = await db.UserModel.FirstOrDefaultAsync(u => u.Id == userData.Id);
            if (user == null)
            {
                return Results.NotFound(new { message = "Пользователь не найден" });
            }
            user.Role = userData.Role;
            await db.SaveChangesAsync();
            return Results.Json(user);
        }
    }
}
