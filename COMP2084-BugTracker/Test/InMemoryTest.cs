using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COMP2084_BugTracker.Controllers;
using COMP2084_BugTracker.Data;
using COMP2084_BugTracker.Models;

namespace COMP2084_BugTracker.Test
{
    public class InMemoryTest
    {
        protected readonly DbContextOptions<ApplicationDbContext> _opts;

        // generates connection
        public InMemoryTest()
        {
            _opts = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "BugTracker").Options;
        }

        // creates data to test with
        protected List<Project> MakeFakeProjects(int i)
        {
            var projects = new List<Project>();

            for (int j = 0; j < i; j++)
            {
                projects.Add(new Project
                {
                    Name = $"test{j}",
                    Version = 1,
                    Description = $"testDesc{j}",
                    Bugs = new List<Bug>()
                });
            }
            return projects;
        }

        protected List<Bug> MakeFakeBugs(int i)
        {
            var bugs = new List<Bug>();

            for (int j = 0; j < i; j++)
            {
                bugs.Add(new Bug
                {
                    Name = $"testFirst{j}",
                    Description = $"testLast{j}",
                    Priority = $"testPrio{j}",
                    Status = $"testStat{j}",
                });
            }
            return bugs;
        }
    }
}
