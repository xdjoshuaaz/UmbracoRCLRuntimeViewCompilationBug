using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace RCL
{
    public class Composer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
            {
                options.FileProviders.Add(new PhysicalFileProvider(RclDirectory()));
            });
        }

        // path automagically injected by c# compiler using CallerFilePath attribute
        public static string RclDirectory([CallerFilePath] string path = null!) => Path.GetDirectoryName(path)!;
    }
}