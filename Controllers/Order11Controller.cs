using Microsoft.AspNetCore.Mvc;
using Testing_Git.Model;
using Testing_Git.Data;
using Testing_Git.Filter;

namespace Testing_Git.Controllers
{
    /// <summary>
    /// Controller responsible for managing order11-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting order11 information.
    /// </remarks>
    [Route("api/[controller]")]
    public class Order11Controller : ControllerBase
    {
        private readonly Testing_GitContext _context;

        public Order11Controller(Testing_GitContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new order11 to the database</summary>
        /// <param name="model">The order11 data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Order11 model)
        {
            _context.Order11.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of order11s based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"Property": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of order11s</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Order11.AsQueryable();
            var result = FilterService<Order11>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific order11 by its primary key</summary>
        /// <param name="entityId">The primary key of the order11</param>
        /// <returns>The order11 data</returns>
        [HttpGet]
        [Route("{entityId:Guid}")]
        public IActionResult GetById([FromRoute] Guid entityId)
        {
            var entityData = _context.Order11.FirstOrDefault(entity => entity.OrderID == entityId);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific order11 by its primary key</summary>
        /// <param name="entityId">The primary key of the order11</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [Route("{entityId:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid entityId)
        {
            var entityData = _context.Order11.FirstOrDefault(entity => entity.OrderID == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Order11.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific order11 by its primary key</summary>
        /// <param name="entityId">The primary key of the order11</param>
        /// <param name="updatedEntity">The order11 data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{entityId:Guid}")]
        public IActionResult UpdateById(Guid entityId, [FromBody] Order11 updatedEntity)
        {
            if (entityId != updatedEntity.OrderID)
            {
                return BadRequest("Mismatched OrderID");
            }

            var entityData = _context.Order11.FirstOrDefault(entity => entity.OrderID == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            var propertiesToUpdate = typeof(Order11).GetProperties().Where(property => property.Name != "OrderID").ToList();
            foreach (var property in propertiesToUpdate)
            {
                property.SetValue(entityData, property.GetValue(updatedEntity));
            }

            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}