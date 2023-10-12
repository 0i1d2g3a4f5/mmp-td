using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public GameOverScreen GameOverScreen;

    public int health;
    public int gold;
    private string text1, text2;
    // Start is called before the first frame update
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
    void Start()
    {
        health = GameObject.Find("SandboxSettings").GetComponent<SandboxSettings>().playerHealth;
        gold = GameObject.Find("SandboxSettings").GetComponent<SandboxSettings>().playerGold;
        ResumeGame();
    }

    // Update is called once per frame
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    void Update()
    {
        text1 = "Health:" + health.ToString();
        GameObject.Find("PlayerHealth").GetComponent<Text>().text = text1;

        if (health <= 0)
        {
            PauseGame();
            GameOverScreen.Setup();
        }

        text2 = "Gold:" + gold.ToString();
        GameObject.Find("PlayerGold").GetComponent<Text>().text = text2;
    }
}
