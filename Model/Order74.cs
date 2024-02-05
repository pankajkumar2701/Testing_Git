using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Testing_Git.Model
{
    /// <summary> 
    /// Represents a order74 entity with essential details
    /// </summary>
    public class Order74
    {
        /// <summary>
        /// Primary key for the Order74 
        /// </summary>
        [Key]
        public Guid OrderID { get; set; }
        /// <summary>
        /// Foreign key referencing the Customer to which the Order74 belongs 
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Customer
        /// </summary>
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        /// <summary>
        /// TotalAmount of the Order74 
        /// </summary>
        public string TotalAmount { get; set; }
        /// <summary>
        /// Foreign key referencing the OrderStatus to which the Order74 belongs 
        /// </summary>
        public Guid OrderStatusId { get; set; }

        /// <summary>
        /// Navigation property representing the associated OrderStatus
        /// </summary>
        [ForeignKey("OrderStatusId")]
        public OrderStatus OrderStatus { get; set; }
    }
}