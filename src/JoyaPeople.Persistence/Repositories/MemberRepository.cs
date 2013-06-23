using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoyaPeople.Domain;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace JoyaPeople.Persistence.Repositories
{
    public class MemberRepository
    {
        /// <summary>
        /// Creates connection to MongoDB server and returns reference 
        /// to desired MongoCollection.
        /// </summary>
        private MongoCollection<Member> GetMongoCollection()
        {
            //Create MongoClient with hard coded connection string.  Clearly 
            //a hard coded connection string is a bad idea in almost any real 
            //application and we won't tolerate it here for very long.
            var mongoClient = new MongoClient("mongodb://localhost");
            
            //Get a refernce to the server
            var mongoServer = mongoClient.GetServer();
            mongoServer.Connect();
            
            //Connect to the database. Same concern here about the hard coded 
            //database name.
            var mongoDatabase = mongoServer.GetDatabase("mongoPeople");

            //Finally return a reference to the Members collection. Hard coding
            //the collection name is probably ok, unless we will be storing to 
            //multiple different collections.  
            return mongoDatabase.GetCollection<Member>("members");
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
