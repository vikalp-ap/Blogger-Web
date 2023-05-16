using System;
using Blogger.Web.Models.Domain;

namespace Blogger.Web.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllAsync();
        Task<Tag?> GetAsync(Guid id);
        Task<Tag?> DeleteAsync(Guid id);
        Task<Tag?> UpdateAsync(Tag tag);
        Task<Tag> AddAsync(Tag tag);
    }
}
