using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesAcrossScenes : MonoBehaviour
{

    // make VariablesAcrossScenes a singleton
    public static VariablesAcrossScenes instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);      // won't get destroyed
        }
        else
        {
            Destroy(gameObject);
        }
    }



}
