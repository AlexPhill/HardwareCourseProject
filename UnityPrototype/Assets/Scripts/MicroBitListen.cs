using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MicroBitListen : MonoBehaviour
{
    float micrograv = 0.00981f;
    public float speed = 1f;
    float[] motion;

    public float rotationSpeed;

    public float timeSinceStart;
    public float timeSinceLastCall;
    
    public float startingBearing;
    bool isFirst = true;
    void Start()
    {
        
    }
    // Called when a message arrives from the micro:bit
    void OnMessageArrived(string msg)
    {
        

        timeSinceLastCall = Time.realtimeSinceStartup - timeSinceStart;
        timeSinceStart = Time.realtimeSinceStartup;
        msg = msg.Trim(); // Remove any extra whitespace or newline characters
        Debug.Log("Message from micro:bit: " + msg);

        if (isFirst)
        {
            motion = Array.ConvertAll(msg.Split(','), float.Parse);
            startingBearing = motion[5];
            isFirst = false;
        }


        if (msg == "A")
        {
           
            gameObject.GetComponent<Deagle>().fire();

            
        }
        else if (msg == "B")
        {
            gameObject.GetComponent<Deagle>().reload();
        }else if (msg != "")
        {
            motion = Array.ConvertAll(msg.Split(','), float.Parse);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-motion[3], motion[5]-startingBearing - 90, -motion[4]), rotationSpeed * timeSinceLastCall);

            //transform.position += new Vector3(motion[0] * speed * timeSinceLastCall,0,-motion[1] * speed * timeSinceLastCall);
            /*
            Vector3 displacement = new Vector3(motion[0] * Mathf.Pow(timeSinceLastCall, 2) / 2 * speed, 0, -motion[1]* Mathf.Pow(timeSinceLastCall,2) / 2* speed);
            transform.position += displacement;
            */
        }
    }
    // Called on connect/disconnect events
    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Connected to micro:bit" : "Disconnected from micro:bit");
    }
}