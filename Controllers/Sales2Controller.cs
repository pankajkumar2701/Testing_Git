using Microsoft.AspNetCore.Mvc;
using Testing_Git.Model;
using Testing_Git.Data;
using Testing_Git.Filter;

namespace Testing_Git.Controllers
{
    /// <summary>
    /// Controller responsible for managing sales2-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting sales2 information.
    /// </remarks>
    [Route("api/[controller]")]
    public class Sales2Controller : ControllerBase
    {
        private readonly Testing_GitContext _context;

        public Sales2Controller(Testing_GitContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new sales2 to the database</summary>
        /// <param name="model">The sales2 data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Sales2 model)
        {
            _context.Sales2.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of sales2s based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"Property": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of sales2s</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Sales2.AsQueryable();
            var result = FilterService<Sales2>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific sales2 by its primary key</summary>
        /// <param name="entityId">The primary key of the sales2</param>
        /// <returns>The sales2 data</returns>
        [HttpGet]
        [Route("{entityId:Guid}")]
        public IActionResult GetById([FromRoute] Guid entityId)
        {
            var entityData = _context.Sales2.FirstOrDefault(entity => entity.SalesId == entityId);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific sales2 by its primary key</summary>
        /// <param name="entityId">The primary key of the sales2</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [Route("{entityId:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid entityId)
        {
            var entityData = _context.Sales2.FirstOrDefault(entity => entity.SalesId == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Sales2.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific sales2 by its primary key</summary>
        /// <param name="entityId">The primary key of the sales2</param>
        /// <param name="updatedEntity">The sales2 data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{entityId:Guid}")]
        public IActionResult UpdateById(Guid entityId, [FromBody] Sales2 updatedEntity)
        {
            if (entityId != updatedEntity.SalesId)
            {
                return BadRequest("Mismatched SalesId");
            }

            var entityData = _context.Sales2.FirstOrDefault(entity => entity.SalesId == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            var propertiesToUpdate = typeof(Sales2).GetProperties().Where(property => property.Name != "SalesId").ToList();
            foreach (var property in propertiesToUpdate)
            {
                property.SetValue(entityData, property.GetValue(updatedEntity));
            }

            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}