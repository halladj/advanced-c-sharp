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
        private readonly IValidator<CreareUserRequest> _postValidator;
        private readonly IValidator<DeleteUserRequest> _deleteValidator;
        private readonly IValidator<UpdateUserRequest> _updateValidator;

        public UsersController(
            IRepository<Users> repository,
            IValidator<CreareUserRequest> postvalidator,
            IValidator<DeleteUserRequest> deletevalidator,
            IValidator<UpdateUserRequest> updatevalidator
        ){
            _repository     = repository;
            _postValidator  = postvalidator;
            _updateValidator= updatevalidator;
            _deleteValidator= deletevalidator;
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
            var validationResults = await _postValidator.ValidateAsync(user);
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
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateUserRequest user
        )
        {
            var validationResults = await _updateValidator.ValidateAsync(user);
            if (!validationResults.IsValid)
            {
                return ValidationProblem(
                    validationResults.ToModelStateDictionary()
                );
            }
            _repository.Update(user);
            return Ok(_repository.GetById(id));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(
            [FromBody] DeleteUserRequest user
        )
        {
            var validationResults = await _deleteValidator.ValidateAsync(user);
            if (!validationResults.IsValid)
            {
                return ValidationProblem(
                    validationResults.ToModelStateDictionary()
                );
            }
            _repository.Delete(user);
            return Ok("Success");
        }
    }
}
