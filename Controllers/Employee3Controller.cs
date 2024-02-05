using Microsoft.AspNetCore.Mvc;
using Testing_Git.Model;
using Testing_Git.Data;
using Testing_Git.Filter;

namespace Testing_Git.Controllers
{
    /// <summary>
    /// Controller responsible for managing employee3-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting employee3 information.
    /// </remarks>
    [Route("api/[controller]")]
    public class Employee3Controller : ControllerBase
    {
        private readonly Testing_GitContext _context;

        public Employee3Controller(Testing_GitContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new employee3 to the database</summary>
        /// <param name="model">The employee3 data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Employee3 model)
        {
            _context.Employee3.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of employee3s based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"Property": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of employee3s</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Employee3.AsQueryable();
            var result = FilterService<Employee3>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific employee3 by its primary key</summary>
        /// <param name="entityId">The primary key of the employee3</param>
        /// <returns>The employee3 data</returns>
        [HttpGet]
        [Route("{entityId:Guid}")]
        public IActionResult GetById([FromRoute] Guid entityId)
        {
            var entityData = _context.Employee3.FirstOrDefault(entity => entity.EmployeeId == entityId);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific employee3 by its primary key</summary>
        /// <param name="entityId">The primary key of the employee3</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [Route("{entityId:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid entityId)
        {
            var entityData = _context.Employee3.FirstOrDefault(entity => entity.EmployeeId == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Employee3.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific employee3 by its primary key</summary>
        /// <param name="entityId">The primary key of the employee3</param>
        /// <param name="updatedEntity">The employee3 data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{entityId:Guid}")]
        public IActionResult UpdateById(Guid entityId, [FromBody] Employee3 updatedEntity)
        {
            if (entityId != updatedEntity.EmployeeId)
            {
                return BadRequest("Mismatched EmployeeId");
            }

            var entityData = _context.Employee3.FirstOrDefault(entity => entity.EmployeeId == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            var propertiesToUpdate = typeof(Employee3).GetProperties().Where(property => property.Name != "EmployeeId").ToList();
            foreach (var property in propertiesToUpdate)
            {
                property.SetValue(entityData, property.GetValue(updatedEntity));
            }

            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}