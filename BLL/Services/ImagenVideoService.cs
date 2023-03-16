using GestorPublicidad.DAL.Repositories;
using GestorPublicidad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPublicidad.BLL.Services
{
    public class ImagenVideoService : IImagenVideoService
    {
        private readonly IGenericRepository<ImagenVideo> _imagenVideoRepository;
        public ImagenVideoService(IGenericRepository<ImagenVideo> imagenVideoRepo)
        {
            _imagenVideoRepository= imagenVideoRepo;
        }
        public async Task<bool> DeleteImageVideo(int id)
        {
            return await _imagenVideoRepository.Delete(id);
        }

        public async Task<IQueryable<ImagenVideo>> GetAllImageVideo()
        {
            return await _imagenVideoRepository.GetAll();

        }

        public async Task<ImagenVideo> GetOneImageVideo(int id)
        {
            return await _imagenVideoRepository.GetOne(id);
        }

        public async Task<bool> InsertImageVideo(ImagenVideo model)
        {
            return await _imagenVideoRepository.Insert(model);
        }

        public async Task<bool> UpdateImageVideo(ImagenVideo model)
        {
            return await _imagenVideoRepository.Update(model);
        }
    }
}
