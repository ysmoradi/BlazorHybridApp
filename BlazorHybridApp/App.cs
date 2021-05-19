using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.MobileBlazorBindings;
using Xamarin.Forms;

namespace BlazorHybridApp
{
    public class App : Application
    {
        public App(IFileProvider fileProvider)
        {
            var hostBuilder = MobileBlazorBindingsHost.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddBlazorHybrid();
                })
                .UseWebRoot("wwwroot");

            hostBuilder.UseStaticFiles(fileProvider);

            var host = hostBuilder.Build();

            MainPage = new ContentPage { Title = "My Application" };

            host.AddComponent<Main>(parent: MainPage);
        }
    }
}
