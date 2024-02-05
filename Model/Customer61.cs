using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Testing_Git.Model
{
    /// <summary> 
    /// Represents a customer61 entity with essential details
    /// </summary>
    public class Customer61
    {
        /// <summary>
        /// Primary key for the Customer61 
        /// </summary>
        [Key]
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Name of the Customer61 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Address of the Customer61 
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// CountryName of the Customer61 
        /// </summary>
        public string CountryName { get; set; }
    }
}