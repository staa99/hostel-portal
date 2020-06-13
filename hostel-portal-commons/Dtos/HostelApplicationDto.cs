using System;
using ProtoBuf;


namespace Staawork.Funaab.HostelPortal.Commons.Dtos
{
    [ProtoContract]
    public sealed class HostelApplicationDto : IEquatable<HostelApplicationDto?>
    {
        [ProtoMember(1)]
        public string HostelId { get; set; } = string.Empty;

        [ProtoMember(2)]
        public string MatricNumber { get; set; } = string.Empty;


        public bool Equals(HostelApplicationDto? other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return HostelId == other.HostelId && MatricNumber == other.MatricNumber;
        }


        public override bool Equals(object? obj) =>
            ReferenceEquals(this, obj) || obj is HostelApplicationDto other && Equals(other);


        public override int GetHashCode() => HashCode.Combine(HostelId, MatricNumber);

        public static bool operator ==(HostelApplicationDto? left, HostelApplicationDto? right) => Equals(left, right);

        public static bool operator !=(HostelApplicationDto? left, HostelApplicationDto? right) => !Equals(left, right);
    }
}