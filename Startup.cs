// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Azure.SignalR.Samples.ChatRoom
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            //string dbConn2 = configuration.GetValue<string>("MySettings:DbConnection");
            services.AddSignalR()
                    .AddAzureSignalR(@"Endpoint=https://sigservice.service.signalr.net;AccessKey=RUoeGhjeERwGP3gak32YhKFRaz7QIbj0zgERSeO6VJc=;Version=1.0;");

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatSampleHub>("/chat");
            });
        }
    }
}
