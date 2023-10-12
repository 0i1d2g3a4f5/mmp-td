using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCap : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int targetFrameRate = 140;
    [SerializeField] public GameObject counter;
    private float ti, ta;
    void Start()
    {
        ti = 0f;
        ta = 0.25f;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }

    // Update is called once per frame
    void Update()
    {
        ti += Time.deltaTime;
        if (ti >= ta)
        {
            counter.GetComponent<Text>().text = "FPS = " + Mathf.RoundToInt(1 / Time.deltaTime).ToString() + "\nTargetFPS = " + targetFrameRate.ToString();
            ti = 0f;
        }
    }
}
