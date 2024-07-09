namespace Presentation.Contracts.Users;

/// <summary>
/// List user response.
/// </summary>
public record ListUserResponse : BaseDataForListResponse
{
    /// <summary>
    /// Nome.
    /// </summary>
    public string Email { get; init; }
}