using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Testing_Git.Model
{
    /// <summary> 
    /// Represents a country16 entity with essential details
    /// </summary>
    public class Country16
    {
        /// <summary>
        /// Primary key for the Country16 
        /// </summary>
        [Key]
        public Guid CountryId { get; set; }
        /// <summary>
        /// Code of the Country16 
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Name of the Country16 
        /// </summary>
        public string Name { get; set; }
    }
}