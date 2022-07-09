using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameSafe : MonoBehaviour
{

    public string playerOneName;
    public string playerTwoName;
    
    public void setHostName(string hostName)
    {
        playerOneName = hostName;
    }

    public void setClientName(string clientName)
    {
        playerTwoName = clientName;
    }

    public string getHostName()
    {
        return playerOneName;
    }

    public string getClientName()
    {
        return playerTwoName;
    }
}
