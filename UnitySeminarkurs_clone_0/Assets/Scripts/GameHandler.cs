using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject NetworkManager;
    public Figur[] figuren;

    int runden;
    int aktiveFigur;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void nächsteRunde()
    {
        setzeInaktiv();
        runden++;
        aktiveFigur++;
        if (aktiveFigur > 6)
        {
            aktiveFigur = 0;
        }
        Bewegungsphase();

    }

    void Bewegungsphase()
    {
        figuren[aktiveFigur].setzeBewegung(true);
        figuren[aktiveFigur].setzeAktion(true);

    }

    void setzeInaktiv()
    {
        for (int i=0; i>6; i++) {
            figuren[i].setzeBewegung(false);
            figuren[i].setzeAktion(false);
        }
    }

}
