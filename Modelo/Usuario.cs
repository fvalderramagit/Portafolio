namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Helper;
    using System.Linq;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Web;
    using System.IO;
    using Model;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Experiencia = new HashSet<Experiencia>();
            Habilidad = new HashSet<Habilidad>();
            Testimonio = new HashSet<Testimonio>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(32)]
        public string Password { get; set; }

        [Column(TypeName = "text")]
        public string Direccion { get; set; }

        [StringLength(50)]
        public string Ciudad { get; set; }

        public int? Pais_id { get; set; }

        [StringLength(50)]
        public string Telefono { get; set; }

        [StringLength(100)]
        public string Facebook { get; set; }

        [StringLength(100)]
        public string Twitter { get; set; }

        [StringLength(100)]
        public string YouTube { get; set; }

        [StringLength(50)]
        public string Foto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Experiencia> Experiencia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Habilidad> Habilidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Testimonio> Testimonio { get; set; }


        //Se crea este metodo que valide la autenticacion del usuario
        public ResponseModel Acceder(string Email, string Password)  //este password es el que se captura en la vista
        {
            var rm = new ResponseModel();   //objeto rm para interpretar lo que el modelo quiere hacer (validar al usuario)

            try
            {
                using (var ctx = new contextPortafolioFAVP())  //abrir la conexion
                {
                    Password = HashHelper.MD5(Password);  //tiene el encriptado. Sobre escribir el metodo

                    //buscar el usuario por los criterios email y password que son los parametros del metodo
                    //agregar el using System.Linq para utilizar las sentencias sql como where;
                    var usuario = ctx.Usuario.Where(x => x.Email == Email)
                                             .Where(x => x.Password == Password)   //se compara el encriptado con el de la BD
                                             .SingleOrDefault();

                    if (usuario != null)  //si usuario no es igual a null 
                    {
                        SessionHelper.AddUserToSession(usuario.id.ToString());   //agregamos el usuario, su ID
                        rm.SetResponse(true);  //Que la respuesta es positiva. el rm.response lo colocamos true
                    }
                    else
                    {
                        rm.SetResponse(false, "Correo o contrase�a incorrecta");
                        // que la respuesta es falsa. es null si no lo encuentra en la BD y que saque este mensaje
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return rm;  //hacer el return del rm, de la respuesta true o false
        }
    }
}
