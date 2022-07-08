using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject goCamController;
    public GameObject goMainCam;
    public Camera mainCam;

    public Transform posCam;

    public GameObject go0Hero0;
    public GameObject go0Hero1;
    public GameObject go0Hero2;
    public GameObject go1Hero0;
    public GameObject go1Hero1;
    public GameObject go1Hero2;
    
    public GameObject goMovementRange0Hero0;
    public GameObject goMovementRange0Hero1;
    public GameObject goMovementRange0Hero2;
    public GameObject goMovementRange1Hero0;
    public GameObject goMovementRange1Hero1;
    public GameObject goMovementRange1Hero2;
    
    public GameObject goAttackRange0Hero0;
    public GameObject goAttackRange0Hero1;
    public GameObject goAttackRange0Hero2;
    public GameObject goAttackRange1Hero0;
    public GameObject goAttackRange1Hero1;
    public GameObject goAttackRange1Hero2;


    private GameObject goCurrentHero;
    private GameObject goCurrentMovementRangeHero;
    private GameObject goCurrentAttackRangeHero;

    private bool movingAnimationActive;
    private Vector3 posCurrentHero = new Vector3();

    private char currentSide = '0';
    private string nameNewHero;
    private bool heroChoosen = false;
    private string nameCurrentHero;

    private int currentHeroCoosen;           // look at strings below
    private string[] names0Heroes = new string[] { "0Hero0", "0Hero1", "0Hero2" };
    private string[] names1Heroes = new string[] { "1Hero0", "1Hero1", "1Hero2" };

    private bool[] heroesMoved = new bool[] { false, false, false };
    private bool[] heroesAttacked = new bool[] { false, false, false };

    private bool[] dead0Heroes = new bool[] { false, false, false };
    private bool[] dead1Heroes = new bool[] { false, false, false };

    bool canChooseHero = false;

    int progressRound = 0;          // stores which progress is made in this round

    private void endGame()
    {
        
    }

    private void side0Won()
    {

    }

    private void side1Won()
    {

    }

    private void checkGameEnd()
    {
        if(!go0Hero0.activeSelf && !go0Hero1.activeSelf && !go0Hero2.activeSelf)    // check if all Heros of side0 are beaten
        {
            side1Won();
            endGame();
        }

        if (!go1Hero0.activeSelf && !go1Hero1.activeSelf && !go1Hero2.activeSelf)    // check if all Heros of side1 are beaten
        {
            side0Won();
            endGame();
        }
    }

    private void changeSide()
    {
        // cange currentSide to the other side
        if (currentSide == '0')
        {
            currentSide = '1';
            goCamController.GetComponent<MoveCamera>().changeToSide1();
            // reset progress and show that the dead Heroes already moved to ignore them
            if (!dead1Heroes[0])
            {
                heroesMoved[0] = false;
                heroesAttacked[0] = false;
            }
            else
            {
                heroesMoved[0] = true;
                heroesAttacked[0] = true;
            }

            if (!dead1Heroes[1])
            {
                heroesMoved[1] = false;
                heroesAttacked[1] = false;
            }
            else
            {
                heroesMoved[1] = true;
                heroesAttacked[1] = true;
            }

            if (!dead1Heroes[2])
            {
                heroesMoved[2] = false;
                heroesAttacked[2] = false;
            }
            else
            {
                heroesMoved[2] = true;
                heroesAttacked[2] = true;
            }
        }
        else
        {
            currentSide = '0';
            goCamController.GetComponent<MoveCamera>().changeToSide0();
            // reset progress and show that the dead Heroes already moved to ignore them
            if (!dead0Heroes[0])
            {
                heroesMoved[0] = false;
                heroesAttacked[0] = false;
            }
            else
            {
                heroesMoved[0] = true;
                heroesAttacked[0] = true;
            }

            if (!dead0Heroes[1])
            {
                heroesMoved[1] = false;
                heroesAttacked[1] = false;
            }
            else
            {
                heroesMoved[1] = true;
                heroesAttacked[1] = true;
            }

            if (!dead0Heroes[2])
            {
                heroesMoved[2] = false;
                heroesAttacked[2] = false;
            }
            else
            {
                heroesMoved[2] = true;
                heroesAttacked[2] = true;
            }
        }

        // reset progress
        heroChoosen = false;
        progressRound = 0;
    }

    public void beginnWalkingAnimation()
    {
        this.GetComponent<Animations>().startWalkingAnimation(nameCurrentHero, goCurrentHero);
        movingAnimationActive = true;
    }

    public void beginnAttackingAnimation(string nameAttackingHero, GameObject goAttackingHero,
        string nameAttackedHero, GameObject goAttackedHero)
    {
        this.GetComponent<Animations>().startAttackAnimation(nameAttackingHero, goAttackingHero, 
            nameAttackedHero, goAttackedHero);
    }

    public void doAttackDamage(string nameAttackingHero, GameObject goAttackingHero,
        string nameAttackedHero, GameObject goAttackedHero)
    {
        goAttackedHero.GetComponent<Stats>().decreaseCurrentHealth(
            goAttackingHero.GetComponent<Stats>().getAttack());     // decreases the health of the attacked

        if (!goAttackedHero.GetComponent<Stats>().getAlive())       // checks if the Hero is dead
        {
            switch (goAttackedHero.transform.name)
            {
                case "0Hero0":
                    dead0Heroes[0] = true;
                    go0Hero0.SetActive(false);
                    break;

                case "0Hero1":
                    dead0Heroes[1] = true;
                    go0Hero1.SetActive(false);
                    break;

                case "0Hero2":
                    dead0Heroes[2] = true;
                    go0Hero2.SetActive(false);
                    break;

                case "1Hero0":
                    dead1Heroes[0] = true;
                    go1Hero0.SetActive(false);
                    break;

                case "1Hero1":
                    dead1Heroes[1] = true;
                    go1Hero1.SetActive(false);
                    break;

                case "1Hero2":
                    dead1Heroes[2] = true;
                    go1Hero2.SetActive(false);
                    break;
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        // fist check if a hero is moving, if it is break Update, to wait till it is over
        if (movingAnimationActive)
        {
            if (posCurrentHero == goCurrentHero.transform.position) // check if the Hero still moves
            {
                this.GetComponent<Animations>().stopWalkingAnimation(nameCurrentHero, goCurrentHero);
                movingAnimationActive = false;
            }
            else        // set the new position as current position, to check the next round again
            {
                posCurrentHero = goCurrentHero.transform.position;
            }
        }
        else             // only does the rest if there is no moving animation
        {

            if (canChooseHero) { chooseHero(); };

            if (heroesAttacked[0] && heroesAttacked[1] && heroesAttacked[2])   // all heroes attacked, the round is over
            {
                changeSide();
            }

            switch (progressRound)
            {
                case 0:         // allows one to choose a hero
                    checkGameEnd();

                    canChooseHero = true;
                    progressRound = 1;
                    break;

                case 1:         // allow the hero to move
                    if (heroChoosen)
                    {
                        canChooseHero = false;
                        determineCurrentHero();

                        if (heroesMoved[currentHeroCoosen])     // checks if the current hero alredy moved
                        {
                            // directly jump to the attack

                            progressRound = 3;
                            break;
                        }

                        goCurrentHero.GetComponent<MousPlayerMovement>().enabled = true;       // enables script for movement
                        goCurrentHero.GetComponent<MousPlayerMovement>().notMoved();           // says that the hero has not already moved
                        goCurrentMovementRangeHero.SetActive(true);                            // enables the Movement range
                                                                                               // so that it is possible to move
                        progressRound = 2;
                    }
                    break;

                case 2:         // deactivate movement 
                    if (goCurrentHero.GetComponent<MousPlayerMovement>().alreadyMoved())
                    {
                        goCurrentMovementRangeHero.SetActive(false);
                        goCurrentHero.GetComponent<MousPlayerMovement>().enabled = false;

                        heroesMoved[currentHeroCoosen] = true;       // save that the hero moved
                        progressRound = 0;          // chose a hero after moving
                        heroChoosen = false;            // show that no hero was choosen
                    }
                    break;

                case 3:     // allow hero to attack

                    if (heroesAttacked[currentHeroCoosen])     // checks if the current hero already attacked
                    {
                        progressRound = 0;
                        heroChoosen = false;    // need to choose a new Hero
                        break;
                    }
                    else
                    {
                        goCurrentHero.GetComponent<MousPlayerAttack>().enabled = true;
                        goCurrentHero.GetComponent<MousPlayerAttack>().notAttacked();
                        goCurrentAttackRangeHero.SetActive(true);

                        progressRound = 4;
                    }

                    break;

                case 4:     // deactivat attack
                    if (goCurrentHero.GetComponent<MousPlayerAttack>().alreadyAttacked())
                    {
                        goCurrentAttackRangeHero.SetActive(false);
                        goCurrentHero.GetComponent<MousPlayerAttack>().enabled = false;

                        heroesAttacked[currentHeroCoosen] = true;        // saves that the hero already moved
                        progressRound = 0;
                        heroChoosen = false;    // need to choose a new Hero
                    }
                    break;
            }
        }
    }


    private void determineCurrentHero()
    {
        nameCurrentHero = nameNewHero;

        switch (nameNewHero)
        {
            case "0Hero0":
                goCurrentHero = go0Hero0;
                goCurrentMovementRangeHero = goMovementRange0Hero0;
                goCurrentAttackRangeHero = goAttackRange0Hero0;
                currentHeroCoosen = 0;
                break;

            case "0Hero1":
                goCurrentHero = go0Hero1;
                goCurrentMovementRangeHero = goMovementRange0Hero1;
                goCurrentAttackRangeHero = goAttackRange0Hero1;
                currentHeroCoosen = 1;
                break;

            case "0Hero2":
                goCurrentHero = go0Hero2;
                goCurrentMovementRangeHero = goMovementRange0Hero2;
                goCurrentAttackRangeHero = goAttackRange0Hero2;
                currentHeroCoosen = 2;
                break;

            case "1Hero0":
                goCurrentHero = go1Hero0;
                goCurrentMovementRangeHero = goMovementRange1Hero0;
                goCurrentAttackRangeHero = goAttackRange1Hero0;
                currentHeroCoosen = 0;
                break;

            case "1Hero1":
                goCurrentHero = go1Hero1;
                goCurrentMovementRangeHero = goMovementRange1Hero1;
                goCurrentAttackRangeHero = goAttackRange1Hero1;
                currentHeroCoosen = 1;
                break;

            case "1Hero2":
                goCurrentHero = go1Hero2;
                goCurrentMovementRangeHero = goMovementRange1Hero2;
                goCurrentAttackRangeHero = goAttackRange1Hero2;
                currentHeroCoosen = 2;
                break;
        }
    }

    private void chooseHero()
    {        
        if (Input.GetMouseButtonDown(0) && heroChoosen == false)    // check if left Mouse Button is klicked
                                                                 // & there isn't already a hero choosen
        {
            // check if the mouse clicked on a Enemy

            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);    // create a ray, from the mainCam,
                                                                        // in the dirrection of the current mouseposition
            RaycastHit[] hits;                                          // RaycastHit[] stores everything the ray goes through

            RaycastHit hitUse = new RaycastHit();                       // the hit that wil be used  

            float nearestHitHero = Mathf.Infinity;                     // distance to nearest hit hero, currently infinity

            hits = Physics.RaycastAll(ray);                             // shoots ot the ray, stores everything it hits in hits

            for (int i = 0; i < hits.Length; i++)                        // for loop goes through all the hits stored in hits
            {
                if (currentSide == hits[i].transform.name[0])                    // checks if a Player of the currentSide got hit
                {
                    if (Vector3.Distance(posCam.position, hits[i].point) < nearestHitHero) // checks if the hit Enemy is the nearest hit
                    {
                        hitUse = hits[i];
                        nearestHitHero = Vector3.Distance(posCam.position, hits[i].point);
                        heroChoosen = true;
                    }
                }
            }
            
            if(heroChoosen)     // check if a Hero was choosen
            {
                nameNewHero = hitUse.transform.name;
                Debug.Log(nameNewHero);
            }
        }
    }
}
