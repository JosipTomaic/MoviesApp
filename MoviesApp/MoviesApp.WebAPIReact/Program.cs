using MoviesApp.DAL;
using MoviesApp.Model;
using MoviesApp.Model.Common;
using MoviesApp.Repository;
using MoviesApp.Repository.Common;
using MoviesApp.Service;
using MoviesApp.Service.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MoviesAppContext>();

builder.Services.AddScoped<ITMDBService, TMDBService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMovieDomain, MovieDomain>();
builder.Services.AddScoped<IAPIMovie, APIMovie>();
builder.Services.AddScoped<IAPIMovieCredit, APIMovieCredit>();
builder.Services.AddScoped<IMovieGenreDomain, MovieGenreDomain>();
builder.Services.AddScoped<IMovieCreditDomain, MovieCreditDomain>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IMovieGenreRepository, MovieGenreRepository>();
builder.Services.AddScoped<IMovieCreditRepository, MovieCreditRepository>();
builder.Services.AddScoped<ICrewMemberRepository, CrewMemberRepository>();
builder.Services.AddScoped<ICrewMemberMovieCreditRepository, CrewMemberMovieCreditRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
        .WithOrigins("https://localhost:44419")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors("CorsPolicy");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
