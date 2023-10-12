using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Vector3 coords;
    [SerializeField] private int spawnCount = 1;
    [SerializeField] private int spawnRate = 1;
    [SerializeField] public GameObject youWon;
    [SerializeField] public AudioSource clap;
    bool switch0;
    private float count = 0f;
    [SerializeField] public GameObject objToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        switch0 = true;
        spawnCount = GameObject.Find("SandboxSettings").GetComponent<SandboxSettings>().enemyCount;
        coords = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        spawnRate = 1 / spawnRate;
        count += (spawnRate + 1f);

    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (spawnCount > 0)
        {
            if (count >= spawnRate)
            {
                objToSpawn = Instantiate(objToSpawn, new Vector3(-coords.x * 1f, coords.y * 0.66f, 0), Quaternion.identity);
                count = 0;
                spawnCount--;
            }
        }
        if (switch0)
        {
            if (spawnCount == 0)
            {

                if (GameObject.FindGameObjectsWithTag("TagEnemy").Length == 0)
                {
                    if (GameObject.FindGameObjectWithTag("TagPlayer").GetComponent<PlayerBehaviour>().health > 0)
                    {
                        switch0 = false;
                        youWon.SetActive(true);
                        clap.Play();
                    }
                }
            }
        }
    }

}
