using Application.Services.Users;
using Domain.Entities;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Contracts.Users;
using Presentation.Helpers;

namespace Presentation.Controllers;

public class UsersController(
    IBaseEntityRepository<User> repository,
    IUserCreator creator)
    : BaseController(repository)
{

    /// <summary>
    /// Creates the user using the email and password provided.
    /// </summary>
    /// <response code="200">User created.</response>
    /// <response code="400">The request was unsuccessful, see details.</response>
    /// <response code="409">User already created.</response>
    [AllowAnonymous]
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateUserRequest request, CancellationToken token = default)
    {
        await creator.CreateAsync(request.ConvertToDto());

        return Ok($"Created user {request.Nome}.");
    }
}