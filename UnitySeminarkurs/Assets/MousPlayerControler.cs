using UnityEngine;
using UnityEngine.AI;

public class MousPlayerControler : MonoBehaviour
{

    public Camera mainCam;

    public NavMeshAgent meshAgent;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))    // check if left Mouse Button is klicked
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);    // create a ray, from the mainCam,
                                                                        // in the dirrection of the current mouseposition
            RaycastHit hit;                                             // RaycastHit stores what got hit

            if (Physics.Raycast(ray, out hit))                          // shoots ot the ray, stors what got hit
                                                                        // in hit, if something got hit continue in if                                                                        
            {
                if(hit.collider.tag == "Field")
                {
                    meshAgent.SetDestination(hit.point);
                }
            }
        }
    }
}
