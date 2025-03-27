using UnityEngine;

public class miniGameHelper : MonoBehaviour
{
    public int finalScore;
    public float sec;
    public GameObject cursor;
    public Camera cam;
    public float speedMod;

    public void setupGameTime(int newSec)
    {
        sec = newSec;
    }

    //public void game() { }
}
