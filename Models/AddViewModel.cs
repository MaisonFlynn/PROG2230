﻿using Ass1gnment.Entities;

namespace Ass1gnment.Models
{
    public class AddViewModel
    {
        public Measurement NewMeasurement { get; set; }
        public List<Position>? Position { get; set; }
    }
}
