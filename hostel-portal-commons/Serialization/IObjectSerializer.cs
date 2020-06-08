using System.Threading.Tasks;


namespace Staawork.Funaab.HostelPortal.Commons.Serialization
{
    public interface IObjectSerializer<T>
    {
        Task<byte[]> SerializeAsync(T obj);
    }
}