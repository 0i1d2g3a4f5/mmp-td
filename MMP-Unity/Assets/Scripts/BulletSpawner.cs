using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] public GameObject objToSpawn;

    // Start is called before the first frame update

    void Start()
    {

    }
    public void BulletSpawnFunc(Vector3 coords, Quaternion rotat)
    {
        Instantiate(objToSpawn, coords, rotat);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
