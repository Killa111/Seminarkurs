using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public GameObject pannelAudio;
    public GameObject pannelVideo;
    public GameObject pannelSteuerung;

    public GameObject buttonAudio;
    public GameObject buttonVideo;
    public GameObject buttonSteuerung;

    private Color standardColor;
    private Color activatetColor;

    private void deactivateAll()
    {
        buttonVideo.GetComponent<Image>().color = standardColor;
        buttonSteuerung.GetComponent<Image>().color = standardColor;
        buttonAudio.GetComponent<Image>().color = standardColor;
        pannelVideo.SetActive(false);
        pannelSteuerung.SetActive(false);
        pannelAudio.SetActive(false);
    }

    public void activateAudioSettings()
    {
        deactivateAll();

        buttonAudio.GetComponent<Image>().color = activatetColor;
        pannelAudio.SetActive(true);
    }

    public void activateSteuerungSettings()
    {
        deactivateAll();

        buttonSteuerung.GetComponent<Image>().color = activatetColor;
        pannelSteuerung.SetActive(true);
    }

    public void activateVideoSettings()
    {
        deactivateAll();

        buttonVideo.GetComponent<Image>().color = activatetColor;
        pannelVideo.SetActive(true);
    }


    private void Start()
    {
        ColorUtility.TryParseHtmlString("D6D6D6", out standardColor);
        ColorUtility.TryParseHtmlString("969696", out activatetColor);

        activateAudioSettings();
    }
}
