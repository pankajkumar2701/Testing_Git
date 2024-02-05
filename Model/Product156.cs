using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Testing_Git.Model
{
    /// <summary> 
    /// Represents a product156 entity with essential details
    /// </summary>
    public class Product156
    {
        /// <summary>
        /// Primary key for the Product156 
        /// </summary>
        [Key]
        public Guid ProductId { get; set; }
        /// <summary>
        /// Name of the Product156 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Code of the Product156 
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Price of the Product156 
        /// </summary>
        public string Price { get; set; }
    }
}