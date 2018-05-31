using System.Linq;
using ExampleProject.Database;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.Controllers
{
    [Route("api/Example")]
	public class ExampleController : Controller
	{
		private readonly MyContext context;

		public ExampleController(MyContext context)
		{
			this.context = context;
		}

		//[HttpGet]
		//public ActionResult Get()
		//{
		//	return Ok("Hello");
		//}

		[HttpGet]
		public IActionResult Get(int id)
		{
			var item = context.Examples.FirstOrDefault(x => x.Id == id);
			return Ok(item);
		}

		[HttpPost]
		public IActionResult Post(ExampleModel model)
		{
			//context.Examples.Add(new Database.ExampleModel()
			//{
			//	Id = 1,
			//	Name = "NewName",
			//	Value = "Hello"
			//});
			context.Examples.Add(model);
			context.SaveChanges();
			return Ok(model.Id);
		}
	}
}