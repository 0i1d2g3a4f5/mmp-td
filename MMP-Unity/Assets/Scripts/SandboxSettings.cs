using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SandboxSettings : MonoBehaviour

{
    public int playerHealth = 100;
    public int playerGold = 400;
    public int enemyHealth = 100;
    public int enemyDamage = 20;
    public int bulletDamage = 20;
    public int enemyPrize = 50;
    public int enemyCount = 15;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        



    }
    public void changePH(string inp)
    {
        playerHealth = int.Parse(inp);

    }
    public void changeEP(string inp)
    {
        enemyPrize = int.Parse(inp);

    }
    public void changePG(string inp)
    {
        playerGold = int.Parse(inp);

    }
    public void changeEH(string inp)
    {
        enemyHealth = int.Parse(inp);

    }
    public void changeED(string inp)
    {
        enemyDamage = int.Parse(inp);

    }
    public void changeBD(string inp)
    {
        bulletDamage = int.Parse(inp);

    }
    public void changeEC(string inp)
    {
        enemyCount = int.Parse(inp);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
