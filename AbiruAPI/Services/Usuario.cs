using AbiruAPI.Transfers;
using System.Linq;

namespace AbiruAPI.Models
{
    public partial class Usuario
    {
        //Registro de Usuario
        public static UsuarioDT Registrar(UsuarioDT userDT)
        {
            AbiruContext db = new AbiruContext();
            Usuario uDT = new Usuario()
            {
                Nombre = userDT.Nombre,
                Dni = userDT.Dni,
                Email = userDT.Email,
                Distrito = userDT.Distrito,
                Pass = userDT.Pass,
                Categoria = userDT.Categoria
            };
            db.Usuarios.Add(uDT);
            db.SaveChanges();
            userDT.ID = uDT.IdUser;
            return userDT;
        }
        //Procedimiento de login
        public static UsuarioDT2 Logearse(UsuarioDT2 userDT)
        {
            AbiruContext db = new AbiruContext();
            Usuario uDT = db.Usuarios.Where(a => a.Email.Equals(userDT.Email) && a.Pass.Equals(userDT.Pass)).FirstOrDefault();
            if (uDT == null)
                return null;
            else
                return new UsuarioDT2()
                {
                    ID = uDT.IdUser,
                    Categoria = uDT.Categoria,
                    Nombre = uDT.Nombre
                };
        }
        //Procedimiento de olvide contraseña
        public static UsuarioDT Olvidarse(UsuarioDT userDT)
        {
            AbiruContext db = new AbiruContext();
            Usuario uDT = db.Usuarios.Where(a => a.Email.Equals(userDT.Email) || a.Nombre.Equals(userDT.Nombre)).FirstOrDefault();
            if (uDT == null)
                return null;
            else
                return new UsuarioDT()
                {
                    Email = uDT.Email,
                    Nombre = uDT.Nombre
                };
        }  

    }
}
