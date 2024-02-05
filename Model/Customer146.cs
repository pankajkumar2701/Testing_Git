using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Testing_Git.Model
{
    /// <summary> 
    /// Represents a customer146 entity with essential details
    /// </summary>
    public class Customer146
    {
        /// <summary>
        /// Primary key for the Customer146 
        /// </summary>
        [Key]
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Name of the Customer146 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Address of the Customer146 
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// CountryName of the Customer146 
        /// </summary>
        public string CountryName { get; set; }
    }
}