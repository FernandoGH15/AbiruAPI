using AbiruAPI.Transfers;

namespace AbiruAPI.Models;

public partial class UsuarioSearch
{
    //Retorno de busquedas guardadas
    public static IEnumerable<ColegioDT2> Obtencion(int userID)
    {
        AbiruContext db = new AbiruContext();
        return from b in db.UsuarioSearches join c in db.Colegios on b.IdColegio equals c.IdColegio where b.IdUsuario == userID
               select new ColegioDT2()
               {
                   IdColegio = c.IdColegio,
                   Nombre = c.Nombre,
                   ImagenMain = c.ImagenMain
               };
    }
}


