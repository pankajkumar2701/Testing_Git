using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Testing_Git.Model
{
    /// <summary> 
    /// Represents a employee146 entity with essential details
    /// </summary>
    public class Employee146
    {
        /// <summary>
        /// Primary key for the Employee146 
        /// </summary>
        [Key]
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// FirstName of the Employee146 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// LastName of the Employee146 
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Department of the Employee146 
        /// </summary>
        public string Department { get; set; }
    }
}