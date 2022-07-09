using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;

public class HeldenWahlOnline : MonoBehaviour
{

    public GameObject HeldenWahl;
    public GameObject NetManager;
    public OwnRoomManager manager;

    // Start is called before the first frame update
    void Start()
    {
        activateHeldenWahl();
        NetManager = GameObject.Find("NetworkManager");             //NetworkManager finden
        manager = NetManager.GetComponent<OwnRoomManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateHeldenWahl()
    {

        HeldenWahl.SetActive(true);
    }

    public void deactivateHeldenWahl()
    {

        HeldenWahl.SetActive(false);
    }

    public void backToLobby()
    {

        if (manager.mode == NetworkManagerMode.ClientOnly)
        {
            manager.StopClient();
            manager.StartClient();
        }

        if (manager.mode == NetworkManagerMode.Host)
        {
            manager.StopHost();
           manager.StartHost();
        }

    }

    public void Confirm()
    {
        SceneManager.LoadScene("Level1");
    }

}
