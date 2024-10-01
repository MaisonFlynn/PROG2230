using Ass1gnment.Entities;

namespace Ass1gnment.Services
{
    public interface IMeasurementService
    {
        public List<Measurement> GetAllMeasurement();
        public Measurement GetMeasurement(int measurementId);
        public int AddMeasurement(Measurement measurement);
        public int UpdateMeasurement(Measurement measurement);
        public int DeleteMeasurement(Measurement measurement);
    }
}
