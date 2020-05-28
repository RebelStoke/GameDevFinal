using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Globalization;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private Text killText;
    private Text coinText;
    private Text gameEndText;
    private Text timer;
    private GameObject handGun;
    private GameObject rifle;


    public int isDash = 0;
    public int isHighJump = 0;
    public int isRifle = 0;

    public int kills = 0;
    public int coins = 0;

    private bool gameOver = false;
    private float timeLeft = 30f;


    // Start is called before the first frame update
    void Start()
    {
        killText = GameObject.Find("KillCounter").GetComponent<Text>();
        coinText = GameObject.Find("CoinCounter").GetComponent<Text>();
        gameEndText = GameObject.Find("EndText").GetComponent<Text>();
        timer = GameObject.Find("Timer").GetComponent<Text>();
        handGun = GameObject.Find("Handgun");
        rifle = GameObject.Find("Rifle");
        LoadGame();
        switchWeapons(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (isRifle == 1)
        {
            if (Input.GetKeyDown("1"))
                switchWeapons(false);
            if (Input.GetKeyDown("2"))
                switchWeapons(true);
        }

        updateTimer();
        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void addKill()
    {
        kills++;
        killText.text = "Kills: " + kills.ToString();
    }

    public void addCoin() {
        updateCoins(1);
    }

    private void updateCoins(int value) {
        coins = coins + value;
        coinText.text = "Money: " + coins.ToString();
    }

    public void GameOver(bool win)
    {
        if (win)
        {
            gameEndText.text = "Succes!";
            SaveGame();
        }
        else
            gameEndText.text = "Game Over!";


        Time.timeScale = 0;
        gameOver = true;
    }

    void updateTimer()
    {
        timeLeft -= Time.deltaTime;
        timer.text = timeLeft.ToString();
        if (timeLeft < 0)
        {
            GameOver(true);
        }
    }

   public void unlock(string unlockable) {
        switch (unlockable)
        {
            case "Dash":
                if (coins >= 5){
                    updateCoins(-5);
                    isDash = 1;
                }
                break;
            case "RifleModel":
                if (coins >= 5)
                {
                    updateCoins(-5);
                    isRifle = 1;
                }
                break;
            case "HighJump":
                if (coins >= 5)
                {
                    updateCoins(-5);
                    isHighJump = 1;
                }
                break;
        }    
    }

    public bool isUnlocked(string unlockable) {
        bool isUnlocked = false;
        switch (unlockable)
        {
            case "Dash":
                Debug.Log(isDash);
                if (isDash == 1) {
                    isUnlocked = true;
                }            
                break;
            case "RifleModel":
                Debug.Log(isRifle);
                if (isRifle == 1)
                {
                    isUnlocked = true;
                }
                break;
            case "HighJump":
                Debug.Log(isHighJump);
                if (isHighJump == 1)
                {
                    isUnlocked = true;
                }
                break;
        }
        return isUnlocked;
    }

    private void switchWeapons(bool w) {
        rifle.SetActive(w);
        handGun.SetActive(!w);
    }


    void SaveGame()
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.SetInt("Dash", isDash);
        PlayerPrefs.SetInt("Rifle", isRifle);
        PlayerPrefs.SetInt("HighJump", isHighJump);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }

    void LoadGame()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            isHighJump = PlayerPrefs.GetInt("HighJump");
            isDash = PlayerPrefs.GetInt("Dash");
            isRifle = PlayerPrefs.GetInt("Rifle");
            coins = PlayerPrefs.GetInt("Coins");
            coinText.text = "Money: " + coins.ToString();
        }
        else
            Debug.LogError("There is no save data!");
    }
}
