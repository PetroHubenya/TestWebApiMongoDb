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
                using (StreamReader reader = new (jsonFilePath))
                {
                    string jsonString = await reader.ReadToEndAsync();
                    List<CurveData>? curves = JsonSerializer.Deserialize<List<CurveData>>(jsonString);
                    if (curves == null)
                    {                        
                        throw new Exception("Failed to deserialize JSON data.");
                    }
                    return curves;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Implement Get CurveData by name and date async method.
         * Check whether the directory and file exists.
         * If the directory and file does not exist throw exception.
         * Using file stream open and read the file.
         * Deserialize JSON from the file to the list of CurveData objects asyncronously.
         * Find the CurveData by name and date.
         * Return CurveData.
         * */

        public async Task<CurveData> GetCurveDataAsync(string curveName, int curveDate)
        {
            string jsonFilePath = JsonFilePath;
            try
            {
                var jsonDirectory = Path.GetDirectoryName(jsonFilePath);
                if (!Directory.Exists(jsonDirectory))
                {
                    throw new FileNotFoundException("The JsonFile does not exist.");
                }
                using (StreamReader reader = new(jsonFilePath))
                {
                    string jsonString = await reader.ReadToEndAsync();
                    List<CurveData>? curves = JsonSerializer.Deserialize<List<CurveData>>(jsonString);
                    if (curves == null)
                    {
                        throw new Exception("Failed to deserialize JSON data.");
                    }
                    CurveData? curve = curves.FirstOrDefault(c => c.CurveName == curveName && c.CurveDate == curveDate);
                    if (curve == null)
                    {
                        throw new Exception("CurveData not found in the list.");
                    }
                    return curve;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Implement Create CurveData async method.
         * Check whether the directory and file exists.
         * If the directory and file does not exist create the file.
         * Using file stream open and read the file.
         * Deserialize JSON from the file to the list of CurveData objects asyncronously.
         * Add CurveData to the list.
         * Seriallize the list to JSON.
         * Write JSON to the file.
         * */

        public async Task CreateCurveDataAsync(CurveData curveData)
        {
            string jsonFilePath = JsonFilePath;
            try
            {
                var jsonDirectory = Path.GetDirectoryName(jsonFilePath);
                if (!Directory.Exists(jsonDirectory))
                {
                    if (jsonDirectory == null)
                    {
                        throw new ArgumentException("The jsonDirectory is null.");
                    }
                    Directory.CreateDirectory(jsonDirectory);
                }
                using (StreamReader reader = new(jsonFilePath))
                {
                    string jsonString = await reader.ReadToEndAsync();
                    List<CurveData>? curves = JsonSerializer.Deserialize<List<CurveData>>(jsonString);
                    if (curves == null)
                    {
                        throw new Exception("Failed to deserialize JSON data.");
                    }
                    curves.Add(curveData);
                    using (StreamWriter writer = new (jsonFilePath))
                    {
                        var options = new JsonSerializerOptions { WriteIndented = true };
                        string serializedData = JsonSerializer.Serialize(curves, options);
                        await writer.WriteAsync(serializedData);
                    }
                }                
            }
            catch (Exception)
            {
                throw;
            }
        }

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

        public async Task<CurveData> UpdateCurveDataAsync(CurveData newData)
        {
            string jsonFilePath = JsonFilePath;
            try
            {
                var jsonDirectory = Path.GetDirectoryName(jsonFilePath);
                if (!Directory.Exists(jsonDirectory))
                {
                    if (jsonDirectory == null)
                    {
                        throw new ArgumentException("The jsonDirectory is null.");
                    }
                    Directory.CreateDirectory(jsonDirectory);
                }
                using (StreamReader reader = new(jsonFilePath))
                {
                    string jsonString = await reader.ReadToEndAsync();
                    List<CurveData>? curves = JsonSerializer.Deserialize<List<CurveData>>(jsonString);
                    if (curves == null)
                    {
                        throw new Exception("Failed to deserialize JSON data.");
                    }

                    CurveData? curve = curves.Find(n => n.CurveName == newData.CurveName && n.CurveDate == newData.CurveDate);
                    if (curve == null)
                    {
                        throw new Exception("CurveData not found in the list.");
                    }
                    curve.Currency = newData.Currency;
                    curve.CurvePoints = newData.CurvePoints;                    

                    using (StreamWriter writer = new(jsonFilePath))
                    {
                        var options = new JsonSerializerOptions { WriteIndented = true };
                        string serializedData = JsonSerializer.Serialize(curves, options);
                        await writer.WriteAsync(serializedData);
                    }

                    return curve;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

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
        public async Task DeleteCurveDataAsync(string curveName, int curveDate)
        {
            string jsonFilePath = JsonFilePath;
            try
            {
                var jsonDirectory = Path.GetDirectoryName(jsonFilePath);
                if (!Directory.Exists(jsonDirectory))
                {
                    if (jsonDirectory == null)
                    {
                        throw new ArgumentException("The jsonDirectory is null.");
                    }
                    Directory.CreateDirectory(jsonDirectory);
                }
                using (StreamReader reader = new(jsonFilePath))
                {
                    string jsonString = await reader.ReadToEndAsync();
                    List<CurveData>? curves = JsonSerializer.Deserialize<List<CurveData>>(jsonString);
                    if (curves == null)
                    {
                        throw new Exception("Failed to deserialize JSON data.");
                    }

                    CurveData? curve = curves.Find(n => n.CurveName == curveName && n.CurveDate == curveDate);
                    if (curve == null)
                    {
                        throw new Exception("CurveData not found in the list.");
                    }
                    curves.Remove(curve);

                    using (StreamWriter writer = new(jsonFilePath))
                    {
                        var options = new JsonSerializerOptions { WriteIndented = true };
                        string serializedData = JsonSerializer.Serialize(curves, options);
                        await writer.WriteAsync(serializedData);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
