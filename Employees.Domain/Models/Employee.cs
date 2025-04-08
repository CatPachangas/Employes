using Newtonsoft.Json;

namespace Employees.Domain.Models
{
    /// <summary>
    /// Clase que define el objeto empleado
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Id empleado
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Nombre completo del empleado
        /// </summary>
        [JsonProperty("employee_name")]
        public string Name { get; set; }

        /// <summary>
        /// Valor del salario del empleado
        /// </summary>
        [JsonProperty("employee_salary")]
        public double Salary { get; set; }

        /// <summary>
        /// Edad del empleado
        /// </summary>
        [JsonProperty("employee_age")]
        public int Age { get; set; }

        /// <summary>
        /// Imagen base 64
        /// </summary>
        [JsonProperty("profile_image")]
        public string? Image { get; set; }

        /// <summary>
        /// Salario anual
        /// </summary>
        public double AnnualSalary { get; set; }

    }
}