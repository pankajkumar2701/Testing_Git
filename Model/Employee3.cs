using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Testing_Git.Model
{
    /// <summary> 
    /// Represents a employee3 entity with essential details
    /// </summary>
    public class Employee3
    {
        /// <summary>
        /// Primary key for the Employee3 
        /// </summary>
        [Key]
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// FirstName of the Employee3 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// LastName of the Employee3 
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Department of the Employee3 
        /// </summary>
        public string Department { get; set; }
    }
}