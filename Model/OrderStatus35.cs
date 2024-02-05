using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Testing_Git.Model
{
    /// <summary> 
    /// Represents a orderstatus35 entity with essential details
    /// </summary>
    public class OrderStatus35
    {
        /// <summary>
        /// Primary key for the OrderStatus35 
        /// </summary>
        [Key]
        public Guid OrderStatusId { get; set; }
        /// <summary>
        /// Name of the OrderStatus35 
        /// </summary>
        public string Name { get; set; }
    }
}