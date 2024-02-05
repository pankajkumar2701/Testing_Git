using Microsoft.AspNetCore.Mvc;
using Testing_Git.Model;
using Testing_Git.Data;
using Testing_Git.Filter;

namespace Testing_Git.Controllers
{
    /// <summary>
    /// Controller responsible for managing employee1-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting employee1 information.
    /// </remarks>
    [Route("api/[controller]")]
    public class Employee1Controller : ControllerBase
    {
        private readonly Testing_GitContext _context;

        public Employee1Controller(Testing_GitContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new employee1 to the database</summary>
        /// <param name="model">The employee1 data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Employee1 model)
        {
            _context.Employee1.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of employee1s based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"Property": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of employee1s</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Employee1.AsQueryable();
            var result = FilterService<Employee1>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific employee1 by its primary key</summary>
        /// <param name="entityId">The primary key of the employee1</param>
        /// <returns>The employee1 data</returns>
        [HttpGet]
        [Route("{entityId:Guid}")]
        public IActionResult GetById([FromRoute] Guid entityId)
        {
            var entityData = _context.Employee1.FirstOrDefault(entity => entity.EmployeeId1 == entityId);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific employee1 by its primary key</summary>
        /// <param name="entityId">The primary key of the employee1</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [Route("{entityId:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid entityId)
        {
            var entityData = _context.Employee1.FirstOrDefault(entity => entity.EmployeeId1 == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Employee1.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific employee1 by its primary key</summary>
        /// <param name="entityId">The primary key of the employee1</param>
        /// <param name="updatedEntity">The employee1 data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{entityId:Guid}")]
        public IActionResult UpdateById(Guid entityId, [FromBody] Employee1 updatedEntity)
        {
            if (entityId != updatedEntity.EmployeeId1)
            {
                return BadRequest("Mismatched EmployeeId1");
            }

            var entityData = _context.Employee1.FirstOrDefault(entity => entity.EmployeeId1 == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            var propertiesToUpdate = typeof(Employee1).GetProperties().Where(property => property.Name != "EmployeeId1").ToList();
            foreach (var property in propertiesToUpdate)
            {
                property.SetValue(entityData, property.GetValue(updatedEntity));
            }

            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}