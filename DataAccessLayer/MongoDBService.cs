using Interfaces;
using Microsoft.Extensions.Options;
using Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MongoDBService : IDataService
    {
        private readonly IMongoCollection<CurveData> _curveData;

        string connectionString = "mongodb://localhost:27017/";
        string databaseName = "CurveDataDB";
        string collectionName = "CurveData";

        public MongoDBService(IOptions<MongoDbSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _curveData = database.GetCollection<CurveData>(mongoDBSettings.Value.CollectionName);
        }

        public MongoDBService()
        {
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase(databaseName);
            _curveData = database.GetCollection<CurveData>(collectionName);
        }

        public Task CreateCurveDataAsync(CurveData curveData)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCurveDataAsync(string curveName, int curveDate)
        {
            throw new NotImplementedException();
        }

        public Task<List<CurveData>> GetAllCurvesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CurveData> GetCurveDataAsync(string curveName, int curveDate)
        {
            throw new NotImplementedException();
        }

        public Task<CurveData> UpdateCurveDataAsync(CurveData newData)
        {
            throw new NotImplementedException();
        }
    }
}
