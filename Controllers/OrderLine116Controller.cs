using Microsoft.AspNetCore.Mvc;
using Testing_Git.Model;
using Testing_Git.Data;
using Testing_Git.Filter;

namespace Testing_Git.Controllers
{
    /// <summary>
    /// Controller responsible for managing orderline116-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting orderline116 information.
    /// </remarks>
    [Route("api/[controller]")]
    public class OrderLine116Controller : ControllerBase
    {
        private readonly Testing_GitContext _context;

        public OrderLine116Controller(Testing_GitContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new orderline116 to the database</summary>
        /// <param name="model">The orderline116 data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        public IActionResult Post([FromBody] OrderLine116 model)
        {
            _context.OrderLine116.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of orderline116s based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"Property": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of orderline116s</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.OrderLine116.AsQueryable();
            var result = FilterService<OrderLine116>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific orderline116 by its primary key</summary>
        /// <param name="entityId">The primary key of the orderline116</param>
        /// <returns>The orderline116 data</returns>
        [HttpGet]
        [Route("{entityId:Guid}")]
        public IActionResult GetById([FromRoute] Guid entityId)
        {
            var entityData = _context.OrderLine116.FirstOrDefault(entity => entity.OrderLineId == entityId);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific orderline116 by its primary key</summary>
        /// <param name="entityId">The primary key of the orderline116</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [Route("{entityId:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid entityId)
        {
            var entityData = _context.OrderLine116.FirstOrDefault(entity => entity.OrderLineId == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.OrderLine116.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific orderline116 by its primary key</summary>
        /// <param name="entityId">The primary key of the orderline116</param>
        /// <param name="updatedEntity">The orderline116 data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{entityId:Guid}")]
        public IActionResult UpdateById(Guid entityId, [FromBody] OrderLine116 updatedEntity)
        {
            if (entityId != updatedEntity.OrderLineId)
            {
                return BadRequest("Mismatched OrderLineId");
            }

            var entityData = _context.OrderLine116.FirstOrDefault(entity => entity.OrderLineId == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            var propertiesToUpdate = typeof(OrderLine116).GetProperties().Where(property => property.Name != "OrderLineId").ToList();
            foreach (var property in propertiesToUpdate)
            {
                property.SetValue(entityData, property.GetValue(updatedEntity));
            }

            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}