using System.Linq;
using ExampleProject.Controllers;
using ExampleProject.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
	        var options = new DbContextOptionsBuilder<MyContext>()
		        .UseInMemoryDatabase("dbNamn") // Databasinstansen får samma namn.
		        .Options;

	        using (var context = new MyContext(options))
	        {
		        var item = new ExampleModel()
		        {
			        Name = "Test",
			        Value = "Value"
		        };
		        context.Examples.Add(item);
		        context.SaveChanges();
	        }

	        using (var context = new MyContext(options))
	        {
		        var item = context.Examples.FirstOrDefault(x => x.Name == "Test");
				Assert.IsNotNull(item);
	        }
		}

	    [TestMethod]
	    public void TestMethod2()
	    {
		    var options = new DbContextOptionsBuilder<MyContext>()
			    .UseInMemoryDatabase("dbNamn") // Databasinstansen får samma namn.
			    .Options;
		    var item = new ExampleModel()
		    {
			    Name = "Test",
			    Value = "Value"
		    };
			var controller = new ExampleController(new MyContext(options));

		    IActionResult postResult = controller.Post(item);

		    var objectResult = (OkObjectResult) postResult;
		    int id = (int) objectResult.Value;

			IActionResult getResult = controller.Get(id);
		    OkObjectResult objectResult2 = (OkObjectResult) getResult;
		    ExampleModel model = (ExampleModel) objectResult2.Value;
		    Assert.AreEqual(item.Name, model.Name);
		}
    }
}
