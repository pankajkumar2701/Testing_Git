using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Testing_Git.Model
{
    /// <summary> 
    /// Represents a product164 entity with essential details
    /// </summary>
    public class Product164
    {
        /// <summary>
        /// Primary key for the Product164 
        /// </summary>
        [Key]
        public Guid ProductId { get; set; }
        /// <summary>
        /// Name of the Product164 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Code of the Product164 
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Price of the Product164 
        /// </summary>
        public string Price { get; set; }
    }
}