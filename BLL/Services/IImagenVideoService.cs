using GestorPublicidad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPublicidad.BLL.Services
{
    public interface IImagenVideoService
    {
        Task<bool> InsertImageVideo(ImagenVideo model);
        Task<bool> UpdateImageVideo(ImagenVideo model);
        Task<bool> DeleteImageVideo(int id);
        Task<ImagenVideo> GetOneImageVideo(int id);
        Task<IQueryable<ImagenVideo>> GetAllImageVideo();
    
    }
}
