using System;
using System.Collections.Generic;

namespace GestorPublicidad.Models;

public partial class ImagenVideo
{
    public int IdImagenVideo { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public string? Ubicacion { get; set; }

    public bool? Estado { get; set; }
}
