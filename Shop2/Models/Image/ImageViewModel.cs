using Microsoft.AspNetCore.Http;

namespace Shop2.Models.Image
{
    public class ImageViewModel
    {
        public string Name { get; set; }
        public IFormFile ImageProduct { get; set; }
    }
}
