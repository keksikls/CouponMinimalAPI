using Microsoft.AspNetCore.Mvc;
using WebApplication_CouponAPI;
using WebApplication_CouponAPI.Data;
using WebApplication_CouponAPI.Models;
using WebApplication_CouponAPI.Models.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/coupon", () => {
   return Results.Ok(CouponStore.couponslist);   
}).WithName("get coupon").Produces<Coupon>(200);

app.MapGet("/api/coupon/{id:int}", (int id) => {
    return Results.Ok(CouponStore.couponslist.FirstOrDefault(u => u.Id == id));
}).WithName("get coupons").Produces<IEnumerable<Coupon>>(200);

app.MapPost("/api/coupon", ([FromBody] CouponCreateDTO coupon_C_DTO) => {
    if (string.IsNullOrEmpty(coupon_C_DTO.Name))
    {
        return Results.BadRequest("Invalid Id or Coupon Name");
    }
    if (CouponStore.couponslist.FirstOrDefault(u => u.Name.ToLower() == coupon_C_DTO.Name.ToLower()) != null)
    {
        return Results.BadRequest("Coupon Name already Exists");
    }

    Coupon coupon = new()
    {
        IsActive = coupon_C_DTO.IsActive,
        Name = coupon_C_DTO.Name,
        Percent = coupon_C_DTO.Percent
    };

    coupon.Id = CouponStore.couponslist.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
    CouponStore.couponslist.Add(coupon);

    CouponDTO couponDTO = new()
    {
        Id = coupon.Id,
        IsActive = coupon.IsActive,
        Name = coupon.Name,
        Percent = coupon.Percent,
        Created = coupon.Created
    };
    return Results.CreatedAtRoute("GetCoupon", new { id = coupon.Id }, couponDTO);
}).WithName("CreateCoupon").Accepts<CouponCreateDTO>("application/json").Produces<CouponDTO>(201).Produces(400);

//app.MapPut("/api/coupon", () => {

//}).WithName("Create coupon");

app.MapDelete("/api/coupon/{id:int}", (int id) => {

}).WithName("Delete coupon");

app.UseHttpsRedirection(); 

app.Run();


