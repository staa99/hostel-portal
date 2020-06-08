using System.IO;
using System.Threading.Tasks;
using ProtoBuf;
using Staawork.Funaab.HostelPortal.Commons.Dtos;


namespace Staawork.Funaab.HostelPortal.Commons.Serialization
{
    public class ProtobufHostelApplicationSerializer : IHostelApplicationSerializer
    {
        public Task<byte[]> SerializeAsync(HostelApplicationDto obj) => Task.Run(() =>
        {
            var stream = new MemoryStream();
            Serializer.Serialize(stream, obj);
            return stream.ToArray();
        });
    }
}