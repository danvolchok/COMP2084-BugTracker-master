using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COMP2084_BugTracker.Controllers;
using COMP2084_BugTracker.Data;
using COMP2084_BugTracker.Models;

namespace COMP2084_BugTracker.Test
{
    public class ProjectsControllerTest : InMemoryTest
    {
        [Fact]
        public async Task Index_Returns_ViewResult_And_ProjectList()
        {
            // disposes this test db after use
            using (var testDb = new ApplicationDbContext(this._opts))
            {
                var testCtrl = new ProjectsController(testDb);
                var result = await testCtrl.Index();
                var resVr = Assert.IsType<ViewResult>(result);
                Assert.IsAssignableFrom<IEnumerable<Project>>(resVr.ViewData.Model);
            }
        }

 

        [Fact]
        public async Task Add_And_Remove()
        {
            using (var testDb = new ApplicationDbContext(this._opts))
            {
                var testCtrl = new ProjectsController(testDb);
                var fakeProjects = MakeFakeProjects(3);

                foreach(var project in fakeProjects)
                {
                    var res = await testCtrl.Create(project);
                    var resVr = Assert.IsType<RedirectToActionResult>(res);
                    Assert.Equal("Index", resVr.ActionName);
                }

                var indexRes = await testCtrl.Index();
                var indexResVr = Assert.IsType<ViewResult>(indexRes);
                var returnedProjects = Assert.IsAssignableFrom<IEnumerable<Project>>(indexResVr.ViewData.Model);

                foreach(var project in returnedProjects)
                {
                    Assert.Contains(project, returnedProjects);
                }

                foreach(var project in returnedProjects)
                {
                    var res = await testCtrl.DeleteConfirmed(project.Id);
                    var resVr = Assert.IsType<RedirectToActionResult>(res);
                    Assert.Equal("Index", resVr.ActionName);
                }
            }
        }


    }
}
