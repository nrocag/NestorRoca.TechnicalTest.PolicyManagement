namespace NestorRoca.TechnicalTest.PolicyManagement.DataAccess
{
    using Entities.Model;
    using MongoDB.Driver.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMongoRepository<T> where T : BaseEntity, new()
    {
        Task DeleteById(string id);

        IMongoQueryable<T> Query { get; set; }

        Task<IEnumerable<T>> GetAll();

        Task<T> GetOne(string id);

        Task UpdateOne(T update);

        Task InsertOne(T item);
    }
}
