
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

//Cedric Strätgen
//last change 09.07.2022
//NetworkRoomManager, mit veränderter GUI


public class OwnNetworkManager : NetworkRoomManager
{
    bool activateReadyButton;


    public override void OnRoomServerPlayersReady()
    {
        //Abfrage ob Spieler breit sind.
#if UNITY_SERVER
            base.OnRoomServerPlayersReady();
#else
        activateReadyButton = true;
#endif
    }

    public override void OnGUI()
    {
        base.OnGUI();
        int screenPart = Screen.width / 4;
        if (allPlayersReady && activateReadyButton && GUI.Button(new Rect(screenPart +150, 300, 120, 20), "START GAME"))
        {
            // set to false to hide it in the game scene
            activateReadyButton = false;

            ServerChangeScene(GameplayScene);
        }
    }

    public override void OnRoomStopClient()
    {
        base.OnRoomStopClient();
    }

    public override void OnRoomStopServer()
    {
        base.OnRoomStopServer();
    }

}
