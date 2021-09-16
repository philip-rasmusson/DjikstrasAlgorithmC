namespace Djikstra
{
    public static class Program
    {
        public static void Main()
        {
            //Starts the program by asking for user input and calling the first method
            //with those values, as well as a starting value for total time (0 as default)
            Backend.RunMatrix(UserInput.GetUserInput(), 0);
        }
    }
}