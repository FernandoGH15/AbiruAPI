using AbiruAPI.Transfers;

namespace AbiruAPI.Models
{
    public partial class Colegio
    {
        //Recomendación de Colegio x Distrito
        public static IEnumerable<ColegioDTB> Recomendado(int distrito)
        {
            AbiruContext db = new AbiruContext();
            return from b in db.Colegios.Where(a => a.Distrito.Equals(distrito))
                   select new ColegioDTB()
                   {
                       IdColegio = b.IdColegio,
                       Nombre = b.Nombre,
                       ImagenPrinc = b.ImagenPrinc
                   };
        }

        //Detallado de Colegio x ID
        public static ColegioDT Detallado (int id)
        {
            AbiruContext db = new AbiruContext();
            Colegio cole = db.Colegios.Find(id);
            return new ColegioDT()
            {
                Nombre = cole.Nombre,
                Distrito = (int)cole.Distrito,
                Vacantes = cole.Vacantes,
                Grado = cole.Grado,
                Tipo = cole.Tipo,
                Genero = cole.Genero,
                Costo = cole.Costo,
                Valoracion = cole.Valoracion,
                Direccion = cole.Direccion,
                DireccionX = cole.DireccionX,
                DireccionY = cole.DireccionY,
                Informacion = cole.Informacion,
                Mision = cole.Mision,
                Vision = cole.Vision,
                ImagenInfo = cole.ImagenInfo,
                ResenaA = cole.ResenaA,
                ResenaB = cole.ResenaB,
                ImagenResA = cole.ImagenResA,
                ImagenResB = cole.ImagenResB,
                Religion = cole.Religion,
                MallaCurricular = cole.MallaCurricular,
                Horario = cole.Horario,
                Reconocimiento = cole.Reconocimiento,
                ImagenRecoA = cole.ImagenRecoA,
                ImagenRecoB = cole.ImagenRecoB,
                ImagenRecoC = cole.ImagenRecoC,
                ImagenDirect = cole.ImagenDirect,
                ImagenFor = cole.ImagenFor

            };
        }
        //Busqueda Basica

        //Busqueda Compleja

        //Busqueda x Distrito


    }
}
