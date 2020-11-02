using System.Collections.Generic;
using System.Threading.Tasks;
using SmapiotCaseStudy.Core.Models;

namespace SmapiotCaseStudy.Core.Interfaces
{
    public interface IRequestsService
    {
        public Task<IList<Request>> GetBy(int year, int month);
        public Task<IList<Request>> GetBy(int year, int month, string subscription);
    }
}