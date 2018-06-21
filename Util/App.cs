namespace Util
{
    public static class App
    {
        public static void StartApp(string[] args)
        {
            switch (args[0])
            {
                case "addMode":
                    var mode = new AddMode();
                    mode.Execute();
                    break;
                case "editMode":
                    (new EditMode()).DoIt();
                    break;
                case "readMode":
                    (new ReadMode()).DoThat(args, args[1]);
                    break;
                case "godMode":
                    System.Console.WriteLine("Your not god!!");
                    break;
                default:
                    System.Console.WriteLine("Parameter error");
                    break;
            }
        }
    }
}