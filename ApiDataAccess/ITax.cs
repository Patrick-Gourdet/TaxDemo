using System.Threading.Tasks;

namespace Auth.ApiDataAccess
{
    /// <summary>
    /// Serves as the extenstion for the memento pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITax<T>
    {
        Task GetTaxInfo(T action);
    }
}