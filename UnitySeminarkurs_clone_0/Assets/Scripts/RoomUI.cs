using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;

public class RoomUI : MonoBehaviour
{

    public Text player1Text;            //toggletext
    public Text player2Text;
    public GameObject ready1;       //toggle Objekt
    public GameObject ready2;
    public Toggle ready1toggle;     //toggle feld
    public Toggle ready2toggle;
    public GameObject playerName;
    public PlayerNameSafe playerNameScript;
    public GameObject NetManager;
    public OwnRoomManager manager;
    public NetworkRoomPlayer playerManager;


    // Start is called before the first frame update
    void Start()
    {
        NetManager = GameObject.Find("NetworkManager");             //NetworkManager finden
        manager = NetManager.GetComponent<OwnRoomManager>();

        playerName = GameObject.Find("PlayerName");
        playerNameScript = playerName.GetComponent<PlayerNameSafe>();   //Objekt mit Namen finden

        if (manager.host && !manager.client)
        {
            Debug.LogWarning("Host is in the Room");
            Transform spawnPosition = GameObject.Find("Player1Position").transform;
            player1Text.text = playerNameScript.getHostName();
            manager.SpawnPlayerReady1(spawnPosition);
            ready1 = GameObject.Find("Toggle");
            ready1.SetActive(true);
        }

        if (!manager.host && manager.client)
        {
            Debug.LogWarning("Client is in the Room");
            Transform spawnPosition = GameObject.Find("Player2Position").transform;
            player2Text.text = playerNameScript.getClientName();
            ready2 = GameObject.Find("Toggle");
            manager.SpawnPlayerReady2(spawnPosition);
            ready2.SetActive(true);
        }
        ready1toggle = ready1.GetComponent<Toggle>();
        ready2toggle = ready2.GetComponent<Toggle>();


    }


    public void ready()
    {   
        if (manager.mode == NetworkManagerMode.Host)
        {
            ready1toggle.isOn = true;
            playerManager = ready1.GetComponent<NetworkRoomPlayer>();
        }

        if (manager.mode == NetworkManagerMode.ClientOnly)
        {
            ready2toggle.isOn = true;
            playerManager = ready2.GetComponent<NetworkRoomPlayer>();
        }
        playerManager.CmdChangeReadyState(true);
    }

    public void startGame()
    {
        if(ready1toggle.isOn == true && ready2toggle.isOn == true)
        {
           //SceneManager.LoadScene("Game");
        }

    }
    
}
