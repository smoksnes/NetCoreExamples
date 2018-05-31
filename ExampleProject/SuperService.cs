namespace ExampleProject
{

	public interface ISuperCalculator
	{
		int Add(int x, int y);
	}
	public class SuperCalculator : ISuperCalculator
	{
		public int Add(int x, int y)
		{
			return x + y;
		}
	}
}