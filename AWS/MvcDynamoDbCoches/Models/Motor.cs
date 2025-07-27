﻿using Amazon.DynamoDBv2.DataModel;
using System.Globalization;

namespace MvcDynamoDbCoches.Models
{
    public class Motor
    {
        [DynamoDBProperty("tipo")]
        public string Tipo { get; set; }
        [DynamoDBProperty("caballos")]
        public int Caballos { get; set; }
        [DynamoDBProperty("potencia")]
        public int Potencia { get; set; }
    }
}
