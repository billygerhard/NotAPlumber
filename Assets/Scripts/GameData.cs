using System.Collections.Generic;

public class GameData
{
    public static int points = 0;
    public static int lives = 3;
    public static float timer = 60;

    public static Dictionary<string, int> levelPointRequirement = new Dictionary<string, int>()
    {
        {"Level1", 3}
    };
}
