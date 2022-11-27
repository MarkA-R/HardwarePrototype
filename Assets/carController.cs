using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    
    public float T = 0.5f;
    public float angle = 0;
    float turningSpeed = 35;
    float moveSpeed = 6;
    bool connected = false;
    public SerialController controller;
    public static carController instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }

        return;
        transform.RotateAround(transform.position, Vector3.up, Mathf.Lerp(-1f, 1f, T) * Time.deltaTime * turningSpeed);
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward*Time.deltaTime*moveSpeed;
        }
        string message = gameObject.GetComponent<SerialController>().ReadSerialMessage();
        if (message != null)
        {
            Debug.Log(message);
            T = float.Parse(message);
        }
        
        /*
        if (T <= 0.5f)
        {
            T += 0.03f;
        }
        else
        {
            T -= 0.03f;
        }
        */
    }

    public void addToLERP(float a)
    {
        T += a;
        if(T> 1)
        {
            T = 1;
        }
        if(T < 0)
        {
            T = 0;
        }
    }

    public void OnMessageArrived(string msg)
    {
        
        if (connected)
        {
            
             float.TryParse(msg, out T);
            transform.RotateAround(transform.position, Vector3.up, Mathf.Lerp(-1f, 1f, T) * Time.deltaTime * turningSpeed);
            
        }
        else
        {
            Debug.Log("Disconnected!");
        }
        
        
    }
   
    public void OnConnectionEvent(bool success)
    {
       
        connected = success;
    }
}
