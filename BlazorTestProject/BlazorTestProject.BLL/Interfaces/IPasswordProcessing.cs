namespace BlazorTestProject.BLL.Interfaces
{
    public interface IPasswordProcessing
    {
        string GenerateSalt();
        string GetHashCode(string pass, string salt);
    }
}
