using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace DataAccessLayer
{
    public class JsonFileService : IDataService
    {

        // Create property, that will store the json file path.
        private string JsonFilePath { get; set; }

        // Initialise the text file path property through the constructor.
        public JsonFileService(string jsonFilePath)
        {
            JsonFilePath = jsonFilePath;
        }

        /* Implement Get all CurveData async method.
         * Check whether the directory and file exists.
         * If the directory and file does not exist throw exception.
         * Using file stream open and read the file.
         * Deserialize JSON from the file to the list of CurveData objects asyncronously.
         * Return the list.
         * */
        public async Task<List<CurveData>> GetAllCurvesAsync()
        {
            string jsonFilePath = JsonFilePath;
            try
            {
                var jsonDirectory = Path.GetDirectoryName(jsonFilePath);
                if (!Directory.Exists(jsonDirectory))
                {
                    throw new FileNotFoundException("The JsonFile does not exist.");
                }
                using (StreamReader reader = new StreamReader(jsonFilePath))
                {
                    string jsonString = await reader.ReadToEndAsync();
                    List<CurveData> curves = JsonSerializer.Deserialize<List<CurveData>>(jsonString);
                    return curves;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Implement Get all CurveData async method.
         * Check whether the directory and file exists.
         * If the directory and file does not exist throw exception.
         * Using file stream open and read the file.
         * Deserialize JSON from the file to the list of CurveData objects asyncronously.
         * Find the CurveData by name and date.
         * Return CurveData.
         * */

        /* Implement Create CurveData async method.
         * Check whether the directory and file exists.
         * If the directory and file does not exist create the file.
         * Using file stream open and read the file.
         * Deserialize JSON from the file to the list of CurveData objects asyncronously.
         * Add CurveData to the list.
         * Seriallize the list to JSON.
         * Write JSON to the file.
         * */

        /* Implement Update CurveData method.
         * Check whether the directory and file exists.
         * If the directory and file does not exist throw exception.
         * Using file stream open and read the file.
         * Deserialize JSON from the file to the list of CurveData objects asyncronously.
         * Find the CurveData by name and date in the list.
         * Replace old data with new data.
         * Seriallize the list to JSON.
         * Write JSON to the file.
         * Return CurveData by name and date.
         * */

        /* Implement Delete CurveData method.
         * Check whether the directory and file exists.
         * If the directory and file does not exist throw exception.
         * Using file stream open and read the file.
         * Deserialize JSON from the file to the list of CurveData objects asyncronously.
         * Find the CurveData by name and date in the list.
         * Delete CurveData from the list.
         * Seriallize the list to JSON.
         * Write JSON to the file.
         * */
        public Task CreateCurveDataAsync(CurveData curveData)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCurveDataAsync(string curveName, int curveDate)
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
