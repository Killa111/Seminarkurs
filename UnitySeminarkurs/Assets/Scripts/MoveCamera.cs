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


    public Vector3 startZoom;
    private Vector3 side0posCam = new Vector3(20.4f, 18f, 0.05f);
    private Quaternion side0rotateCam = Quaternion.Euler(0f, 0f, 0f);
    private Vector3 side1posCam = new Vector3(32f, 18f, 125f);
    private Quaternion side1rotateCam = Quaternion.Euler(0f, 180f, 0f);

    public void changeToSide0()
    {
        Debug.Log("cam changed to side 0");
        neuePosition = side0posCam;
        neueRotation = side0rotateCam;
        neuerZoom = startZoom;
    }

    public void changeToSide1()
    {
        Debug.Log("cam changed to side 1");
        neuePosition = side1posCam;
        neueRotation = side1rotateCam;
        neuerZoom = startZoom;
    }


    void Start()
    {
        startZoom = cameraTransform.localPosition;

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
            neuePosition += (transform.forward * geschwindigkeit);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))       //Rückwärts bewegen
        {
            neuePosition += (transform.forward * -geschwindigkeit );
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))      //nach rechts bewegen
        {
            neuePosition += (transform.right * geschwindigkeit);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))      //nach links bewegen
        {
            neuePosition += (transform.right * -geschwindigkeit);
        }

        if (Input.GetKey(KeyCode.Q))                                        //Kamera nach links rotieren
        {
            neueRotation *= Quaternion.Euler(Vector3.up * rotation );
        }
        if (Input.GetKey(KeyCode.E))                                        //Kamera nach rechts rotieren
        {
            neueRotation *= Quaternion.Euler(Vector3.up * -rotation);       
        }


        if (Input.GetKey(KeyCode.R))                                        //hin zoomen
        {
            neuerZoom += zoom;
        }
        if (Input.GetKey(KeyCode.F))                                        //weg zoomen
        {
            neuerZoom += -zoom;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)                                        //hin zoomen
        {
            neuerZoom += zoom* 3;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)                                        //weg zoomen
        {
            neuerZoom += -zoom*3;
        }

        
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, neuerZoom, Time.deltaTime * zeit); //Bewegungen flüssiger ablaufen lassen
        transform.position = Vector3.Lerp(transform.position, neuePosition, Time.deltaTime * zeit);
        transform.rotation = Quaternion.Lerp(transform.rotation, neueRotation, Time.deltaTime * zeit);
        
    }
}
