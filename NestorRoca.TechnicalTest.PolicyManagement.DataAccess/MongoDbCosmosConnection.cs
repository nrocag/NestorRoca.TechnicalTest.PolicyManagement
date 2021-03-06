﻿namespace NestorRoca.TechnicalTest.PolicyManagement.DataAccess
{
    using MongoDB.Driver;
    using System.Security.Authentication;

    internal static class MongoDbCosmosConnection
    {   
        private static readonly string connectionString = @"mongodb://cosmodb-tests:sTV5s7DSI72Ra8guY2WFqwfXeFGwbbesev8UKq5LrNnVHpDUvDZYr4zIIqn1w9cfcopJ8peaJBm6amW81fyqsA==@cosmodb-tests.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
        private static IMongoDatabase dataBase;

        public static IMongoDatabase DataBase
        {
            get
            {
                if (dataBase == null)
                {
                    GetDataBase();
                }

                return dataBase;
            }
        }

        private static void GetDataBase()
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            MongoClient mongoClient = new MongoClient(settings);

            dataBase = mongoClient.GetDatabase("ManagementInsurancePolicies");
        }
    }
}
