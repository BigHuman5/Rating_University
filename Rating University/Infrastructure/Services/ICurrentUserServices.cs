namespace Rating_University.Infrastructure.Services
{
    public interface ICurrentUserServices
    {
        int getIdUser();
        string? getNameUser();
        int getRoleUser();
    }
}
