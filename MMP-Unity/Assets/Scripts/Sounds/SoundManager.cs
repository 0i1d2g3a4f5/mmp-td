using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip tower1shotSound,enemydieSound,towerbuySound,playerhurtSound;
    static AudioSource audioScr;

    void Start(){
        tower1shotSound = Resources.Load<AudioClip>("tower1shot");
        enemydieSound = Resources.Load<AudioClip>("enemydie");
        towerbuySound = Resources.Load<AudioClip>("towerbuy");
        playerhurtSound = Resources.Load<AudioClip>("enemydie");

        audioScr = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip){
        switch (clip){
            case "tower1shot":
                audioScr.PlayOneShot (tower1shotSound);
                break;
            case "enemydie":
                audioScr.PlayOneShot (enemydieSound);
                break;
            case "towerbuy":
                audioScr.PlayOneShot (towerbuySound);
                break;
            case "playerhurt":
                audioScr.PlayOneShot (playerhurtSound);
                break;
        }
    }
}
