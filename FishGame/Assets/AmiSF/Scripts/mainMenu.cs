using TMPro;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    public GameObject gameMgr;
    public GameObject newGameMgr;
    public GameObject mainMenuOverlay;
    public miniGameMgr mgh;
    public TMP_Text txt;

    private void Start()
    {
        txt.text = "High: " + PlayerPrefs.GetInt("HIGH");
    }

    void Update()
    {
        if (newGameMgr)
        {
            if (mainMenuOverlay.activeSelf)
            {
                mainMenuOverlay.SetActive(false);
            }
            if (mgh)
            {
                if (mgh.hp <= 0 && mgh.timer <= 0)
                {
                    Destroy(newGameMgr);
                }
            }
        }
        if (!newGameMgr)
        {
            if (!mainMenuOverlay.activeSelf)
            {
                mainMenuOverlay.SetActive(true);
                txt.text = "High: " + PlayerPrefs.GetInt("HIGH");
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                newGameMgr = Instantiate(gameMgr);
                newGameMgr.transform.position = Vector3.zero;
            }
        }
    }
}