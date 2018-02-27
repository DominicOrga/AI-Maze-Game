using System.Collections;
using System.Collections.Generic;

public class Preferences {

    public static int difficulty = 1;

    public static int Difficulty {
        get {
            return difficulty;
        }
        set {
            difficulty = value;
        }
    }
}
