namespace Rating_University.Infrastructure.Services
{
    public interface IRolesServices
    {
        Task<bool> IsAdmin { get; }
    }
}
