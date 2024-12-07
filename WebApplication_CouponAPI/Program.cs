using WebApplication_CouponAPI.Data;

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
});

app.MapGet("/api/coupon/{id:int}", (int id) => {
    return Results.Ok(CouponStore.couponslist.FirstOrDefault(u => u.Id == id));
});

app.UseHttpsRedirection(); 

app.Run();

