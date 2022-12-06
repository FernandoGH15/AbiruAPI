using AbiruAPI.Models;
using AbiruAPI.Transfers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AbiruAPI.Controllers
{
    [EnableCors("ABIRU")]
    [Route("api/[controller]")]
    [ApiController]
    public class AbiruController : ControllerBase
    {
        //Registro de usuario
        [HttpPost]
        [Route ("Registrar")]
        public UsuarioDT Registrar(UsuarioDT userDT)
        {
            return Usuario.Registrar(userDT);
        }

        //Login usuario (sin proteccion contra)
        [HttpPost]
        [Route ("Login")]
        public UsuarioDT2 Logeo(UsuarioDT2 userDT2)
        {
            return Usuario.Logearse(userDT2);
        }

        //Perdida de acceso
        [HttpPost]
        [Route ("Olvido")]
        public UsuarioDT Olvido(UsuarioDT userDT)
        {
            return Usuario.Olvidarse(userDT);
        }

        //Obtención de ultimas busquedas (prototipado)
        [HttpGet]
        [Route ("ShowLast")]
        public IEnumerable<ColegioDT2> Obtener(int userID)
        {
            return UsuarioSearch.Obtencion(userID);
        }

        //Mostrar colegios recomendados (base a distrito)
        [HttpGet]
        [Route ("ShowRecomendado")]
        public IEnumerable<ColegioDT2> Recomendado(int userID)
        {
            return Colegio.Recomendado(userID);
        }

        //Mostrar el detallado de un colegio (visualización por envio de variable)
        [HttpGet]
        [Route("Detallado")]
        public ColegioDT Detalle(int colID)
        {
            return Colegio.Detallado(colID);
        }

        //Resultados de busqueda básica
        [HttpGet]
        [Route("BusquedaB")]
        public IEnumerable<ColegioDT3> BusquedaB (string nombre, string grado, string tipo)
        {
            return Colegio.BusquedaB(nombre, grado, tipo);
        }




        //Listado distritos x nombres
        [HttpGet]
        [Route("ListaDist")]
        public IEnumerable<DistritoDT> ListaD()
        {
            return Distrito.Listado();
        }
    }
}
