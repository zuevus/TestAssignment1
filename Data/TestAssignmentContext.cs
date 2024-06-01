﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignment1.Data
{
    public class TestAssignmentContext : DbContext
    {
        private readonly ILogger<TestAssignmentContext> _logger;

        public string DbPath { get; }

        public TestAssignmentContext(IConfiguration configuration, ILogger<TestAssignmentContext> logger)
        {
            _logger = logger;
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var sectioncfg = configuration.GetSection("db");
            DbPath = Path.Join(path, sectioncfg.GetValue<string>("db_name"));

            _logger.LogDebug("Path to DB" + Path.Join(path, configuration.GetValue<string>("db_name")));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Filename = {DbPath}");

    }
}
