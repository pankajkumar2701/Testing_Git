using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Testing_Git.Model
{
    /// <summary> 
    /// Represents a country1 entity with essential details
    /// </summary>
    public class Country1
    {
        /// <summary>
        /// Primary key for the Country1 
        /// </summary>
        [Key]
        public Guid CountryId { get; set; }
        /// <summary>
        /// Code of the Country1 
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Name of the Country1 
        /// </summary>
        public string Name { get; set; }
    }
}