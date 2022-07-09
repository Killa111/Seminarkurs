using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kobold : Figur
{
    // Start is called before the first frame update
    public Kobold()
    {
        setFigurName("Kobold");
        setWerte(10, 2, 5);
        setBewegungRadius(10);
        setActionRadius(4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
