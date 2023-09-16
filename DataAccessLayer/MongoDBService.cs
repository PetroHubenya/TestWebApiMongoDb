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

        readonly string connectionString = "mongodb://localhost:27017/";
        readonly string databaseName = "CurveDataDB";
        readonly string collectionName = "CurveData";

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

        // Get all CurveData
        public async Task<List<CurveData>> GetAllCurvesAsync()
        {
            var filter = Builders<CurveData>.Filter.Empty;
            return await _curveData.Find(filter).ToListAsync();
        }

        // Get CurveData
        public async Task<CurveData> GetCurveDataAsync(string curveName, int curveDate)
        {
            var filter = Builders<CurveData>.Filter.Eq(c => c.CurveName, curveName) &
                         Builders<CurveData>.Filter.Eq(c => c.CurveDate, curveDate);
            return await _curveData.Find(filter).FirstOrDefaultAsync();
        }

        // Create CurveData
        public async Task CreateCurveDataAsync(CurveData curveData)
        {
            await _curveData.InsertOneAsync(curveData);
        }

        // Update CurveData
        public async Task<CurveData> UpdateCurveDataAsync(CurveData newData)
        {
            var filter = Builders<CurveData>.Filter.Eq(c => c.CurveName, newData.CurveName) &
                         Builders<CurveData>.Filter.Eq(c => c.CurveDate, newData.CurveDate);
            await _curveData.ReplaceOneAsync(filter, newData);
            return await _curveData.Find(filter).FirstOrDefaultAsync();
        }

        // Delete CurveData
        public async Task DeleteCurveDataAsync(string curveName, int curveDate)
        {
            var filter = Builders<CurveData>.Filter.Eq(c => c.CurveName, curveName) &
                         Builders<CurveData>.Filter.Eq(c => c.CurveDate, curveDate);
            await _curveData.DeleteOneAsync(filter);
        }
    }
}
