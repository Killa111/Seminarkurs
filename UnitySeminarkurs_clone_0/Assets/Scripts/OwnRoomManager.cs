using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[AddComponentMenu("")]
public class OwnRoomManager : NetworkRoomManager
{ 
    [Header("CustomRoom")]
    public GameObject roomPlayer;

    public GameObject spawnPlayerPrefab;

    public bool host;
    public bool client;

    public void SpawnPlayerReady1(Transform start)
    {
        Debug.LogWarning("Client1 is in the Room");
        roomPlayer = Instantiate(spawnPlayerPrefab, start.position, start.rotation);
        NetworkServer.Spawn(roomPlayer);
    }

    public void SpawnPlayerReady2(Transform start)
    {
        Debug.LogWarning("Client2 is in the Room");
        roomPlayer = Instantiate(spawnPlayerPrefab, start.position, start.rotation);
        NetworkServer.Spawn(roomPlayer);
    }

}



