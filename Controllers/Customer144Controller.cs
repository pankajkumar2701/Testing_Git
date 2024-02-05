using Microsoft.AspNetCore.Mvc;
using Testing_Git.Model;
using Testing_Git.Data;
using Testing_Git.Filter;

namespace Testing_Git.Controllers
{
    /// <summary>
    /// Controller responsible for managing customer144-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting customer144 information.
    /// </remarks>
    [Route("api/[controller]")]
    public class Customer144Controller : ControllerBase
    {
        private readonly Testing_GitContext _context;

        public Customer144Controller(Testing_GitContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new customer144 to the database</summary>
        /// <param name="model">The customer144 data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Customer144 model)
        {
            _context.Customer144.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of customer144s based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"Property": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of customer144s</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Customer144.AsQueryable();
            var result = FilterService<Customer144>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific customer144 by its primary key</summary>
        /// <param name="entityId">The primary key of the customer144</param>
        /// <returns>The customer144 data</returns>
        [HttpGet]
        [Route("{entityId:Guid}")]
        public IActionResult GetById([FromRoute] Guid entityId)
        {
            var entityData = _context.Customer144.FirstOrDefault(entity => entity.CustomerId == entityId);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific customer144 by its primary key</summary>
        /// <param name="entityId">The primary key of the customer144</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [Route("{entityId:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid entityId)
        {
            var entityData = _context.Customer144.FirstOrDefault(entity => entity.CustomerId == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Customer144.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific customer144 by its primary key</summary>
        /// <param name="entityId">The primary key of the customer144</param>
        /// <param name="updatedEntity">The customer144 data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{entityId:Guid}")]
        public IActionResult UpdateById(Guid entityId, [FromBody] Customer144 updatedEntity)
        {
            if (entityId != updatedEntity.CustomerId)
            {
                return BadRequest("Mismatched CustomerId");
            }

            var entityData = _context.Customer144.FirstOrDefault(entity => entity.CustomerId == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            var propertiesToUpdate = typeof(Customer144).GetProperties().Where(property => property.Name != "CustomerId").ToList();
            foreach (var property in propertiesToUpdate)
            {
                property.SetValue(entityData, property.GetValue(updatedEntity));
            }

            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}