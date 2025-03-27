using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class miniGameMgr : MonoBehaviour
{
    public GameObject[] miniGames;
    public int round;
    public float speedMod;
    public GameObject mg;
    public miniGameHelper mgh;
    public GameObject switchScreenFx;
    public float timer;
    public AudioSource timerSfx;
    public TMP_Text txt;
    public GameObject[] hpGos;
    public int hp;
    public GameObject happy;
    public GameObject sad;
    public GameObject overlay;
    public GameObject[] groggSprites;
    public GameObject[] groggAnim;
    public GameObject[] ziverSprites;
    public GameObject cursor;
    public Camera cam;
    public TMP_Text scoreTxt;
    public int score;
    public int highScore;
    public GameObject angyKnuckles;
    public TMP_Text knucklesTimerTxt;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HIGH");
        round = 0;
        if (speedMod < 1)
        {
            speedMod = 1;
        }
        timer = 6;
        hp = 4;
        overlay.SetActive(true);
        updateHP();
        txt.text = "Get\nReady!";
        scoreTxt.text = "Score: " + score + "\nHigh: " + highScore;
    }

    private void updateHP()
    {
        foreach (GameObject hpg in hpGos)
        {
            hpg.SetActive(false);
        }
        for (int i = 0; i < hp; i++)
        {
            hpGos[i].SetActive(true);
        }
        if (hp < 1)
        {
            hp = 0;
            //end game
            foreach (GameObject grogg in groggSprites)
            {
                grogg.SetActive(false);
            }
            groggAnim[0].SetActive(true); //spinning
        }
    }

    private void timerShow()
    {
        if (timer < 0.5f)
        {
            if (txt.text != "Go!")
            {
                timerSfx.Play();
                txt.text = "Go!";
            }
        }
        else if (timer < 1.5f)
        {
            if (txt.text != "1")
            {
                timerSfx.Play();
                txt.text = "1";
            }
        }
        else if (timer < 2.5f)
        {
            if (txt.text != "2")
            {
                timerSfx.Play();
                txt.text = "2";
            }
        }
        else if (timer < 3.5f)
        {
            if (txt.text != "3")
            {
                timerSfx.Play();
                txt.text = "3";
            }
        }
        else if (timer < 4.5f)
        {
            if (txt.text != "Get\nReady!" && txt.text != "Faster!!!")
            {
                txt.text = "Get\nReady!";
                resetSprites();
                if (round >= 5)
                {
                    round -= 5;
                    speedMod += 0.05f;
                    txt.text = "Faster!!!";
                }
            }
        }
    }

    private void knucklesTimerShow()
    {
        if (mgh.sec < 0.5f)
        {
            if (knucklesTimerTxt.text != "1")
            {
                angyKnuckles.SetActive(true);
                knucklesTimerTxt.text = "1";
            }
        }
        else if (mgh.sec < 1.0f)
        {
            if (knucklesTimerTxt.text != "2")
            {
                angyKnuckles.SetActive(true);
                knucklesTimerTxt.text = "2";
            }
        }
        else if (mgh.sec < 1.5f)
        {
            if (knucklesTimerTxt.text != "3")
            {
                angyKnuckles.SetActive(true);
                knucklesTimerTxt.text = "3";
            }
        }
    }

    private void resetSprites()
    {
        //grogg
        groggSprites[0].SetActive(true);
        groggSprites[1].SetActive(false);
        //ziver
        ziverSprites[0].SetActive(true);
        ziverSprites[1].SetActive(false);
        ziverSprites[2].SetActive(false);
    }

    private void Update()
    {
        if (mgh) //run minigame functions
        {
            timer = 6;
            //mgh.game();
            if (mgh.finalScore > 0) //big w
            {
                gameWin();
            }
            else if (mgh.finalScore < 0) //lose due to misinput/skill issue
            {
                gameLose();
            }
            //lose due to timer
            if (mgh.sec <= 0)
            {
                gameLose();
            }
            else
            {
                mgh.sec -= Time.deltaTime * speedMod;
                knucklesTimerShow();
            }
        }
        else //no minigame active, do countdown on main screen
        {
            if (angyKnuckles.activeSelf || knucklesTimerTxt.text != "")
            {
                angyKnuckles.SetActive(false);
                knucklesTimerTxt.text = "";
            }
            if (timer <= 0)
            {
                txt.text = "";
                if (!mgh && hp > 0)
                {
                    selectMiniGame();
                }
                if (hp < 1)
                {
                    Destroy(this.gameObject);
                }
            }
            else
            {
                timer -= Time.deltaTime * speedMod;
                if (hp > 0)
                {
                    timerShow();
                }
            }
        }
    }

    private void selectMiniGame()
    {
        switchScreenFx.SetActive(false);
        switchScreenFx.SetActive(true);
        mg = Instantiate(miniGames[Random.Range(0, miniGames.Length)]);
        mg.transform.position = Vector3.zero;
        mgh = mg.GetComponent<miniGameHelper>();
        //mgh.sec = 8;
        //mgh.setupGameTime(8);
        overlay.SetActive(false);
        mgh.cursor = cursor;
        mgh.cam = cam;
        mgh.speedMod = speedMod;
    }

    private void endMiniGame()
    {
        groggSprites[0].SetActive(false);
        groggSprites[1].SetActive(true);
        switchScreenFx.SetActive(false);
        switchScreenFx.SetActive(true);
        timer = 6;
        overlay.SetActive(true);
        Destroy(mgh.gameObject);
        round++;
        updateHP();
        if (highScore < score)
        {
            highScore = score;
            PlayerPrefs.SetInt("HIGH", highScore);
        }
        scoreTxt.text = "Score: " + score + "\nHigh: " + highScore;
    }

    private void gameWin()
    {
        score++;
        ziverSprites[0].SetActive(false);
        ziverSprites[1].SetActive(true);
        ziverSprites[2].SetActive(false);
        sad.SetActive(false);
        txt.text = "Good!";
        happy.SetActive(false);
        happy.SetActive(true);
        endMiniGame();
    }

    private void gameLose()
    {
        hp--;
        ziverSprites[0].SetActive(false);
        ziverSprites[1].SetActive(false);
        ziverSprites[2].SetActive(true);
        happy.SetActive(false);
        txt.text = "Bad!";
        sad.SetActive(false);
        sad.SetActive(true);
        endMiniGame();
    }
}