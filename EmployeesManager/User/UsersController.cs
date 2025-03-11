using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManager.User
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<Users> _repository;
        private readonly IValidator<Users>  _validtor;

        public UsersController(
            IRepository<Users> repository,
            IValidator<Users> validator

        ){
            _repository = repository;
            _validtor   = validator;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_repository.GetByID(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreatUser(
            [FromBody] Users user
        ){
            var valdiationResults = await _validtor.ValidateAsync(user);
            if (!valdiationResults.IsValid)
            {
            return ValidationProblem(
                valdiationResults.ToModelStateDictionary()
            );
            }
            _repository.create(user);
            return Ok("success");
        }

        [HttpPut("{id}")]
        public IActionResult Update(
            [FromRoute] int id,
            [FromBody] Users user

        )
        {
            _repository.update(user);
            return Ok(_repository.GetByID(id));
        }
        [HttpDelete]
        public IActionResult Delete(
            [FromBody] Users user 
        ){
            _repository.delete(user);
            return Ok("Deleted");
        }
    }
}
