﻿using BoardGameBrawl.App.Hubs;
using BoardGameBrawl.Infrastructure;

namespace BoardGameBrawl.App
{
    public static class SetupMiddlewarePipeline
    {
        public static WebApplication SetupMiddleware(this WebApplication app)
        {
            // Configure the HTTP request pipeline.

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            // mapping SignalR Hubs 

            app.MapHub<TimeSlotHub>("/timeSlotHub");
            
            //app.SeedSQLDatabases();

            return app;
        }
    }
}
