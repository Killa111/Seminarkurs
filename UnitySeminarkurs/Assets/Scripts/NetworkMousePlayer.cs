using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Mirror;



public class NetworkMousePlayer : NetworkBehaviour
{
    public string heroName;
    public GameObject goMovementRange;
    public GameObject goGameCode;

    public Camera mainCam;

    public Transform posCam;

    public NavMeshAgent meshAgent;

    public string nameMoveRange;

    public bool moved = false;

    public void notMoved()
    {
        moved = false;
    }

    void Start()
    {
         goMovementRange = GameObject.Find(nameMoveRange);
        mainCam = GameObject.Find("MainCamera").GetComponent<Camera>();
        meshAgent = GetComponent<NavMeshAgent>();
        posCam = GameObject.Find("MainCamera").transform;
        goMovementRange = GameObject.Find(nameMoveRange);
        goGameCode = GameObject.Find("GameCode");
    }

    public bool alreadyMoved()
    {
        return moved;
    }

    // Update is called once per frame
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && moved == false)    // check if left Mouse Button is klicked
                                                              // & there hasn't already been a move
        {
            Movement();
        }
    }


   //[Command(requiresAuthority=false)]
    public void Movement()
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);    // create a ray, from the mainCam,
                                                                        // in the dirrection of the current mouseposition
            RaycastHit[] hits;                                          // RaycastHit[] stores everything the ray goes through
            RaycastHit hitUse = new RaycastHit();                       // the hit that is used                                     
            bool foundField = false;                                    // got an Field hit
            bool foundMoveRange = false;                                // got the MoveRange hit

            float nearestHitField = Mathf.Infinity;                     // distance to nearest hit Field, currently infinity

            hits = Physics.RaycastAll(ray);                             // shoots ot the ray, stores everything it hits in hits

            for (int i = 0; i < hits.Length; i++)                        // for loop goes through all the hits stored in hit
            {
                if (hits[i].transform.tag == "Field")                    // checks if a object with the tag Field got hit
                {
                    if (Vector3.Distance(posCam.position, hits[i].point) < nearestHitField) // checks if the Field is the nearest
                    {
                        hitUse = hits[i];
                        nearestHitField = Vector3.Distance(posCam.position, hits[i].point);
                        foundField = true;
                    }
                }
                else if (hits[i].transform.name == nameMoveRange)             // checks if the MoveRange got hit
                {
                    foundMoveRange = true;
                }
            }

            bool hitHero = false;

            if (foundField == true)
            {
                Vector3 biggerHeight = new Vector3(0, 100, 0);   // lets the ray start from a bigger height
                Ray ray2 = new Ray(hitUse.transform.position + biggerHeight, hitUse.transform.up * -1); // new Ray that starts in the middle of
                                                                                                        // the Field and goes down, oppsite direction to up
                RaycastHit[] hits2;

                hits2 = Physics.RaycastAll(ray);                             // shoots ot the ray, stores everything it hits in hits2

                for (int i = 0; i < hits2.Length; i++)                        // for loop goes through all the hits stored in hits2
                {
                    if (hits2[i].transform.tag == "Hero")                    // if a Hero got hit, a Hero stands on the field already
                    {
                        if (hits2[i].transform.name != gameObject.transform.name)   // checks if the Hero didn't hit itself
                                                                                    // if the hero hit it selve it will skip 
                                                                                    // the movement this round
                        {
                            hitHero = true;
                        }
                    }
                }
            }
        

        // check if the Player klicked on a Field that is in the movementrange of the hero, and no other Hero is on the Field
        if (foundField == true && foundMoveRange == true && hitHero == false)
        {
            Transform position = hitUse.transform;
            meshAgent.SetDestination(position.position);        // move on the field that got hit
                goGameCode.GetComponent<Game>().beginnWalkingAnimation();
                moved = true;
                goMovementRange.SetActive(false);
        }
    }
  
}
