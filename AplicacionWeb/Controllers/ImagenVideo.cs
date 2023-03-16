using GestorPublicidad.AplicacionWeb.Models.ViewModels;
using GestorPublicidad.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestorPublicidad.AplicacionWeb.Controllers
{
    public class ImagenVideo : Controller
    {
        private readonly IImagenVideoService _imagenVideoService;

        public ImagenVideo(IImagenVideoService imagenVideoService)
        {
            _imagenVideoService= imagenVideoService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListDataInfo()
        {
            IQueryable<ImagenVideoVM> queryImagenVideoSQL = await _imagenVideoService.GetAllImageVideo();
            List<ImagenVideoVM> lsita = queryImagenVideoSQL.ToList();
        }
    }
}
