using BetManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using BetManager.Domain.Repositories;

namespace BetManager.Infrastructure.Database.Repositories
{
    public class CouponRepository(ApplicationDbContext context) : ICouponRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Coupon>> GetAllAsync()
            => await _context.Coupons.ToListAsync();

        public async Task<Coupon?> GetByIdAsync(Guid id)
            => await _context.Coupons.FirstOrDefaultAsync(e => e.Id == id);      

        public async Task<Coupon?> GetByCouponNumberAsync(string couponNumber)  
            => await _context.Coupons.FirstOrDefaultAsync(e => e.CouponNumber == couponNumber);

        public async Task<Coupon> CreateAsync(Coupon coupon)
        {
            await _context.Coupons.AddAsync(coupon);
            await _context.SaveChangesAsync();
            return coupon;
        }

        public async Task<Coupon> UpdateAsync(Coupon coupon)
        {
            _context.Coupons.Update(coupon);
            await _context.SaveChangesAsync();
            return coupon;
        }

        public async Task<Coupon> DeleteAsync(Coupon coupon)
        {
            _context.Coupons.Remove(coupon);
            await _context.SaveChangesAsync();
            return coupon;
        }
    }
}