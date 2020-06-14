using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TR.Web.Models.Models;

namespace TR.Web.Services.Interfaces
{
    public interface IMeetingVariantRepo
    {
        IEnumerable<MeetingVariant> GetMeetingVariants(string owner);
        Task<MeetingVariant> CreateMV(MeetingVariant newMV);
        Task ChangeMV(int mvId, MeetingVariant newMV);
        Task DeleteMV(int mvId);
        MeetingVariant GetMeetingVariantById(int mvId, string userId);
    }
}
