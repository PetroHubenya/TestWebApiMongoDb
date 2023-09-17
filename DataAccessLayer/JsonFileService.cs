using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

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

        // Get all CurveData.
        public async Task<List<CurveData>> GetAllCurvesAsync()
        {
            string jsonFilePath = JsonFilePath;
            try
            {   
                // !
                if (!File.Exists(jsonFilePath))
                {
                    throw new FileNotFoundException("The JsonFile does not exist.");
                }
                else
                {
                    using (StreamReader reader = new(jsonFilePath))
                    {
                        string jsonString = await reader.ReadToEndAsync();
                        // !
                        if (string.IsNullOrEmpty(jsonString))
                        {
                            return new List<CurveData>();
                        }
                        List<CurveData>? curves = JsonSerializer.Deserialize<List<CurveData>>(jsonString);
                        if (curves == null)
                        {
                            throw new Exception("Failed to deserialize JSON data.");
                        }
                        return curves;
                    }
                }                
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get CurveData by CurveName and CurveDate.
        public async Task<CurveData> GetCurveDataAsync(string curveName, int curveDate)
        {
            string jsonFilePath = JsonFilePath;
            try
            {
                if (!File.Exists(jsonFilePath))
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

        // Create CurveData.
        public async Task CreateCurveDataAsync(CurveData curveData)
        {
            string jsonFilePath = JsonFilePath;

            List<CurveData>? curves;

            try
            {                
                if (!File.Exists(jsonFilePath))
                {                    
                    File.Create(jsonFilePath).Close();
                }

                using (StreamReader reader = new(jsonFilePath))
                {
                    string jsonString = await reader.ReadToEndAsync();

                    if (string.IsNullOrEmpty(jsonString))
                    {
                        curves = new ();
                    }
                    else
                    {
                        curves = JsonSerializer.Deserialize<List<CurveData>>(jsonString);

                        if (curves == null)
                        {
                            throw new Exception("Failed to deserialize JSON data.");
                        }
                    }
                }

                if (curves.Exists(c => c._id == curveData._id))
                {
                    throw new Exception("Object with the same id already exists. Please, provide a unique id.");   
                }
                else
                {
                    curves.Add(curveData);

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

        // Update CurveData by CurveName (asynchronous).
        public async Task<CurveData> UpdateCurveDataAsync(CurveData newData)
        {
            string jsonFilePath = JsonFilePath;

            List<CurveData>? curves;

            try
            {
                if (!File.Exists(jsonFilePath))
                {
                    File.Create(jsonFilePath).Close();
                }

                using (StreamReader reader = new(jsonFilePath))
                {
                    string jsonString = await reader.ReadToEndAsync();

                    if (string.IsNullOrEmpty(jsonString))
                    {
                        curves = new();
                    }
                    else
                    {
                        curves = JsonSerializer.Deserialize<List<CurveData>>(jsonString);

                        if (curves == null)
                        {
                            throw new Exception("Failed to deserialize JSON data.");
                        }
                    }
                }

                CurveData? curve = curves.Find(n => n.CurveName == newData.CurveName && n.CurveDate == newData.CurveDate);

                if (curve == null)
                {
                    throw new Exception("CurveData not found in the list.");
                }
                else
                {
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

        // Delete CurveData by CurveName and CurveDate (asynchronous).
        public async Task DeleteCurveDataAsync(string curveName, int curveDate)
        {
            string jsonFilePath = JsonFilePath;

            List<CurveData>? curves;

            try
            {
                if (!File.Exists(jsonFilePath))
                {
                    throw new FileNotFoundException("The JsonFile does not exist.");
                }

                using (StreamReader reader = new(jsonFilePath))
                {
                    string jsonString = await reader.ReadToEndAsync();

                    if (string.IsNullOrEmpty(jsonString))
                    {
                        curves = new();
                    }
                    else
                    {
                        curves = JsonSerializer.Deserialize<List<CurveData>>(jsonString);

                        if (curves == null)
                        {
                            throw new Exception("Failed to deserialize JSON data.");
                        }
                    }
                }

                CurveData? curve = curves.Find(n => n.CurveName == curveName && n.CurveDate == curveDate);

                if (curve == null)
                {
                    throw new Exception("CurveData not found in the list.");
                }
                else
                {
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
