using AbiruAPI.Transfers;

namespace AbiruAPI.Models
{
    public partial class Distrito
    {
        //Mostrar lista de distritos

        public static IEnumerable<DistritoDT> Listado()
        {
            AbiruContext db = new AbiruContext();
            return from b in db.Distritos
                   select new DistritoDT()
                   {
                       IdDist = b.IdDist,
                       Nombre = b.Nombre
                   };
        }
    }
}
