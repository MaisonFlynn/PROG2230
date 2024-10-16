﻿using Ass1gnment.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ass1gnment.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly DBContext _dbContext;

        public MeasurementService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Position> GetPosition()
        {
            return _dbContext.Position.ToList();
        }

        public List<Measurement> GetAllMeasurement()
        {
            return _dbContext.Measurement.Include(m => m.Position).ToList();
        }

        public Measurement GetMeasurement(int measurementID)
        {
            return _dbContext.Measurement.Find(measurementID);
        }

        public int AddMeasurement(Measurement measurement)
        {
            _dbContext.Measurement.Add(measurement);
            _dbContext.SaveChanges();

            return measurement.MeasurementID;
        }

        public int UpdateMeasurement(Measurement measurement)
        {
            _dbContext.Measurement.Update(measurement);
            _dbContext.SaveChanges();

            return measurement.MeasurementID;
        }

        public int DeleteMeasurement(Measurement measurement)
        {
            _dbContext.Measurement.Remove(measurement);
            _dbContext.SaveChanges();

            return measurement.MeasurementID;
        }
    }
}
