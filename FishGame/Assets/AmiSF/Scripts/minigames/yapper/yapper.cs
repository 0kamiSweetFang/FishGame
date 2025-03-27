using TMPro;
using UnityEngine;

public class yapper : MonoBehaviour
{
    public miniGameHelper mgh;
    public GameObject[] charSprites;
    public string[] copyPastas;
    public int atWord;
    public string[] selectedCopyPasta;
    public bool lastInpUp;
    public Canvas canvas;
    public TMP_Text txt;

    private void Start()
    {
        lastInpUp = false;
        atWord = 0;
        selectedCopyPasta = copyPastas[Random.Range(0, copyPastas.Length)].Split(' ');
        canvas.worldCamera = mgh.cam;
    }
    
    private void Update()
    {
        if (atWord >= selectedCopyPasta.Length) return;
        if (Input.GetKeyDown(KeyCode.UpArrow) && !lastInpUp)
        {
            lastInpUp = true;
            yap();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && lastInpUp)
        {
            lastInpUp = false;
            yap();
        }
    }
    private void yap()
    {
        txt.text = selectedCopyPasta[atWord];
        atWord++;
        foreach (GameObject cs in charSprites)
        {
            cs.SetActive(false);
        }
        if (lastInpUp)
        {
            charSprites[1].SetActive(true);
        }
        else
        {
            charSprites[0].SetActive(true);
        }
        if (atWord >= selectedCopyPasta.Length)
        {
            mgh.finalScore = 1;
        }
    }
}