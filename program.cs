using System;
using System.Windows;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;

namespace SimpleBrowserApp
{
    public class Program : Application
    {
        [STAThread]
        public static void Main()
        {
            var app = new Program();
            app.Run();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var window = new Window
            {
                Title = "My Web App",
                Width = 1100,
                Height = 800
            };

            var webView = new WebView2();
            window.Content = webView;

            // Change this to your localhost or production domain
            string url = "http://192.168.1.173:3000/"; 
            // string url = "https://yourdomain.com";

            webView.Loaded += async (s, args) =>
            {
                await webView.EnsureCoreWebView2Async();
                webView.CoreWebView2.Navigate(url);
            };

            window.Show();
        }
    }
}
