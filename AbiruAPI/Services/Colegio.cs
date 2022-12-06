using AbiruAPI.Transfers;

namespace AbiruAPI.Models;

public partial class Colegio
{
    //Mostrar recomendados
    public static IEnumerable<ColegioDT2> Recomendado(int userID)
    {
        AbiruContext db = new AbiruContext();
        int distrito = (int)db.Usuarios.Where(a => a.IdUser.Equals(userID)).FirstOrDefault().Distrito;
        int distID = distrito;
        return from b in db.Colegios.Where(a => a.Distrito.Equals(distID))
               select new ColegioDT2()
               {
                   IdColegio = b.IdColegio,
                   Nombre = b.Nombre,
                   ImagenMain = b.ImagenMain
               };
    }

    //Busqueda de colegio por parametros mínimo
    public static IEnumerable<ColegioDT3> BusquedaB(string nombre, string grado, string tipo)
    {
        AbiruContext db = new AbiruContext();
        return from b in db.Colegios
               join c in db.Distritos on b.Distrito equals c.IdDist
               where (b.Nombre.Contains(nombre) && b.Grado.Contains(grado) && b.Tipo.Contains(tipo))
               select new ColegioDT3()
               {
                   Nombre = b.Nombre,
                   Distrito = c.Nombre,
                   Tipo = b.Tipo,
                   Grado = b.Grado,
                   Cupos = (int)b.Cupos
               };
    }

    //Busqueda de colegio por parametros máximo

    //Busqueda de colegio por distrito

    //Detallado específico de colegio
    public static ColegioDT Detallado(int idCol)
    {
        AbiruContext db = new AbiruContext();
        Colegio col = db.Colegios.Find(idCol);
        return new ColegioDT()
        {
            Nombre = col.Nombre,
            Grado = col.Grado,
            Tipo = col.Tipo,
            Distrito = (int)col.Distrito,
            Cupos = (int)col.Cupos,
            Direccion = col.Direccion,
            UbicacionLat = (decimal)col.UbicacionLat,
            UbicacionLong = (decimal)col.UbicacionLong,
            Valoracion = (int)col.Valoracion,
            Matricula = col.Matricula,
            Resena1 = col.Resena1,
            Resena2 = col.Resena2,
            Reconocimientos = col.Reconocimientos,
            Galeria = col.Galeria,
            GaleriaNum = (int)col.GaleriaNum,
            MallaCurr = col.MallaCurr,
            Costo = (decimal)col.Costo
        };
    }
}
