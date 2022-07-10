using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    AnimationHeroHandler animationHandler;

    void Start()
    {
        
    }

    public void startWalkingAnimation(string nameHero, GameObject goHero)
    {
       animationHandler =goHero.GetComponent<AnimationHeroHandler>();
        animationHandler.walk();
    }

    public void stopWalkingAnimation(string nameHero, GameObject goHero)
    {
        animationHandler = goHero.GetComponent<AnimationHeroHandler>();
        animationHandler.inactive();
    }

    public void startAttackAnimation(string nameAttackingHero, GameObject goAttackingHero,
        string nameAttackedHero, GameObject goAttackedHero)
    {
        animationHandler = goAttackingHero.GetComponent<AnimationHeroHandler>();
        animationHandler.attack();
        animationHandler = goAttackedHero.GetComponent<AnimationHeroHandler>();
        animationHandler.hitted();
        attackAnimationEnded(nameAttackingHero, goAttackingHero, nameAttackedHero, goAttackedHero);
    }

    private void attackAnimationEnded(string nameAttackingHero, GameObject goAttackingHero,
        string nameAttackedHero, GameObject goAttackedHero)
    {
        stopWalkingAnimation(nameAttackedHero,goAttackedHero);
        stopWalkingAnimation(nameAttackingHero, goAttackingHero);
        this.GetComponent<Game>().doAttackDamage(nameAttackingHero, goAttackingHero, nameAttackedHero, goAttackedHero);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
