using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotor : MonoBehaviour
{
    public Quaternion startQuaternion;
    public float maxSpeed;
    public float Speed;
    public Rigidbody rig;
    public bool SRotate;
    public bool krasch;
  
  
    public Text _text;
    void Start()
    {
      
        maxSpeed = 2000f;
        Speed = 20f;
       
        SRotate = false;
        rig = GetComponent<Rigidbody>();
        SRotate = true;
        krasch = false;
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = Speed.ToString("RotorSpeed: " + Speed);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            StartRotate();
          
            //rotate = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            DecelerateRotor();
          
            //rotate = true;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!SRotate)
            {
                SRotate = true; 
            }
            else
            {
                SRotate = false;
            }

            if (Speed < 0)
            {
                Speed = 0;
            }
        }
       
        if (Speed > 20)
        {
         transform.Rotate(Vector3.up * Time.deltaTime * Speed); 
        }

        if (SRotate)
        {
            
            StopRotating();
        }

       
    }

    void DecelerateRotor()
    {
        Speed--;
    }
    void StartRotate()
    {
        if (Speed < maxSpeed)
        {
            Speed++;
        }

        krasch = false;
    }

    void StopRotating()
    {
        if (!krasch)
        {
            krasch = true;
        }
              
        if (Speed > 0)
        {
            Speed--;
        }
    }
    public void SnapRotation()
    {
        transform.rotation = startQuaternion;
    }
    
}
