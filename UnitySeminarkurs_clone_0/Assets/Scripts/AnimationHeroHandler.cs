using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHeroHandler : MonoBehaviour
{
    public GameObject[] idleAnimation;
    public GameObject[] walkAnimation;
    public GameObject[] attackAnimation;
    public GameObject[] hitAnimation;

    // Start is called before the first frame update
    void Start()
    {
        inactive();
    }


    public void walk()      //alles auﬂer laufen.
    {
        for (int i = 0; i < idleAnimation.Length; i++)
        {
            walkAnimation[i].SetActive(true);
            attackAnimation[i].SetActive(false);
            idleAnimation[i].SetActive(false);
            hitAnimation[i].SetActive(false);
        }
    }

    public void attack()            //alles aus auﬂer Angriff
    {
        for(int i = 0; i < idleAnimation.Length; i++)
        {
            walkAnimation[i].SetActive(false);
            attackAnimation[i].SetActive(true);
            idleAnimation[i].SetActive(false);
        }
    }


    public void inactive()          //alles aus, auﬂer idle
    {
        for (int i = 0; i < idleAnimation.Length; i++)
        {
            walkAnimation[i].SetActive(false);
            attackAnimation[i].SetActive(false);
            idleAnimation[i].SetActive(true);
            hitAnimation[i].SetActive(false);
        }
    }

    public void hitted()                //alles aus, auﬂer getroffen
    {
        for (int i = 0; i < idleAnimation.Length; i++)
        {
            walkAnimation[i].SetActive(false);
            attackAnimation[i].SetActive(false);
            idleAnimation[i].SetActive(false);
            hitAnimation[i].SetActive(true);
        }
    }


}
