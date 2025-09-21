using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventotyClass;
using Data;
using Models;
using AutoMapper;

namespace Inventorys.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepresentantesController : ControllerBase
    {
        private readonly InventoryDbContext _context;
        private readonly IMapper _mapper;
        public RepresentantesController(InventoryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var result = await _context.Representantes.ToListAsync();
            if (result.Count == 0) return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> PostOne([FromBody] PostRepresentantes entity)
        {
            try
            {
                var newRepresentante = _mapper.Map<Representantes>(entity);
                var result = await _context.Representantes.AddAsync(newRepresentante);
                newRepresentante.Estado = true;
                await _context.SaveChangesAsync();
                var representante = await _context.Representantes
                .FirstOrDefaultAsync(s => s.Nombre == newRepresentante.Nombre && s.Estado == true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPut]
        public async Task<IActionResult> PutOne([FromBody] GetAllRepresentantes entity)
        {
            try
            {
                var representante = await _context.Representantes.FirstOrDefaultAsync(el => el.RepresentanteId == entity.RepresentanteId);
                if (representante == null) return NotFound();
                representante.Nombre = entity.Nombre;
                representante.PremirApellido = entity.PremirApellido;
                representante.SegundoApellido = entity.SegundoApellido;
                representante.Telefono = entity.Telefono;
                representante.Correo = entity.Correo;
                representante.Cargo = entity.Cargo;
                _context.Representantes.Update(representante);
                await _context.SaveChangesAsync();
                return Ok("Datos actualizados");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}