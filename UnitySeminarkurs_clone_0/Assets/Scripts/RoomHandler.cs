using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;

public class RoomHandler : MonoBehaviour
{

    public Text player1Text;            //toggletext
    public Text player2Text;
    public GameObject ready1;       //toggle Objekt
    public GameObject ready2;
    public PlayerNameSafe playerNameScript;
    public GameObject NetManager;
    public OwnRoomManager manager;
    public NetworkRoomPlayer playerManager;
    public Transform spawnPosition1;
    public Transform spawnPosition2;

    private string search = "Capsule";

    // Start is called before the first frame update
    void Start()
    {
        NetManager = GameObject.Find("NetworkManager");             //NetworkManager finden
        manager = NetManager.GetComponent<OwnRoomManager>();

        playerNameScript = NetManager.GetComponent<PlayerNameSafe>();   //Objekt mit Namen finden

        if (manager.mode == NetworkManagerMode.Host)
        {
            Debug.LogWarning("Host is in the Room");
            manager.SpawnPlayerReady1(spawnPosition1);
            ready1 = GameObject.Find(search);
            if(ready1 == null) { Debug.LogWarning("Toggle found"); } else { Debug.LogWarning("noToggle!"); }
            //player1Text.text = playerNameScript.getHostName();
            ready1.SetActive(true);
        }

        if (manager.mode == NetworkManagerMode.ClientOnly)
        {
            Debug.LogWarning("Client is in the Room");
            ready2 = GameObject.Find(search);
            //player2Text.text = playerNameScript.getClientName();
            manager.SpawnPlayerReady2(spawnPosition2);
            ready2.SetActive(true);
        }

    }


    }

