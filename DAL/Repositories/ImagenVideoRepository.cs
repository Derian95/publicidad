using GestorPublicidad.DAL.DataContext;
using GestorPublicidad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPublicidad.DAL.Repositories
{
    public class ImagenVideoRepository : IGenericRepository<ImagenVideo>
    {
        private readonly S3kGestorPublicidadContext _dbContext;
        public ImagenVideoRepository(S3kGestorPublicidadContext context)
        {
            _dbContext= context;
        }
        public async Task<bool> Delete(int id)
        {
            ImagenVideo imagenVideovideo = _dbContext.ImagenVideos.First(x=>x.IdImagenVideo ==id);
            _dbContext.ImagenVideos.Remove(imagenVideovideo);
            await _dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<IQueryable<ImagenVideo>> GetAll()
        {
            IQueryable<ImagenVideo> queryImagenVideo = _dbContext.ImagenVideos;
            return  queryImagenVideo;
        }

        public async Task<ImagenVideo> GetOne(int id)
        {

            return await _dbContext.ImagenVideos.FindAsync(id);
        }

        public async Task<bool> Insert(ImagenVideo model)
        {
            _dbContext.ImagenVideos.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(ImagenVideo model)
        {
            _dbContext.Update(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
