using ITI_Project.Data;
using ITI_Project.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.AI;
using OpenAI;
using System.ClientModel;


namespace ITI_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //Edit 
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
            });

            var openAiClient = new OpenAIClient(
                new ApiKeyCredential(
                    builder.Configuration.GetSection("AI")["ApiKey"]!),

                new OpenAIClientOptions { Endpoint = new Uri(builder.Configuration.GetSection("AI")["BaseUrl"]!) }
                );

            var chatClient = openAiClient.GetChatClient(builder.Configuration.GetSection("AI")["Model"]!);

            builder.Services.AddSingleton(chatClient);

            builder.Services.AddScoped<LibraryTool>();

            builder.Services.AddSingleton<IChatClient>(
                new ChatClientBuilder(chatClient.AsIChatClient()).UseFunctionInvocation().Build()
                );

            

            // =================================



            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("constr")));
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Member/Login";
                options.AccessDeniedPath = "/Member/AccessDenied";
                options.ExpireTimeSpan = TimeSpan.FromDays(7);
                options.SlidingExpiration = true;
            });

            builder.Services.AddAuthorization();
            builder.Services.AddScoped<IAiService, AiService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/Home/NotFound");

            app.UseHttpsRedirection();
            app.UseRouting();

            // ?? «· ⁄œÌ· «·√”«”Ì:  ›⁄Ì· Session Middleware ﬁ»· Authentication Ê Authorization
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Book}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
