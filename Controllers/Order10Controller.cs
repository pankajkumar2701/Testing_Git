using Microsoft.AspNetCore.Mvc;
using Testing_Git.Model;
using Testing_Git.Data;
using Testing_Git.Filter;

namespace Testing_Git.Controllers
{
    /// <summary>
    /// Controller responsible for managing order10-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting order10 information.
    /// </remarks>
    [Route("api/[controller]")]
    public class Order10Controller : ControllerBase
    {
        private readonly Testing_GitContext _context;

        public Order10Controller(Testing_GitContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new order10 to the database</summary>
        /// <param name="model">The order10 data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Order10 model)
        {
            _context.Order10.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of order10s based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"Property": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of order10s</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Order10.AsQueryable();
            var result = FilterService<Order10>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific order10 by its primary key</summary>
        /// <param name="entityId">The primary key of the order10</param>
        /// <returns>The order10 data</returns>
        [HttpGet]
        [Route("{entityId:Guid}")]
        public IActionResult GetById([FromRoute] Guid entityId)
        {
            var entityData = _context.Order10.FirstOrDefault(entity => entity.OrderID == entityId);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific order10 by its primary key</summary>
        /// <param name="entityId">The primary key of the order10</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [Route("{entityId:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid entityId)
        {
            var entityData = _context.Order10.FirstOrDefault(entity => entity.OrderID == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Order10.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific order10 by its primary key</summary>
        /// <param name="entityId">The primary key of the order10</param>
        /// <param name="updatedEntity">The order10 data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{entityId:Guid}")]
        public IActionResult UpdateById(Guid entityId, [FromBody] Order10 updatedEntity)
        {
            if (entityId != updatedEntity.OrderID)
            {
                return BadRequest("Mismatched OrderID");
            }

            var entityData = _context.Order10.FirstOrDefault(entity => entity.OrderID == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            var propertiesToUpdate = typeof(Order10).GetProperties().Where(property => property.Name != "OrderID").ToList();
            foreach (var property in propertiesToUpdate)
            {
                property.SetValue(entityData, property.GetValue(updatedEntity));
            }

            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}