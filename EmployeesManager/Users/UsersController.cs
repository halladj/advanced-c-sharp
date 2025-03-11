using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManager.Users
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<Users> _repository;
        private readonly IValidator<Users> _validator;

        public UsersController(
            IRepository<Users> repository,
            IValidator<Users> validator
        ){
            _repository = repository;
            _validator  = validator;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_repository.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(
            [FromBody] Users user
        )
        {
            var validationResults = await _validator.ValidateAsync(user);
            if (!validationResults.IsValid)
            {
                return ValidationProblem(
                    validationResults.ToModelStateDictionary()
                );
            }

            _repository.Create(user);
            return Ok("success");
        }

        [HttpPut("{id}")]
        public IActionResult Update(
            [FromRoute] int id,
            [FromBody] Users user
        )
        {
            _repository.Update(user);
            return Ok(_repository.GetById(id));
        }

        [HttpDelete]
        public IActionResult Delete(
            [FromBody] Users user
        )
        {
            _repository.Delete(user);
            return Ok("Success");
        }
    }
}
