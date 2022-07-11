using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    
    public float geschwindigkeit;
    public float geschwindigkeitSchnell;
    public float geschwindigkeitNormal;
    public float zeit;
    public float rotation;
    public Vector3 zoom;
    public Transform cameraTransform;


    public Vector3 neuePosition;
    public Quaternion neueRotation;
    public Vector3 neuerZoom;

    private int sideSwitched = 1;        // gets multiplicatet with all canges, if 1 normal,
                                         // if side changed -1 to invert the canges

    private Vector3 side0posCam = new Vector3(5.6f, 18.5f, -27f);
    private Quaternion side0rotateCam = Quaternion.Euler(60f, 0f, 0f);
    private Vector3 side1posCam = new Vector3(5.6f, 18.5f, 127f);
    private Quaternion side1rotateCam = Quaternion.Euler(60f, 180f, 0f);

    public void changeToSide0()
    {
        sideSwitched = 1;
        transform.position = side0posCam;
        transform.transform.rotation = side0rotateCam;
    }

    public void changeToSide1()
    {
        sideSwitched = -1;
        transform.position = side1posCam;
        transform.transform.rotation = side1rotateCam;
    }


    void Start()
    {
        neuePosition = transform.position;
        neueRotation = transform.rotation;
        neuerZoom = cameraTransform.localPosition;
    }

    void Update()
    {
        KeyInput(); 
    }


    void KeyInput(){

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            geschwindigkeit = geschwindigkeitSchnell;                       //Shift um schneller zu bewegen
        }
        else
        {
            geschwindigkeit = geschwindigkeitNormal;                        //kein Shift um normal zu bewegen
        }


    
        if( Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))          //Vorwärts bewegen
        {
            neuePosition += (transform.forward * geschwindigkeit * sideSwitched);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))       //Rückwärts bewegen
        {
            neuePosition += (transform.forward * -geschwindigkeit * sideSwitched);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))      //nach rechts bewegen
        {
            neuePosition += (transform.right * geschwindigkeit * sideSwitched);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))      //nach links bewegen
        {
            neuePosition += (transform.right * -geschwindigkeit * sideSwitched);
        }

        if (Input.GetKey(KeyCode.Q))                                        //Kamera nach links rotieren
        {
            neueRotation *= Quaternion.Euler(Vector3.up * rotation * sideSwitched);
        }
        if (Input.GetKey(KeyCode.E))                                        //Kamera nach rechts rotieren
        {
            neueRotation *= Quaternion.Euler(Vector3.up * -rotation * sideSwitched);       
        }


        if (Input.GetKey(KeyCode.R))                                        //hin zoomen
        {
            neuerZoom += zoom * sideSwitched;
        }
        if (Input.GetKey(KeyCode.F))                                        //weg zoomen
        {
            neuerZoom += -zoom * sideSwitched;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)                                        //hin zoomen
        {
            neuerZoom += zoom* 3 * sideSwitched;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)                                        //weg zoomen
        {
            neuerZoom += -zoom*3 * sideSwitched;
        }


        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, neuerZoom, Time.deltaTime * zeit); //Bewegungen flüssiger ablaufen lassen
        transform.position = Vector3.Lerp(transform.position, neuePosition, Time.deltaTime * zeit);
        transform.rotation = Quaternion.Lerp(transform.rotation, neueRotation, Time.deltaTime * zeit);
    }
}
