using Microsoft.OpenApi.Models;

namespace WebApiProject
{
    internal class Info : OpenApiInfo
    {
        public string Version { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}