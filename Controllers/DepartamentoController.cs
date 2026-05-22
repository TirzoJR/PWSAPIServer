using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PWSAPIServer.Models;
using PWSAPIShare;


namespace PWS26Api.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly BdPws2026Context _dbContext;

        public DepartamentoController(BdPws2026Context dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponsiveAPI<List<DepartamentoDTO>>();
            var listaDepartamentoDTO = new List<DepartamentoDTO>();
            try
            {
                foreach (var item in await _dbContext.TbEmpleados.Include(d => d.IdDepartamentoNavigation).ToListAsync())
                {
                    listaDepartamentoDTO.Add(new DepartamentoDTO
                    {
                        IdDepartamento = item.IdDepartamento,
                        Nombre = item.NombreCompleto,
                    });
                }
                responseApi.EsCorrecto = true;
                responseApi.Valor = listaDepartamentoDTO;
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }
    }
}