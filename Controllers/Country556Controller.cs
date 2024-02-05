using Microsoft.AspNetCore.Mvc;
using Testing_Git.Model;
using Testing_Git.Data;
using Testing_Git.Filter;

namespace Testing_Git.Controllers
{
    /// <summary>
    /// Controller responsible for managing country556-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting country556 information.
    /// </remarks>
    [Route("api/[controller]")]
    public class Country556Controller : ControllerBase
    {
        private readonly Testing_GitContext _context;

        public Country556Controller(Testing_GitContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new country556 to the database</summary>
        /// <param name="model">The country556 data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Country556 model)
        {
            _context.Country556.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of country556s based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"Property": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of country556s</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Country556.AsQueryable();
            var result = FilterService<Country556>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific country556 by its primary key</summary>
        /// <param name="entityId">The primary key of the country556</param>
        /// <returns>The country556 data</returns>
        [HttpGet]
        [Route("{entityId:Guid}")]
        public IActionResult GetById([FromRoute] Guid entityId)
        {
            var entityData = _context.Country556.FirstOrDefault(entity => entity.CountryId == entityId);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific country556 by its primary key</summary>
        /// <param name="entityId">The primary key of the country556</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [Route("{entityId:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid entityId)
        {
            var entityData = _context.Country556.FirstOrDefault(entity => entity.CountryId == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Country556.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific country556 by its primary key</summary>
        /// <param name="entityId">The primary key of the country556</param>
        /// <param name="updatedEntity">The country556 data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{entityId:Guid}")]
        public IActionResult UpdateById(Guid entityId, [FromBody] Country556 updatedEntity)
        {
            if (entityId != updatedEntity.CountryId)
            {
                return BadRequest("Mismatched CountryId");
            }

            var entityData = _context.Country556.FirstOrDefault(entity => entity.CountryId == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            var propertiesToUpdate = typeof(Country556).GetProperties().Where(property => property.Name != "CountryId").ToList();
            foreach (var property in propertiesToUpdate)
            {
                property.SetValue(entityData, property.GetValue(updatedEntity));
            }

            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}