using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Commons.Dtos;
using Staawork.Funaab.HostelPortal.Services.Hostels.Applications.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Hostels.Applications
{
    internal class HostelApplicationService : IHostelApplicationService
    {
        /// <inheritdoc />
        public async Task<IDictionary<string, HostelApplicationStatus>> CheckHostelApplicationStatusAsync(
            string                         matricNumber,
            IHostelApplicationCacheChecker cacheChecker)
        {
            ValidateCacheChecker(cacheChecker);
            ValidateMatricNumber(matricNumber);

            // check hostel application status
            return await cacheChecker.CheckHostelApplicationStatusAsync(matricNumber);
        }


        /// <inheritdoc />
        public Task<HostelApplicationStatus> CheckSingleHostelApplicationStatusAsync(
            HostelApplicationDto           hostelApplicationData,
            IHostelApplicationCacheChecker cacheChecker)
        {
            ValidateMatricNumber(hostelApplicationData.MatricNumber);
            ValidateHostelId(hostelApplicationData.HostelId);
            ValidateCacheChecker(cacheChecker);

            return cacheChecker.CheckSingleHostelApplicationStatusAsync(hostelApplicationData);
        }


        /// <inheritdoc />
        public async Task<InitiateHostelApplicationResultDto> InitiateHostelApplicationAsync(
            HostelApplicationDto           hostelApplicationData,
            IHostelApplicationQueue        hostelApplicationQueue,
            IHostelApplicationCacheChecker cacheChecker,
            IHostelApplicationCacheUpdater cacheUpdater)
        {
            var status = await cacheChecker.CheckSingleHostelApplicationStatusAsync(hostelApplicationData);
            switch (status)
            {
                case HostelApplicationStatus.Nonexistent:
                    await QueueHostelApplicationInitiationRequest(hostelApplicationData,
                                                                  hostelApplicationQueue,
                                                                  cacheUpdater);

                    return new InitiateHostelApplicationResultDto
                        { Message = "Application process initiated.", Success = true };
                // it exists on the queue and is still being processed
                case HostelApplicationStatus.Queued:
                    return new InitiateHostelApplicationResultDto
                    {
                        Message = "Please wait, your application is currently queued and will be processed soon",
                        Success = true
                    };
                case HostelApplicationStatus.InProcess:
                    return new InitiateHostelApplicationResultDto
                        { Message = "Please wait, your application is currently being processed", Success = true };
                case HostelApplicationStatus.Succeeded:
                    return new InitiateHostelApplicationResultDto
                    {
                        Message =
                            "Congratulations, your application completed successfully. You can proceed to pay your hostel fees.",
                        Success = true
                    };
                case HostelApplicationStatus.FailedNoHostelAvailable:
                    return new InitiateHostelApplicationResultDto
                    {
                        Message =
                            "Sorry, your application failed because there are no hostels available. Kindly try another hostel."
                    };
                case HostelApplicationStatus.FailedUnknownReason:
                    await QueueHostelApplicationInitiationRequest(hostelApplicationData,
                                                                  hostelApplicationQueue,
                                                                  cacheUpdater);

                    return new InitiateHostelApplicationResultDto
                    {
                        Message =
                            "Sorry, your application failed for an unknown reason. We are already trying again for you. You can also choose another hostel."
                    };
                case HostelApplicationStatus.FailedDoNotRepeat:
                    return new InitiateHostelApplicationResultDto
                    {
                        Message =
                            "Sorry, your application failed for an unknown reason. We recommend you try another hostel."
                    };
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        private static async Task QueueHostelApplicationInitiationRequest(HostelApplicationDto hostelApplicationData,
                                                                          IHostelApplicationQueue
                                                                              hostelApplicationQueue,
                                                                          IHostelApplicationCacheUpdater cacheUpdater)
        {
            await cacheUpdater.UpdateHostelApplicationStatusAsync(hostelApplicationData,
                                                                  HostelApplicationStatus.Queued);

            await hostelApplicationQueue.SendNewHostelApplicationAsync(hostelApplicationData);
        }


        private static void ValidateCacheChecker(IHostelApplicationCacheChecker cacheChecker)
        {
            // check cache checker not null
            if (cacheChecker == null)
            {
                throw new ArgumentNullException(nameof(cacheChecker));
            }
        }


        private static void ValidateHostelId(string hostelId)
        {
            // validate matric number
            if (string.IsNullOrEmpty(hostelId))
            {
                throw new ApplicationException("Error checking application status: Invalid hostel ID - (null).");
            }
        }


        private static void ValidateMatricNumber(string matricNumber)
        {
            // validate matric number
            if (string.IsNullOrEmpty(matricNumber))
            {
                throw new ApplicationException(
                    "Error checking application status: Invalid matriculation number - (null).");
            }
        }
    }
}