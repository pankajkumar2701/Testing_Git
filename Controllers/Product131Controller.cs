using Microsoft.AspNetCore.Mvc;
using Testing_Git.Model;
using Testing_Git.Data;
using Testing_Git.Filter;

namespace Testing_Git.Controllers
{
    /// <summary>
    /// Controller responsible for managing product131-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting product131 information.
    /// </remarks>
    [Route("api/[controller]")]
    public class Product131Controller : ControllerBase
    {
        private readonly Testing_GitContext _context;

        public Product131Controller(Testing_GitContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new product131 to the database</summary>
        /// <param name="model">The product131 data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Product131 model)
        {
            _context.Product131.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of product131s based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"Property": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of product131s</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Product131.AsQueryable();
            var result = FilterService<Product131>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific product131 by its primary key</summary>
        /// <param name="entityId">The primary key of the product131</param>
        /// <returns>The product131 data</returns>
        [HttpGet]
        [Route("{entityId:Guid}")]
        public IActionResult GetById([FromRoute] Guid entityId)
        {
            var entityData = _context.Product131.FirstOrDefault(entity => entity.ProductId == entityId);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific product131 by its primary key</summary>
        /// <param name="entityId">The primary key of the product131</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [Route("{entityId:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid entityId)
        {
            var entityData = _context.Product131.FirstOrDefault(entity => entity.ProductId == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Product131.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific product131 by its primary key</summary>
        /// <param name="entityId">The primary key of the product131</param>
        /// <param name="updatedEntity">The product131 data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{entityId:Guid}")]
        public IActionResult UpdateById(Guid entityId, [FromBody] Product131 updatedEntity)
        {
            if (entityId != updatedEntity.ProductId)
            {
                return BadRequest("Mismatched ProductId");
            }

            var entityData = _context.Product131.FirstOrDefault(entity => entity.ProductId == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            var propertiesToUpdate = typeof(Product131).GetProperties().Where(property => property.Name != "ProductId").ToList();
            foreach (var property in propertiesToUpdate)
            {
                property.SetValue(entityData, property.GetValue(updatedEntity));
            }

            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}