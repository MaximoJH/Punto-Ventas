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
    public class SuplidoresController : ControllerBase
    {
        private readonly InventoryDbContext _context;
        private readonly IMapper _mapper;
        public SuplidoresController(InventoryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllSuplidores>>> GetAll()
        {
            var suplidores = await _context.Suplidores.ToListAsync();

            if (suplidores == null)
                return NotFound();
            var result = _mapper.Map<List<GetAllSuplidores>>(suplidores);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<GetAllSuplidores>> PostOne([FromBody] PostSuplidores entity)
        {
            var newSuplidor = _mapper.Map<Suplidores>(entity);
            newSuplidor.Estado = newSuplidor.Estado = "Activo";
            await _context.AddAsync(newSuplidor);
            await _context.SaveChangesAsync();
            var suplidores = await _context.Suplidores
                .FirstOrDefaultAsync(s => s.NombreEmpresa == newSuplidor.NombreEmpresa && s.Estado == "Activo");
            return Ok(_mapper.Map<GetAllSuplidores>(suplidores));
        }
        [HttpPatch]
        public async Task<ActionResult> ChangeStatus([FromBody] ChangeStatusSuplidores entity)
        {
            if ((entity is null) || (entity.SuplidorId <= 0) || string.IsNullOrWhiteSpace(entity.Estado)) return BadRequest();
            var suplidor = await _context.Suplidores.FirstOrDefaultAsync(e => e.SuplidorId == entity.SuplidorId);
            if (suplidor == null) return NotFound();
            suplidor.Estado = entity.Estado;
            _context.Suplidores.Update(suplidor);
            await _context.SaveChangesAsync();
            return Ok(entity);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateOne([FromBody] GetAllSuplidores entity)
        {
            if (entity == null) return BadRequest();
            var suplidor = await _context.Suplidores.FirstOrDefaultAsync
            (
                e => e.SuplidorId == entity.SuplidorId
            );
            if (suplidor == null) return NotFound();
            suplidor.NombreEmpresa = entity.NombreEmpresa;
            suplidor.Direccion = entity.Direccion;
            suplidor.Telefono = entity.Telefono;
            suplidor.Correo = entity.Correo;
            suplidor.PaginaWeb = entity.PaginaWeb;
            
            _context.Suplidores.Update(suplidor);
            await _context.SaveChangesAsync();
            return Ok("Datos actualizados");
        }
    }
}