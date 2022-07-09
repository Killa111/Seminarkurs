using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Figur
{
    GameObject andereFigur1; 
    GameObject andereFigur2;
    // Start is called before the first frame update
    public Golem()
    {
        setFigurName("Golem");
        setWerte(20, 3, 5);
        setBewegungRadius(5);
        setActionRadius(4);
    }

    public void setOtherFigur(GameObject figur1, GameObject figur2)
    {
        andereFigur1 = figur1;
        andereFigur2 = figur2;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
