using UnityEngine;
using UnityEngine.AI;

public class MousPlayerControler : MonoBehaviour
{

    public Camera mainCam;

    public Transform posCam;

    public NavMeshAgent meshAgent;

    public string nameMoveRange;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))    // check if left Mouse Button is klicked
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);    // create a ray, from the mainCam,
                                                                        // in the dirrection of the current mouseposition
            RaycastHit[] hits;                                          // RaycastHit[] stores everything the ray goes through
            RaycastHit hitUse = new RaycastHit();                       // the hit that is used                                     
            bool foundField = false;                                    // got an Field hit
            bool foundMoveRange = false;                                // got the MoveRange hit

            hits = Physics.RaycastAll(ray);                             // shoots ot the ray, stores everything it hits in hits

            float nearestHitField = Mathf.Infinity;                     // distance to nearest hit Field
            
            for(int i = 0; i < hits.Length; i++)                        // for loop goes through all the hits stored in hit
            {
                if(hits[i].transform.tag == "Field")                    // checks if a object with the tag Field got hit
                {
                    if(Vector3.Distance(posCam.position, hits[i].point) < nearestHitField) // checks if the Field is the nearest
                    {
                        hitUse = hits[i];
                        nearestHitField = Vector3.Distance(posCam.position, hits[i].point);
                        foundField = true;
                    }
                }

                if(hits[i].transform.name == nameMoveRange)             // checks if the MoveRange got hit
                {
                    foundMoveRange = true;
                }                
            }

            if(foundField == true & foundMoveRange == true)        
            {
                meshAgent.SetDestination(hitUse.point);
            }            
        }
    }
}