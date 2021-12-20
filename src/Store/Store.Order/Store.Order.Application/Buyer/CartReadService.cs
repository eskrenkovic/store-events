using System.Data;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Store.Core.Domain;
using Store.Order.Domain.Buyers.ValueObjects;
using Store.Order.Infrastructure;
using Store.Order.Infrastructure.Entity;

namespace Store.Order.Application.Buyer
{
    public class CartReadService
    {
        private readonly ISerializer _serializer;
        private readonly IDbConnection _db;

        public CartReadService(ISerializer serializer, StoreOrderDbContext context)
        {
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            _db = context?.Database.GetDbConnection() ?? throw new ArgumentNullException(nameof(context));  
        } 
        
        public async Task<Cart> GetCartAsync(BuyerIdentifier buyerId)
        {
            string query = @"SELECT *
                             FROM public.cart
                             WHERE customer_number = @CustomerNumber 
                             AND session_id = @SessionId;";

            CartEntity cartEntity = await _db.QuerySingleOrDefaultAsync<CartEntity>(query, new { buyerId.CustomerNumber, buyerId.SessionId });
            if (cartEntity == null) return null;

            return _serializer.Deserialize<Cart>(cartEntity.Data);
        }
    }
}