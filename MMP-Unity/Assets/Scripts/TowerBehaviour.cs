using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    [SerializeField] float rateOfFire;
    [SerializeField] public int price;
    float count = 0f;
    public BulletSpawner b;
    // Start is called before the first frame update
    void Start()
    {
        rateOfFire = 1f / rateOfFire;
        GameObject a = GameObject.Find("BulletSpawner");
        b = (BulletSpawner)a.GetComponent(typeof(BulletSpawner));
    }

    // Update is called once per frame
    public float closestDistance()
    {
        float closestDist = Mathf.Infinity;
        GameObject closestEne = null;
        foreach (GameObject next in GameObject.FindGameObjectsWithTag("TagEnemy"))
        {
            float dist = (transform.position - next.transform.position).sqrMagnitude;
            if (dist < closestDist)
            {
                closestDist = dist;
                closestEne = next;

            }
        }
        return closestDist;
    }

    void Update()
    {
        count += Time.deltaTime;
        if ((count >= rateOfFire) && (closestDistance() < 20))
        {
            SoundManager.PlaySound("tower1shot");
            //Debug.Log(closestDistance());
            b.BulletSpawnFunc(transform.position, transform.rotation);
            count = 0;
        }
    }
}
