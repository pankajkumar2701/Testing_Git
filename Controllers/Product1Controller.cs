using Microsoft.AspNetCore.Mvc;
using Testing_Git.Model;
using Testing_Git.Data;
using Testing_Git.Filter;

namespace Testing_Git.Controllers
{
    /// <summary>
    /// Controller responsible for managing product1-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting product1 information.
    /// </remarks>
    [Route("api/[controller]")]
    public class Product1Controller : ControllerBase
    {
        private readonly Testing_GitContext _context;

        public Product1Controller(Testing_GitContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new product1 to the database</summary>
        /// <param name="model">The product1 data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Product1 model)
        {
            _context.Product1.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of product1s based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"Property": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of product1s</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Product1.AsQueryable();
            var result = FilterService<Product1>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific product1 by its primary key</summary>
        /// <param name="entityId">The primary key of the product1</param>
        /// <returns>The product1 data</returns>
        [HttpGet]
        [Route("{entityId:Guid}")]
        public IActionResult GetById([FromRoute] Guid entityId)
        {
            var entityData = _context.Product1.FirstOrDefault(entity => entity.ProductId == entityId);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific product1 by its primary key</summary>
        /// <param name="entityId">The primary key of the product1</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [Route("{entityId:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid entityId)
        {
            var entityData = _context.Product1.FirstOrDefault(entity => entity.ProductId == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Product1.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific product1 by its primary key</summary>
        /// <param name="entityId">The primary key of the product1</param>
        /// <param name="updatedEntity">The product1 data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{entityId:Guid}")]
        public IActionResult UpdateById(Guid entityId, [FromBody] Product1 updatedEntity)
        {
            if (entityId != updatedEntity.ProductId)
            {
                return BadRequest("Mismatched ProductId");
            }

            var entityData = _context.Product1.FirstOrDefault(entity => entity.ProductId == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            var propertiesToUpdate = typeof(Product1).GetProperties().Where(property => property.Name != "ProductId").ToList();
            foreach (var property in propertiesToUpdate)
            {
                property.SetValue(entityData, property.GetValue(updatedEntity));
            }

            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}