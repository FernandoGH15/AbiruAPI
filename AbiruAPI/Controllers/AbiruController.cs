using AbiruAPI.Transfers;
using AbiruAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AbiruAPI.Controllers
{
    [EnableCors("ALIEXPRESSVUE")]
    [Route("api/[controller]")]
    [ApiController]
    public class AbiruController : ControllerBase
    {
        //Aqui van todos los controladores API necesarios para el funcionamiento
        //Controladores de Usuario (Registro, Login, Olvido)
        [HttpPost]
        [Route ("Registrar")]
        public UsuarioDT Registrar(UsuarioDT usuarioDT)
        {
            return Usuario.Registrar(usuarioDT);
        }
        //https://localhost:7048/api/Abiru/Registrar

        [HttpPost]
        [Route ("Login")]
        public UsuarioDT2 Login(UsuarioDT2 usuarioDT)
        {
            return Usuario.Login(usuarioDT);
        }
        //https://localhost:7048/api/Abiru/Login

        [HttpPost]
        [Route ("Olvido")]
        public UsuarioDT3 Olvido(UsuarioDT3 usuarioDT)
        {
            return Usuario.Olvido(usuarioDT);
        }
        //https://localhost:7048/api/Abiru/Olvido


        //Controladores de Distrito (Identificación)
        [HttpGet]
        [Route ("ListarDistrito")]
        public IEnumerable<DistritoDT> Listar()
        {
            return Distrito.Listado();
        }
        //https://localhost:7048/api/Abiru/ListarDistrito


        //Controladores de Colegio (se especifica)
        [HttpGet]
        [Route ("Recomendado")]
        public IEnumerable<ColegioDTB> Recomendado(int distrito)
        {
            return Colegio.Recomendado(distrito);
        }
        //https://localhost:7048/api/Abiru/Recomendado?distrito=15

        [HttpGet]
        [Route ("Detallado")]
        public ColegioDT Detallado (int id)
        {
            return Colegio.Detallado(id);
        }
        //https://localhost:7048/api/Abiru/Detallado?id=1



        //Controladores de UsuarioSearch (función adicional)

        [HttpGet]
        [Route ("Reciente")]
        public IEnumerable<UsuarioSearchDT> Reciente(int id)
        {
            return UsuarioSearch.Reciente(id);
        }

        //Controladores de Reclamos (teórico)
    }
}
