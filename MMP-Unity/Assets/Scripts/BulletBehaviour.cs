using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 420;


    public GameObject closestEnemy()
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
        return closestEne;
    }

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {


        this.target = closestEnemy();

    }


    // Update is called once per frame
    void Update()
    {
        // Vector3 diff = (target.transform.position - transform.position).normalized;
        //GetComponent<Rigidbody2D>().velocity = new Vector2(diff.x, diff.y) * speed * Time.deltaTime;

        if (!target)
        {
            target = closestEnemy();

        }

        if (!target)
        {
            Destroy(this.gameObject);

        }
        if (target)
        {
            GetComponent<Rigidbody2D>().velocity = ((target.transform.position - transform.position).normalized * speed * Time.deltaTime);
            // transform.position += (target.transform.position - transform.position).normalized * speed * Time.deltaTime;
            transform.rotation *= Quaternion.AngleAxis(Vector3.Angle(transform.right, target.transform.position - transform.position), Vector3.Cross(transform.right, target.transform.position - transform.position));
            transform.rotation *= Quaternion.AngleAxis(-90, new Vector3(0, 0, 1));
        }

    }
}
