using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Testing_Git.Model
{
    /// <summary> 
    /// Represents a employee116 entity with essential details
    /// </summary>
    public class Employee116
    {
        /// <summary>
        /// Primary key for the Employee116 
        /// </summary>
        [Key]
        public Guid EmployeeId1 { get; set; }
        /// <summary>
        /// FirstName1 of the Employee116 
        /// </summary>
        public string FirstName1 { get; set; }
        /// <summary>
        /// LastName1 of the Employee116 
        /// </summary>
        public string LastName1 { get; set; }
        /// <summary>
        /// Department of the Employee116 
        /// </summary>
        public string Department { get; set; }
    }
}