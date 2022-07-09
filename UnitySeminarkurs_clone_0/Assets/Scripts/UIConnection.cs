using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;



//Seminar Kurs 2021/22 
//UI Verarbeitung für Connection Menü im Muliplayer (local)

public class UIConnection : MonoBehaviour
{
    public GameObject NetManager;
    public NetworkManager manager;
    public Text Input;
    public Text Placeholder;
    public string test;

    void Awake()
    {
        manager = NetManager.GetComponent<OwnRoomManager>(); //NetworkManager deklarieren
    }
   

    public void Host()
    {
        print (Input.text);
        if (Input.text is "")
        {
            Placeholder.text = "Enter Adress"; //Eingabe Aufforderung
        }
        else
        {
            manager.networkAddress = Input.text;        //Adresse an an Manager geben
            manager.StartHost();
        }

    }

    public void Join()
    { 
        manager.networkAddress =Input.text;
        print(manager.networkAddress);
        manager.StartClient();
    }
      

    public void Stop()
    {
        manager.StopHost();
        manager.StopClient();

    }

}
