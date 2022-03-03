#nullable disable

namespace RoundRobin;

class RoundRobinApp
{
    protected static Queue<string> onMap = new();
    protected static List<string> offMap = new();

    private static bool inputComplete = false;
    private static int numParticipants;
    private static int numSittingOut;
    private static string strNumParticipants;
    private static string strNumSittingOut;
    private static string strName;

    public static void Main()
    {
        try{
            while(inputComplete == false){           
                Console.WriteLine("Enter Number of Participants:");
                strNumParticipants = Console.ReadLine();

                if (strNumParticipants == null){
                        Console.WriteLine("Invalid Input, Please Try again\n");
                    }
                numParticipants = Convert.ToInt32(strNumParticipants);

                Console.WriteLine("Enter Number Sitting Out");
                strNumSittingOut = Console.ReadLine();

                if (strNumSittingOut == null){
                        Console.WriteLine("Invalid Input, Please Try again\n");
                    }
                numSittingOut = Convert.ToInt32(strNumSittingOut); 
                
                for(int i = 0; i<numParticipants;i++){

                    Console.WriteLine($"Enter Name {i+1}");
                    strName = Console.ReadLine();

                    if (strName == null){
                        Console.WriteLine("Invalid Input, Please Try again\n");
                    }

                    onMap.Enqueue(strName);

                    Console.WriteLine($"Enqueued Name {i+1}");
                }
                inputComplete = true;
            }
        }
        catch(Exception e){
            Console.WriteLine(e.GetType().FullName);
            Console.WriteLine(e.Message);
        }

        for(int i = 0; i < numSittingOut; i++){
            offMap.Add(onMap.First());
            onMap.Dequeue();
        }

        for (int i = 0; i < numParticipants; i++){
            Console.WriteLine($"\nRound {i+1}");
            Extensions.printOffMap(offMap);
            Extensions.printOnMap(onMap);

            for(int x = 0; x < numSittingOut; x++){
                onMap.Enqueue(offMap[x]);
                offMap.RemoveAt(x);
                offMap.Add(onMap.Dequeue());
            }
        }
    }
}