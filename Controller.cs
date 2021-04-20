using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private string MoveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";
    
    public Rotor rotor;
    public Rigidbody rig;
    public float moveSpeed = 15;
    private float CurSpeed;
    float finalSpeed;
    public int rotationRate = 360;
    private float gravity = -500;
    private Vector3 someValue;
    #region  Monobehaviour API
    
    

    #endregion

    private void Start()
    {
        CurSpeed = rotor.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        float moveAxis = Input.GetAxis(MoveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);
        
        ApplyInput(moveAxis,turnAxis);
    }
    
    private void ApplyInput(float moveInput, float turnInput)
    {
        Move(moveInput);
        Turn(turnInput);
    }
    
    
    private void Move(float input)
    {
        // && rotor.Speed > 500if (!rotor.SRotate)
        {
        
          someValue = calculateAltitude(CurSpeed);
            rig.AddForce(someValue * Time.deltaTime);
            //transform.Translate(Vector3.up * input * moveSpeed);
        }
        
    }
    private void Turn(float input)
    {
        transform.Rotate(0,input * rotationRate * Time.deltaTime,0);
        
    }

    private Vector3 calculateAltitude(float curSpeed)
    {
       Vector3 Gravity = new Vector3(0,gravity,0);
       Vector3 finalSpeed = new Vector3(0,curSpeed,0);
       finalSpeed = curSpeed * Gravity;
         return finalSpeed;
    }
}
