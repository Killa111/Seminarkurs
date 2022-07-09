using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public void startWalkingAnimation(string nameHero, GameObject goHero)
    {

    }

    public void stopWalkingAnimation(string nameHero, GameObject goHero)
    {

    }

    public void startAttackAnimation(string nameAttackingHero, GameObject goAttackingHero,
        string nameAttackedHero, GameObject goAttackedHero)
    {

        attackAnimationEnded(nameAttackingHero, goAttackingHero, nameAttackedHero, goAttackedHero);
    }

    private void attackAnimationEnded(string nameAttackingHero, GameObject goAttackingHero,
        string nameAttackedHero, GameObject goAttackedHero)
    {
        this.GetComponent<Game>().doAttackDamage(nameAttackingHero, goAttackingHero, nameAttackedHero, goAttackedHero);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
