using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;

public class GamePlay_Manager : MonoBehaviour
{
    public static GamePlay_Manager instance;

    [SerializeField]
    private Text coinTxt, timerTxt, win_Lose_Txt;

    private int coinCount;

    [SerializeField]
    private float timerTreshold = 100f;

    private float timerCount;

    private StringBuilder coinString= new StringBuilder(), timerString= new StringBuilder();

    private bool gameOver;

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private GameObject enemy_Spawner;

    private bool win;

    private void Awake()
    {
        /*if(instance != null) { Destroy(gameObject); }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }*/

        instance = this;

        timerCount = Time.time + 1f;
    }

    private void Update()
    {
        if (gameOver) return;

        CountTimer();

        if (timerTreshold == 0f)
        {
            win = false;
            GameOver();
        }

        if(coinCount == 0)
        {
            win = true;
            GameOver();
        }
            
    }

    public void SetCoinCount(int coinValue)
    {
        coinCount += coinValue;

        coinString.Length = 0;
        coinString.Append("Coins: ");
        coinString.Append(coinCount.ToString());
        coinTxt.text = coinString.ToString();
    }

    void CountTimer()
    {
        if(Time.time > timerCount)
        {
            timerCount = Time.time + 1f;

            timerTreshold--;

            timerString.Length = 0;
            timerString.Append("Time: ");
            timerString.Append(timerTreshold.ToString());

            timerTxt.text = timerString.ToString();
        }
    }

    public void GameOver()
    {
        gameOver= true;

        GameObject.FindWithTag(TagManager.PLAYER_TAG)
            .GetComponent<BallController>().DestroyPlayer();

        enemy_Spawner.SetActive(false);

        Invoke("ShowGameOverPanel", 1f); 
    }

    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);

        if(win) { win_Lose_Txt.text = "That was just luck"; }
        else { win_Lose_Txt.text = "Loser"; }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(0);
    }


}






