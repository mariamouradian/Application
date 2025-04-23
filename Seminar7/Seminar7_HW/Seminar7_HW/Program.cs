namespace Seminar7_HW
{
    public class TestClass
    {
        [CustomName("CustomFieldName")]
        public int I = 0;

        public string S = "Hello";
    }

    class Program
    {
        static void Main()
        {
            var testObj = new TestClass();
            testObj.I = 42;
            testObj.S = "World";

            string serialized = SerializationHelper.ObjectToString(testObj);
            Console.WriteLine(serialized); 

            var newObj = new TestClass();
            SerializationHelper.StringToObject(newObj, serialized);

            Console.WriteLine($"I: {newObj.I}, S: {newObj.S}"); 
        }
    }
}
