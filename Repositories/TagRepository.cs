using System;
using Blogger.Web.Data;
using Blogger.Web.Models.Domain;
using Blogger.Web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Web.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly BlogDbContext blogDbContext;

        public TagRepository(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        public async Task<Tag> AddAsync(Tag tag)
        {
            await blogDbContext.Tags.AddAsync(tag);
            await blogDbContext.SaveChangesAsync();
            return tag;
            //throw new NotImplementedException();
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existingTag = await blogDbContext.Tags.FindAsync(id);
            if (existingTag != null)
            {
                blogDbContext.Tags.Remove(existingTag);
                await blogDbContext.SaveChangesAsync();
                return existingTag;
            }
            return null;
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await blogDbContext.Tags.ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<Tag?> GetAsync(Guid id)
        {
            return await blogDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
            //throw new NotImplementedException();
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await blogDbContext.Tags.FindAsync(tag.Id);
            if (existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;
                await blogDbContext.SaveChangesAsync();
                return existingTag;
            }
            return null;
            //throw new NotImplementedException();
        }
    }
}

