using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsSpawner : MonoBehaviour
{
    [SerializeField] GameObject setObj;
    GameObject objSpawned;
    // Start is called before the first frame update

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("TagSettings").GetLength(0) == 0)
        {
            objSpawned = Instantiate(setObj);
            objSpawned.name = "SandboxSettings";
        }
        GameObject.Find("Canvas").transform.Find("Sandboxmode").transform.Find("StartGold").transform.GetChild(0).transform.GetChild(0).transform.Find("PlaceholderPG").GetComponent<TMPro.TextMeshProUGUI>().text = GameObject.FindGameObjectWithTag("TagSettings").GetComponent<SandboxSettings>().playerGold.ToString();
        GameObject.Find("Canvas").transform.Find("Sandboxmode").transform.Find("StartHP").transform.GetChild(0).transform.GetChild(0).transform.Find("PlaceholderPH").GetComponent<TMPro.TextMeshProUGUI>().text = GameObject.FindGameObjectWithTag("TagSettings").GetComponent<SandboxSettings>().playerHealth.ToString();
        GameObject.Find("Canvas").transform.Find("Sandboxmode").transform.Find("EnemyDamage").transform.GetChild(0).transform.GetChild(0).transform.Find("PlaceholderED").GetComponent<TMPro.TextMeshProUGUI>().text = GameObject.FindGameObjectWithTag("TagSettings").GetComponent<SandboxSettings>().enemyDamage.ToString();
        GameObject.Find("Canvas").transform.Find("Sandboxmode").transform.Find("EnemyHealth").transform.GetChild(0).transform.GetChild(0).transform.Find("PlaceholderEH").GetComponent<TMPro.TextMeshProUGUI>().text = GameObject.FindGameObjectWithTag("TagSettings").GetComponent<SandboxSettings>().enemyHealth.ToString();
        GameObject.Find("Canvas").transform.Find("Sandboxmode").transform.Find("BulletDamage").transform.GetChild(0).transform.GetChild(0).transform.Find("PlaceholderBD").GetComponent<TMPro.TextMeshProUGUI>().text = GameObject.FindGameObjectWithTag("TagSettings").GetComponent<SandboxSettings>().bulletDamage.ToString();
        GameObject.Find("Canvas").transform.Find("Sandboxmode").transform.Find("EnemyPrize").transform.GetChild(0).transform.GetChild(0).transform.Find("PlaceholderEP").GetComponent<TMPro.TextMeshProUGUI>().text = GameObject.FindGameObjectWithTag("TagSettings").GetComponent<SandboxSettings>().enemyPrize.ToString();
        GameObject.Find("Canvas").transform.Find("Sandboxmode").transform.Find("EnemyCount").transform.GetChild(0).transform.GetChild(0).transform.Find("PlaceholderEC").GetComponent<TMPro.TextMeshProUGUI>().text = GameObject.FindGameObjectWithTag("TagSettings").GetComponent<SandboxSettings>().enemyCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void changePH(string i)
    {
        GameObject.FindGameObjectWithTag("TagSettings").GetComponent<SandboxSettings>().changePH(i);
    }
    public void changePG(string i)
    {
        GameObject.FindGameObjectWithTag("TagSettings").GetComponent<SandboxSettings>().changePG(i);
    }
    public void changeEH(string i)
    {
        GameObject.FindGameObjectWithTag("TagSettings").GetComponent<SandboxSettings>().changeEH(i);
    }
    public void changeED(string i)
    {
        GameObject.FindGameObjectWithTag("TagSettings").GetComponent<SandboxSettings>().changeED(i);
    }
    public void changeEP(string i)
    {
        GameObject.FindGameObjectWithTag("TagSettings").GetComponent<SandboxSettings>().changeEP(i);
    }
    public void changeBD(string i)
    {
        GameObject.FindGameObjectWithTag("TagSettings").GetComponent<SandboxSettings>().changeBD(i);
    }
    public void changeEC(string i)
    {
        GameObject.FindGameObjectWithTag("TagSettings").GetComponent<SandboxSettings>().changeEC(i);
    }
}
