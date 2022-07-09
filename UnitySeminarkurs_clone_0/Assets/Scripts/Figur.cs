using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figur : MonoBehaviour
{
    private int spieler;
    private string figurenName;


    private int bewegungsRadius;        //Objekt Variablen
    private int actionRadius;
    public GameObject figurObjekt;
    private GameObject objektBewegung;
    private GameObject objektAction;

    private int angriff;    //Werte der Figur
    private int leben;
    private int lebenAnfang;
    private int abwehr;

    // Start is called before the first frame update
    void Start()
    {
        objektBewegung = figurObjekt.transform.GetChild(0).gameObject;      //bekommt die Felder der Figur
        objektAction = figurObjekt.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void bekommeSchaden(int schaden)
    {
        schaden = schaden - abwehr;                 //Abwehr lindert Schaden
        if (schaden < 0)                            //Verhindern, dass Angriff negativen Schaden macht
        {
            schaden = 0;
        }
        leben = leben - schaden;                    //neue Leben berechnen
    }

    public int getAngriff()
    {
        return angriff;                             
    }

    public int getLeben()
    {
        return leben;
    }

    public void setLeben(int neueLeben)
    {
        leben = neueLeben;
    }

    public int getLebenAnfang()
    {
        return lebenAnfang;
    }

    public int getAbwehr()
    {
        return abwehr;
    }

    public void setWerte(int gLebenAnfang, int gAbwehr, int gAngriff)
    {
        lebenAnfang = gLebenAnfang;
        abwehr = gAbwehr;
        angriff = gAngriff;
    }

    public int getSpieler()   //gibt den Spieler der Figur zurück
    {
        return spieler;
    }

    public void setSpieler(int spielerNummer) // legt fest wem diese Figur gehört (0 KI, 1 Spieler1/Host, 2 Spieler2/Client)
    {
        spieler = spielerNummer;
    }

    public string getFigurName()   //gibt den Spieler der Figur zurück
    {
        return figurenName;
    }

    public void setFigurName(string gFigurName) // legt fest wem diese Figur gehört (0 KI, 1 Spieler1/Host, 2 Spieler2/Client)
    {
        figurenName = gFigurName;
    }

    public int getBewgungRadius()       
    {
        return bewegungsRadius;
    }

    public void setBewegungRadius(int gBewegung)        //legt den Radius in der sich die Figur bewegt fest.
    {
        bewegungsRadius = gBewegung;
        objektBewegung.transform.localScale = new Vector3(bewegungsRadius, 0.05f, bewegungsRadius);
    }

    public int getActionRadius()
    {
        return actionRadius;
    }

    public void setActionRadius(int gAction) //legt den Radius fest, in dem die Figur Agieren/Angreifen kann.
    {
        actionRadius = gAction;
        objektAction.transform.localScale = new Vector3(actionRadius, 0.05f, actionRadius);
    }

    public void setzeBewegung (bool aktivB)
    {

        objektBewegung.SetActive(aktivB);

    }

    public void setzeAktion(bool aktivA)
    {

        objektAction.SetActive(aktivA);

    }
}
