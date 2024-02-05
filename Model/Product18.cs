using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Testing_Git.Model
{
    /// <summary> 
    /// Represents a product18 entity with essential details
    /// </summary>
    public class Product18
    {
        /// <summary>
        /// Primary key for the Product18 
        /// </summary>
        [Key]
        public Guid ProductId { get; set; }
        /// <summary>
        /// Name of the Product18 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Code of the Product18 
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Price of the Product18 
        /// </summary>
        public string Price { get; set; }
    }
}