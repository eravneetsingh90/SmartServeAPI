namespace SmartServe.API.Helper
{
    public interface ICurrentUser
    {
        int? UserId { get; }

        string? Username { get; }

        string? Role { get; }

    }
}

