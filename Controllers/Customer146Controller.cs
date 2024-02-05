using Microsoft.AspNetCore.Mvc;
using Testing_Git.Model;
using Testing_Git.Data;
using Testing_Git.Filter;

namespace Testing_Git.Controllers
{
    /// <summary>
    /// Controller responsible for managing customer146-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting customer146 information.
    /// </remarks>
    [Route("api/[controller]")]
    public class Customer146Controller : ControllerBase
    {
        private readonly Testing_GitContext _context;

        public Customer146Controller(Testing_GitContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new customer146 to the database</summary>
        /// <param name="model">The customer146 data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Customer146 model)
        {
            _context.Customer146.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of customer146s based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"Property": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of customer146s</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Customer146.AsQueryable();
            var result = FilterService<Customer146>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific customer146 by its primary key</summary>
        /// <param name="entityId">The primary key of the customer146</param>
        /// <returns>The customer146 data</returns>
        [HttpGet]
        [Route("{entityId:Guid}")]
        public IActionResult GetById([FromRoute] Guid entityId)
        {
            var entityData = _context.Customer146.FirstOrDefault(entity => entity.CustomerId == entityId);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific customer146 by its primary key</summary>
        /// <param name="entityId">The primary key of the customer146</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [Route("{entityId:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid entityId)
        {
            var entityData = _context.Customer146.FirstOrDefault(entity => entity.CustomerId == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Customer146.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific customer146 by its primary key</summary>
        /// <param name="entityId">The primary key of the customer146</param>
        /// <param name="updatedEntity">The customer146 data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{entityId:Guid}")]
        public IActionResult UpdateById(Guid entityId, [FromBody] Customer146 updatedEntity)
        {
            if (entityId != updatedEntity.CustomerId)
            {
                return BadRequest("Mismatched CustomerId");
            }

            var entityData = _context.Customer146.FirstOrDefault(entity => entity.CustomerId == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            var propertiesToUpdate = typeof(Customer146).GetProperties().Where(property => property.Name != "CustomerId").ToList();
            foreach (var property in propertiesToUpdate)
            {
                property.SetValue(entityData, property.GetValue(updatedEntity));
            }

            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}