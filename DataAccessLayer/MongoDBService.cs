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

        public void CreateCurveData(CurveData curveData)
        {
            throw new NotImplementedException();
        }

        public void DeleteCurveData(string curveName, int curveDate)
        {
            throw new NotImplementedException();
        }

        public List<CurveData> GetAllCurves()
        {
            throw new NotImplementedException();
        }

        public CurveData GetCurveData(string curveName, int curveDate)
        {
            throw new NotImplementedException();
        }

        public CurveData UpdateCurveData(CurveData newData)
        {
            throw new NotImplementedException();
        }
    }
}
