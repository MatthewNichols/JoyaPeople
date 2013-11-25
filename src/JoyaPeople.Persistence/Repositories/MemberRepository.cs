using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoyaPeople.Domain;
using JoyaPeople.Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace JoyaPeople.Persistence.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private MongoDatabase _mongoDatabase;

        public MemberRepository(string connectionString)
        {
            OpenConnection(connectionString);
        }

        /// <summary>
        /// Create a connection to the DB specifies in the connectionString.
        /// </summary>
        /// <param name="connectionString">Specifies the Db to connect to.</param>
        private void OpenConnection(string connectionString)
        {
            //Use the MongoUrl class to parse the connectionString
            var mongoUrl = new MongoUrl(connectionString);

            //Create a MongoClient with the new mongoUrl object instead of a url string.
            var mongoClient = new MongoClient(mongoUrl);

            //Get a refernce to the server
            var mongoServer = mongoClient.GetServer();
            mongoServer.Connect();

            //Connect to the database using the mongoUrl again but to get the DatabaseName
            _mongoDatabase = mongoServer.GetDatabase(mongoUrl.DatabaseName);
        }

        /// <summary>
        /// Returns reference to desired MongoCollection.
        /// </summary>
        private MongoCollection<Member> GetMongoCollection()
        {
            //Return a reference to the Members collection. Hard coding
            //the collection name is typically ok here, unless we will be storing to 
            //multiple different collections of the same type in the same Db.  In that case it would
            //probably be better to pass the collection name in on the constructor or set it from a 
            //property.
            return _mongoDatabase.GetCollection<Member>("members");
        }

        public void Save(Member member)
        {
            var mongoCollection = GetMongoCollection();
            mongoCollection.Save(member);
        }

        public IList<Member> SearchByName(string firstNameString, string lastNameString)
        {
            if (string.IsNullOrWhiteSpace(firstNameString) && string.IsNullOrWhiteSpace(lastNameString))
            {
                return new List<Member>();
            }

            var queryable = GetMongoCollection().AsQueryable();
            //IQueryable<Member> results = null;
            if (!string.IsNullOrWhiteSpace(firstNameString))
            {
                queryable = queryable.Where(m => m.FirstName.StartsWith(firstNameString));                    
            }

            if (!string.IsNullOrWhiteSpace(lastNameString))
            {
                queryable = queryable.Where(m => m.LastName.StartsWith(lastNameString));
            }

            return queryable.ToList();
        }

        public Member GetById(ObjectId id)
        {
            var mongoCollection = GetMongoCollection();
            return mongoCollection.FindOneById(id);
        }
    }
}
