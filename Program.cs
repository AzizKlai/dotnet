using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using tp3sqlite.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
//data base
SqliteConnection sqlite_conn;
// create a new database connection;
sqlite_conn = new SqliteConnection("Data Source=C:/Users/user/Documents/vscode proj/charpproj/tp2sqlite/src/database/TP3.db");
// Open the connection:
         try
         { 

            sqlite_conn.Open();
         }
        
catch (Exception ex)
         { 
         }
         
SqliteCommand sqlite_cmd;
sqlite_cmd=sqlite_conn.CreateCommand();
sqlite_cmd.CommandText="SELECT * FROM personal_info ";
//sqlite_cmd.ExecuteNonQuery();

SqliteDataReader sqlite_datareader;
sqlite_datareader =sqlite_cmd.ExecuteReader();
using(sqlite_datareader)
{
    while(sqlite_datareader.Read())
{  Int64 id=(Int64)sqlite_datareader["id"];
    string firstName=(string)sqlite_datareader["first_name"];
    string lastname=(string)sqlite_datareader["last_name"];
    string email=(string)sqlite_datareader["email"];
    string datebirth=(string)sqlite_datareader["date_birth"];
    string image=(string)sqlite_datareader["image"];
    string country=(string)sqlite_datareader["country"];
    Debug.WriteLine("id: {0} | firstname: {1} | email: {2} | datebirth: {5} | image: {3} | country: {4}",id,firstName,lastname,image,country,datebirth);

}
}

//Debug.WriteLine 
 sqlite_conn.Close();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
 
app.MapRazorPages();

app.Run();





//reverso