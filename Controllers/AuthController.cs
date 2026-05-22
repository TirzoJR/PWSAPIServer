using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PWSAPIServer.Models;
using PWSAPIShare;

namespace PWS26Api.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly BdPws2026Context _dbContext;

        public AuthController(BdPws2026Context dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] TbUsuario loginUser)
        {
            var responseApi = new ResponsiveAPI<string>();

            try
            {
                // Busca al usuario que coincida con el nombre y contraseña, y que esté activo
                var dbUsuario = await _dbContext.TbUsuarios.FirstOrDefaultAsync(x =>
                    x.Usuario == loginUser.Usuario &&
                    x.Pass == loginUser.Pass &&
                    x.Activo == true);

                if (dbUsuario != null)
                {
                    responseApi.EsCorrecto = true;
                    // En un escenario real aquí devolverías un token JWT. 
                    // Para este ejercicio devolvemos un mensaje de éxito.
                    responseApi.Valor = "Autenticación exitosa. Bienvenido " + dbUsuario.Usuario;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Credenciales incorrectas o usuario inactivo.";
                }
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