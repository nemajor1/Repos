using BackendForClub.Data;
using BackendForClub.DataModels;
using Microsoft.EntityFrameworkCore;

namespace BackendForClub.Controllers.Bar
{
    public static class BarController
    {
        public static void Bar(this WebApplication app)
        {
            app.MapGet("/api/bar/GetAllPositoin", GetAllPosition);
            app.MapGet("/api/bar/FindPositionById", FindPositionById);
            app.MapPost("/api/bar/AddPosition", AddPosition);
            app.MapDelete("/api/bar/DeletePosition", DeletePosition);
            app.MapPut("/api/bar/AddQuantity", AddQuantity);
            app.MapPut("/api/bar/DelQuantity", DelQuantity);
            app.MapPut("/api/bar/SetPrice", SetPrice);
            app.MapPut("/api/bar/SetQuantity", SetQuantity);

        }
        private static async Task<IResult> GetAllPosition(ApplicationContext db)
        {
            var bar = await db.BarModel.ToListAsync();
            return Results.Json(bar);
        }
        private static async Task<IResult> FindPositionById(int Id, ApplicationContext db)
        {
            var bar = await db.BarModel.FirstOrDefaultAsync(b => b.Id == Id);
            if (bar == null)
            {
                return Results.Json("Не найден");
            }
            return Results.Json(bar);
        }
        private static async Task<IResult> AddPosition(AddPositionModel bar, ApplicationContext db)
        {
            var existPos = await db.BarModel.FirstOrDefaultAsync(b => b.Name == bar.Name);
            if (existPos != null)
            {
                return Results.Json($"Позиция {bar.Name} уже существует");
            }
            var pos = new BarModel
            {
                Name = bar.Name
            };
            await db.BarModel.AddAsync(pos);
            await db.SaveChangesAsync();
            return Results.Json($"Позиция {bar.Name} создана");
        }
        private static async Task<IResult> DeletePosition(int Id, ApplicationContext db)
        {
            var pos = await db.BarModel.FirstOrDefaultAsync(b => b.Id == Id);
            if(pos == null)
            {
                return Results.Json("Позиция не найдена");
            }
            db.Remove(pos);
            await db.SaveChangesAsync();
            return Results.Json("Success");
        }
        private static async Task<IResult> AddQuantity(QuantityModel qm, ApplicationContext db)
        {
            var bar = await db.BarModel.FirstOrDefaultAsync(b => b.Id == qm.Id);
            if (bar == null || qm.Quantity <= 0)
            {
                return Results.Json($"Неверный запрос, {qm.Id} позиция не найдена, или {qm.Quantity} <= 0 ");
            }
            bar.Quantity += qm.Quantity;
            await db.SaveChangesAsync();
            return Results.Json($"Пополнено на {qm.Quantity}");
        }
        private static async Task<IResult> DelQuantity(QuantityModel qm, ApplicationContext db)
        {
            var bar = await db.BarModel.FirstOrDefaultAsync(u => u.Id == qm.Id);
            if (bar == null || qm.Quantity <= 0 || bar.Quantity < qm.Quantity)
            {
                return Results.Json($"Неверный запрос, {qm.Id}  позиция не найдена, или {qm.Quantity} <= 0, или > {bar.Quantity} ");
            }
            bar.Quantity -= qm.Quantity;
            await db.SaveChangesAsync();
            return Results.Json($"Списание на {qm.Quantity}");
        }
        private static async Task<IResult> SetPrice(PriceModel pm, ApplicationContext db)
        {
            var bar = await db.BarModel.FirstOrDefaultAsync(u => u.Id == pm.Id);
            if (bar == null || pm.Price < 0)
            {
                return Results.Json("Not found");
            }
            bar.Price = pm.Price;
            await db.SaveChangesAsync();
            return Results.Json(bar);
        }
        private static async Task<IResult> SetQuantity(QuantityModel qm, ApplicationContext db)
        {
            var bar = await db.BarModel.FirstOrDefaultAsync(u => u.Id == qm.Id);
            if (bar == null || qm.Quantity < 0)
            {
                return Results.Json("Not found");
            }
            bar.Quantity = qm.Quantity;
            await db.SaveChangesAsync();
            return Results.Json(bar);
        }
    }
}
