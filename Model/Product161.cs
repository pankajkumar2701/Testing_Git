using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Testing_Git.Model
{
    /// <summary> 
    /// Represents a product161 entity with essential details
    /// </summary>
    public class Product161
    {
        /// <summary>
        /// Primary key for the Product161 
        /// </summary>
        [Key]
        public Guid ProductId { get; set; }
        /// <summary>
        /// Name of the Product161 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Code of the Product161 
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Price of the Product161 
        /// </summary>
        public string Price { get; set; }
    }
}