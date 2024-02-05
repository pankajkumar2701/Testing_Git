using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Testing_Git.Model
{
    /// <summary> 
    /// Represents a product114 entity with essential details
    /// </summary>
    public class Product114
    {
        /// <summary>
        /// Primary key for the Product114 
        /// </summary>
        [Key]
        public Guid ProductId { get; set; }
        /// <summary>
        /// Name of the Product114 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Code of the Product114 
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Price of the Product114 
        /// </summary>
        public string Price { get; set; }
    }
}