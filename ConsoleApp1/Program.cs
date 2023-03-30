namespace ConsoleApp1
{
    internal class Program
    {
        static  void Main(string[] args)
        {
            //var testDataSet = new List<int>() { 1, 2, 3 };
            //var result =testDataSet.Select(async x =>new Value()
            //{
            //    name = await SimulatedAsyncIOCall(x),
            //});

            //foreach (var item in result)
            //{
                
            //}

            
        }

        public class Value
        {
            public string name { get; set; }
        }


        public static async Task<string> SimulatedAsyncIOCall(int i)
        {
            await Task.Delay(0);
            return i.ToString();
        }
    }

}