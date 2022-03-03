namespace RoundRobin;
class Extensions{
    public static void printOnMap(Queue<string> onMap){
        Console.WriteLine("\nOn Map:");
            foreach(string s in onMap){
                Console.WriteLine(s);
            }
    }

    public static void printOffMap(List<string> offMap){
        Console.WriteLine("Off Map:");
            foreach(string s in offMap){
                Console.WriteLine(s);
            }
    }
}