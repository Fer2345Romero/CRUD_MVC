using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CRUD_MVC.Models
{
    //Esta es la clase que representa la tabla Alumno en la BD
    public class Alumnos:BaseModel
    {
        #region Propiedades
        [Key]
        public int AlumnoId { get; set; }
        [NotNull]
        [Required(ErrorMessage = "El campo Nombres es requerido")]
        public string Nombres { get; set; }
        [NotNull]
        [Required(ErrorMessage = "El campo Apellidos es requerido")]
        public string Apellidos { get; set; }

        [NotNull]
        [Required(ErrorMessage = "El campo Edad es requerido")]
        public int Edad { get; set; }
        [NotNull]
        [Required(ErrorMessage = "El campo Carnet es requerido")]
        public string Carnet { get; set; }
        [Required(ErrorMessage = "El campo Cantidad de Materias es requerido")]
        public int CantidaddMaterias { get; set; }
        [Required(ErrorMessage = "El campo Ciclo es requerido")]
        public int ciclo { get; set; }
        [Required(ErrorMessage = "El campo Fecha de nacimiento es requerido")]
        public DateTime FechaNacimiento { get; set; }
        [NotMapped]
        public string NombreCompleto { get; set; }
        #endregion Propiedades




        #region Constructor
        public Alumnos()
        {
            FechaNacimiento = DateTime.Now.Date;
            IsActive = true;
            Created = DateTime.Now;
            CreateBy = "Admin";
        }
        public Alumnos(string nombres, int edad, string apellidos, DateTime fechaNacimiento)
        {
            Nombres = nombres;
            Edad = edad;
            Apellidos = apellidos;
            FechaNacimiento = fechaNacimiento;
            NombreCompleto = $"{Nombres} {Apellidos}";
        }
        #endregion Constructor

        #region Funciones
        public bool EsMayorDeEdad()
        {
            return Edad > 18;
        }
        #endregion


    }
}
