using System.Collections.Generic;
using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Services.Hostels.Listing.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Hostels.Listing
{
    public class HostelWebApiLoader : IHostelWebApiLoader
    {
        /// <inheritdoc />
        public async Task<ICollection<HostelDto>> LoadHostels()
        {
            // currently this is stubbed. When integration with the Web API is complete, we will switch to the integration
            var hostels = new List<HostelDto>
            {
                new HostelDto
                {
                    Id = "FIO",
                    AvailableCount = 500,
                    Name = "Iyalode Tinubu (Female Hostel) - Old block",
                    Price = "₦18,090.00"
                },
                new HostelDto
                {
                    Id = "FIN",
                    AvailableCount = 400,
                    Name = "Iyalode Tinubu (Female Hostel) - New block",
                    Price = "₦25,090.00"
                },
                new HostelDto
                {
                    Id = "FNC",
                    AvailableCount = 300,
                    Name = "Marble (Female Hostel) ",
                    Price = "₦30,090:00"
                },
                new HostelDto
                {
                    Id = "FNA",
                    AvailableCount = 200,
                    Name = "Needs Assessment (Female Hostel) ",
                    Price = "₦50,090:00"
                },
                new HostelDto
                {
                    Id = "MUO",
                    AvailableCount = 400,
                    Name = "Umar Kabir Hall (Male Hostel) - Old Block ",
                    Price = "₦18,090.00"
                },
                new HostelDto
                {
                    Id = "MUN",
                    AvailableCount = 500,
                    Name = "Umar Kabir Hall (Male Hostel) - New Block ",
                    Price = "₦25,090.00"
                },
                new HostelDto
                {
                    Id = "MNA",
                    AvailableCount = 600,
                    Name = "Needs Assessment (Male Hostel) ",
                    Price = "₦50,090:00"
                },
                new HostelDto
                {
                    Id = "FPI",
                    AvailableCount = 300,
                    Name = "PG Female Hall - Iyalode Tinubu Hostel (3/room)",
                    Price = "₦35,090.00"
                },
                new HostelDto
                {
                    Id = "FPN",
                    AvailableCount = 100,
                    Name = "New PG Male Hostel (2/room)",
                    Price = "₦60,090.00"
                },
                new HostelDto
                {
                    Id = "MPC",
                    AvailableCount = 200,
                    Name = "New PG Male Hostel: CEADESE (2/room)",
                    Price = "₦60,090.00"
                }
            };

            // simulate a delay in loading the data
            await Task.Delay(1000);

            return hostels;
        }
    }
}