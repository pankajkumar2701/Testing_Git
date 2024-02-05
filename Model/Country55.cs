using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Testing_Git.Model
{
    /// <summary> 
    /// Represents a country55 entity with essential details
    /// </summary>
    public class Country55
    {
        /// <summary>
        /// Primary key for the Country55 
        /// </summary>
        [Key]
        public Guid CountryId { get; set; }
        /// <summary>
        /// Code of the Country55 
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Name of the Country55 
        /// </summary>
        public string Name { get; set; }
    }
}