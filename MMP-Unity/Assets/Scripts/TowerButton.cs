using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{
    [SerializeField] public GameObject obj;
    [SerializeField] public Sprite spr;
    // Start is called before the first frame update
    void Start()
    {

        {
            if (obj.tag != "TagEmptySlot")
            {
                this.GetComponentInChildren<Text>().text = obj.GetComponent<TowerBehaviour>().price.ToString();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
