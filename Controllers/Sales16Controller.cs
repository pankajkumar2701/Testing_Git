using Microsoft.AspNetCore.Mvc;
using Testing_Git.Model;
using Testing_Git.Data;
using Testing_Git.Filter;

namespace Testing_Git.Controllers
{
    /// <summary>
    /// Controller responsible for managing sales16-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting sales16 information.
    /// </remarks>
    [Route("api/[controller]")]
    public class Sales16Controller : ControllerBase
    {
        private readonly Testing_GitContext _context;

        public Sales16Controller(Testing_GitContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new sales16 to the database</summary>
        /// <param name="model">The sales16 data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Sales16 model)
        {
            _context.Sales16.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of sales16s based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"Property": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of sales16s</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Sales16.AsQueryable();
            var result = FilterService<Sales16>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific sales16 by its primary key</summary>
        /// <param name="entityId">The primary key of the sales16</param>
        /// <returns>The sales16 data</returns>
        [HttpGet]
        [Route("{entityId:Guid}")]
        public IActionResult GetById([FromRoute] Guid entityId)
        {
            var entityData = _context.Sales16.FirstOrDefault(entity => entity.SalesId == entityId);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific sales16 by its primary key</summary>
        /// <param name="entityId">The primary key of the sales16</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [Route("{entityId:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid entityId)
        {
            var entityData = _context.Sales16.FirstOrDefault(entity => entity.SalesId == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Sales16.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific sales16 by its primary key</summary>
        /// <param name="entityId">The primary key of the sales16</param>
        /// <param name="updatedEntity">The sales16 data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{entityId:Guid}")]
        public IActionResult UpdateById(Guid entityId, [FromBody] Sales16 updatedEntity)
        {
            if (entityId != updatedEntity.SalesId)
            {
                return BadRequest("Mismatched SalesId");
            }

            var entityData = _context.Sales16.FirstOrDefault(entity => entity.SalesId == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            var propertiesToUpdate = typeof(Sales16).GetProperties().Where(property => property.Name != "SalesId").ToList();
            foreach (var property in propertiesToUpdate)
            {
                property.SetValue(entityData, property.GetValue(updatedEntity));
            }

            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}