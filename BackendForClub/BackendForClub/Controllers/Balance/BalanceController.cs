using BackendForClub.Data;
using Microsoft.EntityFrameworkCore;

namespace BackendForClub.Controllers.Balance
{
    public static class BalanceController
    {
        public static void Balance(this WebApplication app)
        {
            app.MapPost("/api/balance/AddBalance", AddBalance);
            app.MapPost("/api/balance/DelBalance", DelBalance);
        }
        private static async Task<IResult> AddBalance(BalanceModel balanceModel, ApplicationContext db)
        {
            var user = await db.UserModel.FirstOrDefaultAsync(u => u.Id == balanceModel.Id);
            if (user == null || balanceModel.Quantity <= 0)
            {
                return Results.Json($"Неверный запрос, {balanceModel.Id}  пользователь не найден, или {balanceModel.Quantity} <= 0 ");
            }
            user.Balance += balanceModel.Quantity;
            await db.SaveChangesAsync();
            return Results.Json($"Пополнено на {balanceModel.Quantity}");
        }
        private static async Task<IResult> DelBalance(BalanceModel balanceModel, ApplicationContext db)
        {
            var user = await db.UserModel.FirstOrDefaultAsync(u => u.Id == balanceModel.Id);
            if (user == null || balanceModel.Quantity <= 0 || user.Balance < balanceModel.Quantity)
            {
                return Results.Json($"Неверный запрос, {balanceModel.Id}  пользователь не найден, или {balanceModel.Quantity} <= 0, или > {user.Balance} ");
            }
            user.Balance -= balanceModel.Quantity;
            await db.SaveChangesAsync();
            return Results.Json($"Пополнено на {balanceModel.Quantity}");
        }
    }
}
