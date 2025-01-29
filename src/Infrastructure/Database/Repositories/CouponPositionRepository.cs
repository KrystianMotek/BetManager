using BetManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using BetManager.Domain.Repositories;

namespace BetManager.Infrastructure.Database.Repositories
{
    public class CouponPositionRepository(ApplicationDbContext context) : ICouponPositionRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<CouponPosition?> GetByIdAsync(Guid id)
            => await _context.CouponPositions.FirstOrDefaultAsync(p => p.Id == id);

        public async Task<CouponPosition?> GetByPositionNumberAsync(int positionNumber)
            => await _context.CouponPositions.FirstOrDefaultAsync(p => p.PositionNumber == positionNumber);
        
        public async Task<CouponPosition> CreateAsync(CouponPosition couponPosition)
        {
            await _context.CouponPositions.AddAsync(couponPosition);
            await _context.SaveChangesAsync();
            return couponPosition;
        }

        public async Task<CouponPosition> UpdateAsync(CouponPosition couponPosition)
        {
            _context.CouponPositions.Update(couponPosition);
            await _context.SaveChangesAsync();
            return couponPosition;
        }

        public async Task<CouponPosition> DeleteAsync(CouponPosition couponPosition)
        {
            _context.CouponPositions.Remove(couponPosition);
            await _context.SaveChangesAsync();
            return couponPosition;
        }
    }
}