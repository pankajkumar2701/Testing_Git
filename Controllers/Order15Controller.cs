using Microsoft.AspNetCore.Mvc;
using Testing_Git.Model;
using Testing_Git.Data;
using Testing_Git.Filter;

namespace Testing_Git.Controllers
{
    /// <summary>
    /// Controller responsible for managing order15-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting order15 information.
    /// </remarks>
    [Route("api/[controller]")]
    public class Order15Controller : ControllerBase
    {
        private readonly Testing_GitContext _context;

        public Order15Controller(Testing_GitContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new order15 to the database</summary>
        /// <param name="model">The order15 data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Order15 model)
        {
            _context.Order15.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of order15s based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"Property": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of order15s</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Order15.AsQueryable();
            var result = FilterService<Order15>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific order15 by its primary key</summary>
        /// <param name="entityId">The primary key of the order15</param>
        /// <returns>The order15 data</returns>
        [HttpGet]
        [Route("{entityId:Guid}")]
        public IActionResult GetById([FromRoute] Guid entityId)
        {
            var entityData = _context.Order15.FirstOrDefault(entity => entity.OrderID == entityId);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific order15 by its primary key</summary>
        /// <param name="entityId">The primary key of the order15</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [Route("{entityId:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid entityId)
        {
            var entityData = _context.Order15.FirstOrDefault(entity => entity.OrderID == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Order15.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific order15 by its primary key</summary>
        /// <param name="entityId">The primary key of the order15</param>
        /// <param name="updatedEntity">The order15 data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{entityId:Guid}")]
        public IActionResult UpdateById(Guid entityId, [FromBody] Order15 updatedEntity)
        {
            if (entityId != updatedEntity.OrderID)
            {
                return BadRequest("Mismatched OrderID");
            }

            var entityData = _context.Order15.FirstOrDefault(entity => entity.OrderID == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            var propertiesToUpdate = typeof(Order15).GetProperties().Where(property => property.Name != "OrderID").ToList();
            foreach (var property in propertiesToUpdate)
            {
                property.SetValue(entityData, property.GetValue(updatedEntity));
            }

            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}