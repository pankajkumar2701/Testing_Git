using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Testing_Git.Model
{
    /// <summary> 
    /// Represents a 56 entity with essential details
    /// </summary>
    public class 56
    {
        /// <summary>
        /// Primary key for the 56 
        /// </summary>
        [Key]
        public Guid OrderStatusId { get; set; }
        /// <summary>
        /// Name of the 56 
        /// </summary>
        public string Name { get; set; }
    }
}