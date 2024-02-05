using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Testing_Git.Model
{
    /// <summary> 
    /// Represents a sales21 entity with essential details
    /// </summary>
    public class Sales21
    {
        /// <summary>
        /// Primary key for the Sales21 
        /// </summary>
        [Key]
        public Guid SalesId { get; set; }
        /// <summary>
        /// Name of the Sales21 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Foreign key referencing the Product to which the Sales21 belongs 
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        /// <summary>
        /// CustomerId of the Sales21 
        /// </summary>
        public string CustomerId { get; set; }
    }
}