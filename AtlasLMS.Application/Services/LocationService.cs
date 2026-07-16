using AtlasLMS.Data;
using AutoMapper;

namespace AtlasLMS.Application.Services;

public class LocationService
{
    private readonly IMapper _mapper;
    private readonly AtlasDbContext _context;

    public LocationService(IMapper mapper, AtlasDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    //Obtener todas las ubicaciones de la libreria
    //Obtener una ubicacion en concreto

}