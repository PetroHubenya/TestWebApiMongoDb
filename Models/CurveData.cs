namespace Models
{
    public class CurveData
    {
        public string _id { get; set; }

        public string CurveName { get; set; }

        public string Currency { get; set; }

        public int CurveDate { get; set; }

        public List<CurvePoint> CurvePoints { get; set; }

    }
}