using Microsoft.Extensions.Configuration;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Logging.WebApi.Helpers
{
    public static class ElasticHelper
    {

        public static ElasticsearchSinkOptions ConfigurationElasticSink(IConfigurationRoot configuration, string environment)
        {

            var elasticSink = new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]));
            elasticSink.AutoRegisterTemplate = true;
            elasticSink.IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.Now:yyyy-MM-dd}";

            return elasticSink;
        }
    }
}
