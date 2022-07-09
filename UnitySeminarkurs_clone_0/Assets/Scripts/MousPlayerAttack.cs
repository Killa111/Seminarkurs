using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousPlayerAttack : MonoBehaviour
{
    public GameObject goAttackRange;
    public GameObject goGameCode;

    public Camera mainCam;

    public Transform posCam;

    public string nameAttackRange;

    public char enemySide;

    public string enemyHit;

    public bool attacked = false;

    public void notAttacked()
    {
        attacked = false;
    }

    public bool alreadyAttacked()
    {
        return attacked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && attacked == false)    // check if left Mouse Button is klicked
                                                                 // & there wasn't already a attack
        {
            // check if the mouse clicked on a Enemy

            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);    // create a ray, from the mainCam,
                                                                        // in the dirrection of the current mouseposition
            RaycastHit[] hits;                                          // RaycastHit[] stores everything the ray goes through
            RaycastHit hitUse = new RaycastHit();                       // the hit that is used                                     
            bool foundEnemy = false;                                    // hits the enemy

            float nearestHitEnemy = Mathf.Infinity;                     // distance to nearest hit Enemy, currently infinity

            hits = Physics.RaycastAll(ray);                             // shoots ot the ray, stores everything it hits in hits
            
            for (int i = 0; i < hits.Length; i++)                        // for loop goes through all the hits stored in hits
            {
                string currentName = hits[i].transform.name;
                char currentSide = currentName[0];              // get first char that is specific for each side

                if (currentSide == enemySide)                    // checks if a Enemy got hit
                {
                    if (Vector3.Distance(posCam.position, hits[i].point) < nearestHitEnemy) // checks if the hit Enemy ist the nearest hit
                    {
                        hitUse = hits[i];
                        nearestHitEnemy = Vector3.Distance(posCam.position, hits[i].point);
                        foundEnemy = true;
                    }
                }
            }

            // checks if the enemy is in the attack range

            if(foundEnemy == true)
            {
                Vector3 biggerHeight = new Vector3(0, 50, 0);   // lets the ray start from a bigger height
                Ray ray2 = new Ray(hitUse.transform.position + biggerHeight, hitUse.transform.up*-1); // new Ray that starts in the middle of
                                                                                       // the enemy and goes down, oppsite direction to up
                RaycastHit[] hits2;

                hits2 = Physics.RaycastAll(ray);                             // shoots ot the ray, stores everything it hits in hits2

                for (int i = 0; i < hits2.Length; i++)                        // for loop goes through all the hits stored in hits2
                {
                    string currentName = hits2[i].transform.name;

                    if (currentName == nameAttackRange)                    // checks Attack Range got hit
                    {
                        enemyHit = hitUse.transform.name;
                        Debug.Log(enemyHit);
                        goGameCode.GetComponent<Game>().beginnAttackingAnimation(this.transform.name, this.transform.gameObject,
                            hitUse.transform.name, hitUse.transform.gameObject);
                        attacked = true;
                        goAttackRange.SetActive(false);
                    }
                }
            }
        }
    }
}
