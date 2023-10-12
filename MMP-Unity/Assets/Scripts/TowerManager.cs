using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour
{
    private TowerButton buttonPress;
    public SpriteRenderer renderSprite;

    private bool act = false;
    private bool sell = false;
    // Start is called before the first frame update
    void Start()
    {
        renderSprite = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {



        if (act)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (GameObject.Find("playerbase").GetComponent<PlayerBehaviour>().gold >= buttonPress.obj.GetComponent<TowerBehaviour>().price && renderSprite.enabled == true)
                {
                    Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero);
                    if (hit.collider != null)
                    {
                        if (hit.collider.gameObject.tag == "TagEmptySlot")
                        {
                            SoundManager.PlaySound("towerbuy");
                            hit.collider.tag = "Untagged";
                            PlaceTower(hit);
                            act = false;
                        }
                    }
                }

            }
            if (Input.GetMouseButtonDown(1))
            {
                renderSprite.enabled = false;
                act = false;
            }
        }
        if (sell)
        {
            if (Input.GetMouseButtonDown(0))
            {

                Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.tag == "TagTower")
                    {
                        SoundManager.PlaySound("towerbuy");
                        SellTower(hit);
                        sell = false;
                    }
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                renderSprite.enabled = false;
                sell = false;
            }
        }
        if (renderSprite.enabled)
        {
            FollowMouse();
        }

    }
    public void activate()
    {
        act = true;
    }
    public void selling()
    {
        sell = true;
    }
    void SellTower(RaycastHit2D inp)
    {
        Instantiate(buttonPress.obj, new Vector3(inp.transform.position.x, inp.transform.position.y - 0.5f, inp.transform.position.z), Quaternion.identity);

        DisableDrag();
        GameObject.Find("playerbase").GetComponent<PlayerBehaviour>().gold += inp.collider.gameObject.GetComponent<TowerBehaviour>().price / 2;
        Destroy(inp.collider.gameObject);
    }
    void PlaceTower(RaycastHit2D inp)
    {

        Instantiate(buttonPress.obj, new Vector3(inp.transform.position.x, inp.transform.position.y + 0.5f, inp.transform.position.z), Quaternion.identity);
        Destroy(inp.collider.gameObject);
        DisableDrag();
        GameObject.Find("playerbase").GetComponent<PlayerBehaviour>().gold -= buttonPress.obj.GetComponent<TowerBehaviour>().price;
    }
    public void SelectedTower(TowerButton towerSelected)
    {

        buttonPress = towerSelected;
        if (GameObject.Find("playerbase").GetComponent<PlayerBehaviour>().gold >= buttonPress.obj.GetComponent<TowerBehaviour>().price)
        {
            EnableDrag(buttonPress.spr);
            //Debug.Log("Pressed"+buttonPress.gameObject);
        }

    }
    public void SelectedTower2(TowerButton towerSelected)
    {

        buttonPress = towerSelected;

        EnableDrag(buttonPress.spr);
        //Debug.Log("Pressed"+buttonPress.gameObject);


    }
    public void EnableDrag(Sprite sprite)
    {
        renderSprite.enabled = true;
        renderSprite.sprite = sprite;
    }
    public void DisableDrag()
    {
        renderSprite.enabled = false;
    }
    public void FollowMouse()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }
}