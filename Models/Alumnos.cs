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
        public string Nombres { get; set; }
        [NotNull]
        public int Edad { get; set; }
        [NotNull]
        public string Carnet { get; set; }
        public int CantidaddMaterias { get; set; }
        public int ciclo { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [NotMapped]
        public string NombreCompleto { get; set; }
        #endregion Propiedades

        #region Constructor
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
