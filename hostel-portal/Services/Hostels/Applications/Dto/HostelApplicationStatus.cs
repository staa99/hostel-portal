namespace Staawork.Funaab.HostelPortal.Services.Hostels.Applications.Dto
{
    public enum HostelApplicationStatus
    {
        Nonexistent,
        Queued,
        InProcess,
        Succeeded,
        FailedNoHostelAvailable,
        FailedUnknownReason,
        FailedDoNotRepeat
    }
}