using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class MongoSaleRepository : ISaleRepository
    {
        private readonly IMongoCollection<Sale> _sales;

        public MongoSaleRepository(IMongoDatabase database)
        {
            _sales = database.GetCollection<Sale>("sales");
        }

        public async Task<Sale> GetByIdAsync(Guid id)
        {
            return await _sales.Find(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            return await _sales.Find(_ => true).ToListAsync();
        }

        public async Task AddAsync(Sale sale)
        {
            await _sales.InsertOneAsync(sale);
        }

        public async Task UpdateAsync(Sale sale)
        {
            await _sales.ReplaceOneAsync(s => s.Id == sale.Id, sale);
        }

        public async Task<Sale> GetBySaleNumberAsync(int saleNumber)
        {
            return await _sales.Find(s => s.SaleNumber == saleNumber).FirstOrDefaultAsync();
        }
    }
}