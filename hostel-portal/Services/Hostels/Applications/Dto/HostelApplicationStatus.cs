namespace Staawork.Funaab.HostelPortal.Services.Hostels.Applications.Dto
{
    public enum HostelApplicationStatus
    {
        Queued,
        InProcess,
        Succeeded,
        FailedNoHostelAvailable,
        FailedUnknownReason,
        FailedDoNotRepeat,
        Nonexistent
    }
}