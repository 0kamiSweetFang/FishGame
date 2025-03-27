using TMPro;
using UnityEngine;

public class spell : MonoBehaviour
{
    public miniGameHelper mgh;
    public TMP_Text insttxt;
    public TMP_Text txt;
    public AudioSource errSource;
    public string[] wordList;
    public string targetWord;
    public string inp;

    void Start()
    {
        targetWord = wordList[Random.Range(0, wordList.Length)].ToLower();
        insttxt.text = targetWord;
    }

    void Update()
    {
        typies();
        txt.text = inp;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (inp == targetWord)
            {
                mgh.finalScore = 1;
            }
            else
            {
                inp = "";
                errSource.Play();
            }
        }
    }

    void typies()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            inp += "a";
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            inp += "b";
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            inp += "c";
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            inp += "d";
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            inp += "e";
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            inp += "f";
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            inp += "g";
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            inp += "h";
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            inp += "i";
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            inp += "j";
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            inp += "k";
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            inp += "l";
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            inp += "m";
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            inp += "n";
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            inp += "o";
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            inp += "p";
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            inp += "q";
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            inp += "r";
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            inp += "s";
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            inp += "t";
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            inp += "u";
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            inp += "v";
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            inp += "w";
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            inp += "x";
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            inp += "y";
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            inp += "z";
        }
    }
}