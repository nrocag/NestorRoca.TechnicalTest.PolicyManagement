namespace NestorRoca.TechnicalTest.PolicyManagement.DataAccess
{
    using Entities.Model;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IMongoRepository<T> where T : BaseEntity, new()
    {
        Task DeleteById(string id);

        IMongoQueryable<T> Query { get; set; }

        Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> GetAll();

        Task<T> GetOne(string id);

        Task<T> FindOneAndUpdate(Expression<Func<T, bool>> expression, UpdateDefinition<T> update, FindOneAndUpdateOptions<T> option);

        Task UpdateOne(Expression<Func<T, bool>> expression, T update);

        Task UpdateOne(T update);

        Task DeleteOne(Expression<Func<T, bool>> expression);

        Task InsertMany(IEnumerable<T> items);

        Task InsertOne(T item);
    }
}
