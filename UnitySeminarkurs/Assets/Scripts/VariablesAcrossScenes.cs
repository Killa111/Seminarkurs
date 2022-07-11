using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesAcrossScenes : MonoBehaviour
{
    // Variables that can be read everywhere


    public string[] names0Heroes = new string[3];
    public int[] number0Heroes = new int[3];
    public int[] health0Heroes = new int[3];
    public int[] damage0Heroes = new int[3];
    public int[] walkingRange0Heroes = new int[3];
    public int[] attackingRange0Heroes = new int[3];

    public string[] names1Heroes = new string[3];
    public int[] number1Heroes = new int[3];
    public int[] health1Heroes = new int[3];
    public int[] damage1Heroes = new int[3];
    public int[] walkingRange1Heroes = new int[3];
    public int[] attackingRange1Heroes = new int[3];

    // make VariablesAcrossScenes a singleton
    public static VariablesAcrossScenes instance;// { get; private set; }  // static means that the variable is the same
                                                                        // everywhere
                                                                        // private set in the curly brackets means
                                                                        // that only this class can set VariablesAcrossScenes,
                                                                        // so others can't destroy it
                                                                        // get means that others can use VariablesAcrossScenes
    private void Awake()        // is called at the very first
    {
        if(instance == null)        // checks if this is the first time
        {
            instance = this;  
            DontDestroyOnLoad(gameObject);      // won't get destroyed when the scene changes
        }
        else
        {
            Destroy(gameObject);
        }
    }





}
