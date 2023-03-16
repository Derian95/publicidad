using AplicacionWeb.Models;
using GestorPublicidad.AplicacionWeb.Models.ViewModels;
using GestorPublicidad.BLL.Services;
using GestorPublicidad.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AplicacionWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IImagenVideoService _imagenVideoService;

        public HomeController(IImagenVideoService imagenVideoService)
        {
            _imagenVideoService = imagenVideoService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> ListDataInfo()
        {
            IQueryable<ImagenVideo> queryImagenVideoSQL = await _imagenVideoService.GetAllImageVideo();
            List<ImagenVideoVM> lista = queryImagenVideoSQL.Select(x => new ImagenVideoVM()
            {
                IdImagenVideo = x.IdImagenVideo,
                Titulo = x.Titulo,
                Descripcion = x.Descripcion,
                Ubicacion = x.Ubicacion,
                Estado = x.Estado,
            }).ToList();

            return StatusCode(StatusCodes.Status200OK,lista);
        }


        [HttpPost]
        public async Task<IActionResult> InsertDataInfo([FromBody] ImagenVideo model)
        {
            ImagenVideo newModel = new ImagenVideo()
            {
                Titulo= model.Titulo,
                Descripcion= model.Descripcion,
                Ubicacion= model.Ubicacion,
            };

            bool response = await _imagenVideoService.InsertImageVideo(newModel);

            return StatusCode(StatusCodes.Status200OK, new {value = response});
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDataInfo([FromBody] ImagenVideo model)
        {
            ImagenVideo newModel = new ImagenVideo()
            {
                Titulo = model.Titulo,
                Descripcion = model.Descripcion,
                Ubicacion = model.Ubicacion,
            };

            bool response = await _imagenVideoService.UpdateImageVideo(newModel);

            return StatusCode(StatusCodes.Status200OK, new { value = response });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInfo(int id)
        {

            bool response = await _imagenVideoService.DeleteImageVideo(id);

            return StatusCode(StatusCodes.Status200OK, new { value = response });
        }
    }
}