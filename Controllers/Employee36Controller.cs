using Microsoft.AspNetCore.Mvc;
using Testing_Git.Model;
using Testing_Git.Data;
using Testing_Git.Filter;

namespace Testing_Git.Controllers
{
    /// <summary>
    /// Controller responsible for managing employee36-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting employee36 information.
    /// </remarks>
    [Route("api/[controller]")]
    public class Employee36Controller : ControllerBase
    {
        private readonly Testing_GitContext _context;

        public Employee36Controller(Testing_GitContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new employee36 to the database</summary>
        /// <param name="model">The employee36 data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Employee36 model)
        {
            _context.Employee36.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of employee36s based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"Property": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of employee36s</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Employee36.AsQueryable();
            var result = FilterService<Employee36>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific employee36 by its primary key</summary>
        /// <param name="entityId">The primary key of the employee36</param>
        /// <returns>The employee36 data</returns>
        [HttpGet]
        [Route("{entityId:Guid}")]
        public IActionResult GetById([FromRoute] Guid entityId)
        {
            var entityData = _context.Employee36.FirstOrDefault(entity => entity.EmployeeId == entityId);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific employee36 by its primary key</summary>
        /// <param name="entityId">The primary key of the employee36</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [Route("{entityId:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid entityId)
        {
            var entityData = _context.Employee36.FirstOrDefault(entity => entity.EmployeeId == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Employee36.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific employee36 by its primary key</summary>
        /// <param name="entityId">The primary key of the employee36</param>
        /// <param name="updatedEntity">The employee36 data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{entityId:Guid}")]
        public IActionResult UpdateById(Guid entityId, [FromBody] Employee36 updatedEntity)
        {
            if (entityId != updatedEntity.EmployeeId)
            {
                return BadRequest("Mismatched EmployeeId");
            }

            var entityData = _context.Employee36.FirstOrDefault(entity => entity.EmployeeId == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            var propertiesToUpdate = typeof(Employee36).GetProperties().Where(property => property.Name != "EmployeeId").ToList();
            foreach (var property in propertiesToUpdate)
            {
                property.SetValue(entityData, property.GetValue(updatedEntity));
            }

            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}