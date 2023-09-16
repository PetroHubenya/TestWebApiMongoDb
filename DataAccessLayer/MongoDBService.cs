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

        public MongoDBService(IOptions<MongoDbSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _curveData = database.GetCollection<CurveData>(mongoDBSettings.Value.CollectionName);
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
