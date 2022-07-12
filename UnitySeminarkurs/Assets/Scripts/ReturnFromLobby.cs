using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnFromLobby : MonoBehaviour
{

    public GameObject NetManager;
    public OwnNetworkManager manager;
    // Start is called before the first frame update
    void Start()
    {

        NetManager = GameObject.Find("NetworkManager 1");             //NetworkManager finden
        manager = NetManager.GetComponent<OwnNetworkManager>();
    }

    public void back()
    {
        manager.StopHost();
        manager.StopClient();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
