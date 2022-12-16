using AbiruAPI.Transfers;

namespace AbiruAPI.Models
{
    public partial class Usuario
    {
        //Registro de usuario
        public static UsuarioDT Registrar(UsuarioDT userDT)
        { 
            AbiruContext db = new AbiruContext();
            Usuario user = new Usuario()
            {
                Nombre = userDT.Nombre,
                Apellido = userDT.Apellido,
                Distrito = userDT.Distrito,
                Dni = userDT.Dni,
                Correo = userDT.Correo,
                Pass = userDT.Pass                                                                                                                                                          
            };
            db.Usuarios.Add(user);
            db.SaveChanges();
            userDT.IdUsuario = user.IdUsuario;
            return userDT;
        }

        //Login de usuario

        public static UsuarioDT2 Login (UsuarioDT2 userDT)
        {
            AbiruContext db = new AbiruContext();
            Usuario user = db.Usuarios.Where(a => a.Correo.Equals(userDT.Correo) && a.Pass.Equals(userDT.Pass)).FirstOrDefault();
            if (user == null)
                return null;
            else
                return new UsuarioDT2()
                {
                    IdUsuario = user.IdUsuario,
                    Nombre  =   user.Nombre,
                    Apellido =  user.Apellido,
                    Distrito = (int)user.Distrito
                };  
        }
      
        //Olvide de usuario
        public static UsuarioDT3 Olvido (UsuarioDT3 userDT)
        {
            AbiruContext db = new AbiruContext();
            Usuario user = db.Usuarios.Where(a => a.Dni.Equals(userDT.Dni) || a.Correo.Equals(userDT.Correo)).FirstOrDefault();
            if (user == null)
                return null;
            else
                return new UsuarioDT3()
                {
                    Pass = user.Pass
                };
        }
    }
}
