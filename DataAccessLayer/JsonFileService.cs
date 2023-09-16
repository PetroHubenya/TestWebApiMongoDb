using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class JsonFileService // Apply IDataService interface.
    {
        // Create property, that will store the text file path.

        // Initialise the text file path property through the constructor.

        // Check whether the file exists.

        // If the file does not exist create the file.

        /* Implement Get all CurveData async method.
         * Using file stream open and read the file.
         * Deserialize JSON from the file to the list of CurveData objects asyncronously.
         * Return the list.
         * */

        /* Implement Get all CurveData async method.
         * Using file stream open and read the file.
         * Deserialize JSON from the file to the list of CurveData objects asyncronously.
         * Find the CurveData by name and date.
         * Return CurveData.
         * */

        /* Implement Create CurveData async method.
         * Using file stream open and read the file.
         * Deserialize JSON from the file to the list of CurveData objects asyncronously.
         * Add CurveData to the list.
         * Seriallize the list to JSON.
         * Write JSON to the file.
         * */

        /* Implement Update CurveData method.
         * Using file stream open and read the file.
         * Deserialize JSON from the file to the list of CurveData objects asyncronously.
         * Find the CurveData by name and date in the list.
         * Replace old data with new data.
         * Seriallize the list to JSON.
         * Write JSON to the file.
         * Return CurveData by name and date.
         * */

        /* Implement Delete CurveData method.
         * Using file stream open and read the file.
         * Deserialize JSON from the file to the list of CurveData objects asyncronously.
         * Find the CurveData by name and date in the list.
         * Delete CurveData from the list.
         * Seriallize the list to JSON.
         * Write JSON to the file.
         * */
    }
}
