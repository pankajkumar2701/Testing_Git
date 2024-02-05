using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Testing_Git.Model
{
    /// <summary> 
    /// Represents a employee entity with essential details
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Primary key for the Employee 
        /// </summary>
        [Key]
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// FirstName of the Employee 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// LastName of the Employee 
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Department of the Employee 
        /// </summary>
        public string Department { get; set; }
    }
}