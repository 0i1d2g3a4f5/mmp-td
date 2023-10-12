using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{


    [SerializeField] private float speed = 140;
    private Vector3 coords;
    private Vector3[] currentAim = new Vector3[4];
    private int i = 0;
    private int health;
    private int damage;
    private int prize;
    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.Find("SandboxSettings").GetComponent<SandboxSettings>().enemyHealth;
        damage = GameObject.Find("SandboxSettings").GetComponent<SandboxSettings>().enemyDamage;
        prize = GameObject.Find("SandboxSettings").GetComponent<SandboxSettings>().enemyPrize;
        coords = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        currentAim[0] = new Vector3(coords.x * 0.43f, coords.y * 0.62f, 0);
        currentAim[1] = new Vector3(coords.x * 0.57f, -coords.y * 0.1f, 0);
        currentAim[2] = new Vector3(coords.x * 0.48f, -coords.y * 0.65f, 0);
        currentAim[3] = new Vector3(-coords.x * 0.8f, -coords.y * 0.69f, 0);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "TagBullet")
        {
            health -= 20;
            Destroy(coll.gameObject);
            if (health <= 0)
            {
                SoundManager.PlaySound("enemydie");
                GameObject.FindGameObjectWithTag("TagPlayer").GetComponent<PlayerBehaviour>().gold += prize;
                Destroy(this.gameObject);


            }


        }
        if (coll.gameObject.tag == "TagPlayer")
        {
            SoundManager.PlaySound("playerhurt");
            coll.gameObject.GetComponent<PlayerBehaviour>().health -= damage;
            Destroy(this.gameObject);
        }
    }












    // Update is called once per frame
    void Update()
    {
        //Vector3 diff = (currentAim[i] - transform.position).normalized;
        // GetComponent<Rigidbody2D>().velocity = new Vector2(diff.x, diff.y) * speed * Time.deltaTime;
        GetComponent<Rigidbody2D>().velocity = (currentAim[i] - transform.position).normalized * speed * Time.deltaTime;
        // transform.position += (currentAim[i] - transform.position).normalized * speed * Time.deltaTime;

        transform.rotation *= Quaternion.AngleAxis(Vector3.Angle(transform.right, currentAim[i] - transform.position), Vector3.Cross(transform.right, currentAim[i] - transform.position));
        if ((currentAim[i] - transform.position).sqrMagnitude < 0.01f)
        {
            if (i < 3)
            {
                i++;
            }
        }






    }

}
