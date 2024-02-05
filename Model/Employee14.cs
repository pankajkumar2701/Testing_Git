using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Testing_Git.Model
{
    /// <summary> 
    /// Represents a employee14 entity with essential details
    /// </summary>
    public class Employee14
    {
        /// <summary>
        /// Primary key for the Employee14 
        /// </summary>
        [Key]
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// FirstName of the Employee14 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// LastName of the Employee14 
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Department of the Employee14 
        /// </summary>
        public string Department { get; set; }
    }
}