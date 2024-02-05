using Microsoft.AspNetCore.Mvc;
using Testing_Git.Model;
using Testing_Git.Data;
using Testing_Git.Filter;

namespace Testing_Git.Controllers
{
    /// <summary>
    /// Controller responsible for managing order167-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting order167 information.
    /// </remarks>
    [Route("api/[controller]")]
    public class Order167Controller : ControllerBase
    {
        private readonly Testing_GitContext _context;

        public Order167Controller(Testing_GitContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new order167 to the database</summary>
        /// <param name="model">The order167 data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Order167 model)
        {
            _context.Order167.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of order167s based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"Property": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of order167s</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Order167.AsQueryable();
            var result = FilterService<Order167>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific order167 by its primary key</summary>
        /// <param name="entityId">The primary key of the order167</param>
        /// <returns>The order167 data</returns>
        [HttpGet]
        [Route("{entityId:Guid}")]
        public IActionResult GetById([FromRoute] Guid entityId)
        {
            var entityData = _context.Order167.FirstOrDefault(entity => entity.OrderID == entityId);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific order167 by its primary key</summary>
        /// <param name="entityId">The primary key of the order167</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [Route("{entityId:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid entityId)
        {
            var entityData = _context.Order167.FirstOrDefault(entity => entity.OrderID == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Order167.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific order167 by its primary key</summary>
        /// <param name="entityId">The primary key of the order167</param>
        /// <param name="updatedEntity">The order167 data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{entityId:Guid}")]
        public IActionResult UpdateById(Guid entityId, [FromBody] Order167 updatedEntity)
        {
            if (entityId != updatedEntity.OrderID)
            {
                return BadRequest("Mismatched OrderID");
            }

            var entityData = _context.Order167.FirstOrDefault(entity => entity.OrderID == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            var propertiesToUpdate = typeof(Order167).GetProperties().Where(property => property.Name != "OrderID").ToList();
            foreach (var property in propertiesToUpdate)
            {
                property.SetValue(entityData, property.GetValue(updatedEntity));
            }

            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}