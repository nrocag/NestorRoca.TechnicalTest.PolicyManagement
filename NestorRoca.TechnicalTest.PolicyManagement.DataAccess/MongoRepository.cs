namespace NestorRoca.TechnicalTest.PolicyManagement.DataAccess
{
    using Entities.Model;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MongoRepository<T> : IMongoRepository<T> where T : BaseEntity, new()
    {
        private readonly string collectionName;

        private readonly IMongoDatabase db;

        public MongoRepository()
        {
            this.collectionName = typeof(T).Name;
            this.db = MongoDbCosmosConnection.DataBase;
        }

        protected IMongoCollection<T> Collection
        {
            get
            {
                return this.db.GetCollection<T>(this.collectionName);
            }
            set
            {
                this.Collection = value;
            }
        }

        public IMongoQueryable<T> Query
        {
            get
            {
                return this.Collection.AsQueryable<T>();
            }
            set
            {
                this.Query = value;
            }
        }

        public async Task<T> GetOne(string id)
        {
            ObjectId objectId = new ObjectId(id);
            return await this.Collection.Find(x => x._id.Equals(objectId)).SingleOrDefaultAsync();
        }
        
        public async Task UpdateOne(T update)
        {
            ObjectId objectId = new ObjectId(update._id);
            await this.Collection.ReplaceOneAsync(x => x._id.Equals(objectId), update);
        }
        
        public async Task DeleteById(string id)
        {
            ObjectId objectId = new ObjectId(id);
            DeleteResult result = await this.Collection.DeleteOneAsync(x => x._id.Equals(objectId));

            if (result.DeletedCount <= 0)
            {
                throw new KeyNotFoundException("No se pudo eliminar el registro con id" + id);
            }
        }
        
        public async Task InsertOne(T item)
        {
            item._id = ObjectId.GenerateNewId().ToString();
            await this.Collection.InsertOneAsync(item);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this.Collection.Find(x => true).ToListAsync();
        }
    }
}
