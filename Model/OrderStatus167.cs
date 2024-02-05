using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Testing_Git.Model
{
    /// <summary> 
    /// Represents a orderstatus167 entity with essential details
    /// </summary>
    public class OrderStatus167
    {
        /// <summary>
        /// Primary key for the OrderStatus167 
        /// </summary>
        [Key]
        public Guid OrderStatusId { get; set; }
        /// <summary>
        /// Name of the OrderStatus167 
        /// </summary>
        public string Name { get; set; }
    }
}