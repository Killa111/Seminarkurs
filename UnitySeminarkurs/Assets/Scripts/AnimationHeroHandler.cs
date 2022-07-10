using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHeroHandler : MonoBehaviour
{
    public GameObject idleAnimation;
    public GameObject walkAnimation;
    public GameObject attackAnimation;
    public GameObject hitAnimation;

    // Start is called before the first frame update
    void Start()
    {
        inactive();
    }


    public void walk()      //alles ausauﬂer laufen.
    {
        walkAnimation.SetActive(true);
        attackAnimation.SetActive(false);
        idleAnimation.SetActive(false);
        hitAnimation.SetActive(false);

    }

    public void attack()            //alles aus auﬂer Angriff
    {
        walkAnimation.SetActive(false);
        attackAnimation.SetActive(true);
        idleAnimation.SetActive(false);

    }


    public void inactive()          //alles aus, auﬂer idle
    {
        walkAnimation.SetActive(false);
        attackAnimation.SetActive(false);
        idleAnimation.SetActive(true);
        hitAnimation.SetActive(false);
    }

    public void hitted()                //alles aus, auﬂer getroffen
    {
        walkAnimation.SetActive(false);
        attackAnimation.SetActive(false);
        idleAnimation.SetActive(false);
        hitAnimation.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
