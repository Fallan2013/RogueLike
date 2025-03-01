namespace RogueLike
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            Map map = new ();
            FoV fov = new FoV(map);
            
            //Menu startMenu = new ();
            Character Warior = new(1, 10, 5);
            bool gameStart = true;
            map.mapCreater(40, 40);
            while (gameStart)
            {
                map.mapPrinter(40, 40);
                map.Move();
            }
            Save save = new();
            
            
           
           
        }
    }
}
