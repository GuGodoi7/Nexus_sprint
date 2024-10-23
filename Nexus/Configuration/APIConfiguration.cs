namespace Nexus.Configuration
{
    public class APIConfiguration
    {
        public string MongoDbConnectionString { get; set; }

        public string MongoDbDatabase { get; set; }

        public SwaggerInfo Swagger { get; set; }

        public class SwaggerInfo
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Email { get; set; }
            public string Name { get; set; }
        }
    }
}