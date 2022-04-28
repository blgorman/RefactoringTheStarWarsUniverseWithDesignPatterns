﻿using Microsoft.Extensions.Configuration;

namespace StarWarsUniverse_v1
{
    public class Program
    {
        private static IConfigurationRoot _configuration;


        public static void Main(string[] args)
        {
            BuildOptions();
            Console.WriteLine("Hello World");

            var configCheck = _configuration["SimpleKey:SimpleValue"];
            Console.WriteLine($"Configuration: {configCheck}");
        }

        private static void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
        }
    }
}
