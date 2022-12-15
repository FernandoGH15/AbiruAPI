using AbiruAPI.Transfers;

namespace AbiruAPI.Models
{
    public partial class UsuarioSearch
    {
        //Usuario Search Reciente (parte izquierda dentro del sistema)
        public static IEnumerable<UsuarioSearchDT> Reciente(int idUser)
        {
            AbiruContext db = new AbiruContext();
            return from b in db.Colegios join c in db.UsuarioSearches on b.IdColegio equals c.IdColegio where c.IdUsuario == idUser
                   select new UsuarioSearchDT()
                   {
                       IdColegio = b.IdColegio,
                       Nombre = b.Nombre,
                       ImagenPrinc = b.ImagenPrinc
                   };
        }


        //Agregar una busqueda reciente
        public static void Agregar (int idUser, int idCole)
        {
            AbiruContext db = new AbiruContext();
            UsuarioSearch usearch = new UsuarioSearch()
            {
                IdColegio = idCole,
                IdUsuario = idUser
            };
            db.UsuarioSearches.Add(usearch);
            db.SaveChanges();
        }

        //Quitar una busqueda reciente
        public static void Eliminar(int idUser, int idCole)
        {
            AbiruContext db = new AbiruContext();
            UsuarioSearch usearch = db.UsuarioSearches.Where(a=> a.IdUsuario==idUser && a.IdColegio == idCole).FirstOrDefault();
            db.UsuarioSearches.Remove(usearch);
            db.SaveChanges();
        }
    }
}
