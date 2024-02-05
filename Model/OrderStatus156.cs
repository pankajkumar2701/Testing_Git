using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Testing_Git.Model
{
    /// <summary> 
    /// Represents a orderstatus156 entity with essential details
    /// </summary>
    public class OrderStatus156
    {
        /// <summary>
        /// Primary key for the OrderStatus156 
        /// </summary>
        [Key]
        public Guid OrderStatusId { get; set; }
        /// <summary>
        /// Name of the OrderStatus156 
        /// </summary>
        public string Name { get; set; }
    }
}