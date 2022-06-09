using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWallWebAPI.Domain.Models;
using MyWallWebAPI.Infrastructure.Data.Contexts;

namespace MyWallWebAPI.Infrastructure.Data.Repositories
{
    public class LikeRepository
    {
        private readonly MySQLContext _context;

        public LikeRepository(MySQLContext context)
        {
            _context = context;
        }

        public async Task<List<Like>> ListLikes()
        {
            List<Like> list = await _context.Like.OrderBy(p => p.Data).Include(p => p.ApplicationUser).Include(p => p.Post).ToListAsync();

            return list;
        }

        public async Task<List<Like>> ListLikesByApplicationUserId(string applicationUserId)
        {
            List<Like> list = await _context.Like.Where(p => p.ApplicationUserId.Equals(applicationUserId)).OrderBy(p => p.Data).Include(p => p.ApplicationUser).Include(p => p.Post).ToListAsync();

            return list;
        }

        public async Task<Like> FindLikeByPostAndUserId(int postId, string applicationUserId)
        {
            Like like = await _context.Like.FirstOrDefaultAsync(p => p.PostId == postId && p.ApplicationUserId == applicationUserId);

            return like;
        }

        public async Task<List<Like>> ListLikesByPostId(int postId)
        {
            List<Like> list = await _context.Like.Where(p => p.PostId.Equals(postId)).OrderBy(p => p.Data).Include(p => p.ApplicationUser).Include(p => p.Post).ToListAsync();

            return list;
        }

        public async Task<Like> GetLikeById(int likeId)
        {
            Like like = await _context.Like.Include(p => p.ApplicationUser).Include(p => p.Post).FirstOrDefaultAsync((p => p.Id == likeId));

            return like;
        }

        public async Task<Like> CreateLike(Like like)
        {
            var ret = await _context.Like.AddAsync(like);

            await _context.SaveChangesAsync();

            ret.State = EntityState.Detached;

            return ret.Entity;
        }

        public async Task<int> UpdateLike(Like like)
        {
            _context.Entry(like).State = EntityState.Modified;

            return await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteLikeAsync(int likeId)
        {
            var item = await _context.Like.FindAsync(likeId);
            _context.Like.Remove(item);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
