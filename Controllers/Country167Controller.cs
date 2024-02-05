using Microsoft.AspNetCore.Mvc;
using Testing_Git.Model;
using Testing_Git.Data;
using Testing_Git.Filter;

namespace Testing_Git.Controllers
{
    /// <summary>
    /// Controller responsible for managing country167-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting country167 information.
    /// </remarks>
    [Route("api/[controller]")]
    public class Country167Controller : ControllerBase
    {
        private readonly Testing_GitContext _context;

        public Country167Controller(Testing_GitContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new country167 to the database</summary>
        /// <param name="model">The country167 data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Country167 model)
        {
            _context.Country167.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of country167s based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"Property": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of country167s</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Country167.AsQueryable();
            var result = FilterService<Country167>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific country167 by its primary key</summary>
        /// <param name="entityId">The primary key of the country167</param>
        /// <returns>The country167 data</returns>
        [HttpGet]
        [Route("{entityId:Guid}")]
        public IActionResult GetById([FromRoute] Guid entityId)
        {
            var entityData = _context.Country167.FirstOrDefault(entity => entity.CountryId == entityId);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific country167 by its primary key</summary>
        /// <param name="entityId">The primary key of the country167</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [Route("{entityId:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid entityId)
        {
            var entityData = _context.Country167.FirstOrDefault(entity => entity.CountryId == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Country167.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific country167 by its primary key</summary>
        /// <param name="entityId">The primary key of the country167</param>
        /// <param name="updatedEntity">The country167 data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{entityId:Guid}")]
        public IActionResult UpdateById(Guid entityId, [FromBody] Country167 updatedEntity)
        {
            if (entityId != updatedEntity.CountryId)
            {
                return BadRequest("Mismatched CountryId");
            }

            var entityData = _context.Country167.FirstOrDefault(entity => entity.CountryId == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            var propertiesToUpdate = typeof(Country167).GetProperties().Where(property => property.Name != "CountryId").ToList();
            foreach (var property in propertiesToUpdate)
            {
                property.SetValue(entityData, property.GetValue(updatedEntity));
            }

            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}