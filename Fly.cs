using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fly : MonoBehaviour
{
    public Rotor rotor;
    public Rigidbody rig;
    public Transform pivot;

    //public Rigidbody rb;
    public float x = 1;
    private float drag;
    private bool isUsingGravity;
    private float maxAngle = 90;
    private float minAngle = 70;

    private float currSpeed;


    public Text _text;
    private float rot = 1;



    void Start()
    {
        isUsingGravity = rig.isKinematic;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rot == maxAngle)
        {
            rot = minAngle;
        }
        currSpeed = rotor.Speed;

        drag = rig.drag;
        _text.text = rot.ToString("rotation: " + rot);
        if (Input.GetKey((KeyCode.K)))
        {
            rig.useGravity = !rig.useGravity;
        }



        if (!rotor.SRotate && rotor.Speed > 500)
        {


            if (Input.GetKey(KeyCode.Space))
            {

                rig.AddForce(new Vector3(0, x, 0) * currSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                rig.AddForce(new Vector3(-x, 0, 0) * currSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {


                rig.AddForce(new Vector3(x, 0, 0) * currSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.W))
            {
                 
             rig.AddForce(new Vector3(0, 0, x) * currSpeed * Time.deltaTime);
            }


            if (Input.GetKey(KeyCode.S))
            {
                rig.AddForce(new Vector3(0, 0, -x) * currSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.E))
            {
                transform.RotateAround(pivot.position, Vector3.up, rot * Time.deltaTime);
                rot++;
                
            }

            if (Input.GetKey(KeyCode.Q))
            {
                transform.RotateAround(pivot.position, Vector3.down, rot * Time.deltaTime);
                    rot++;
            }

            //Rotate helicopter

                // Y-axis
            if (Input.GetKey(KeyCode.Keypad7))
            {
                    transform.RotateAround(pivot.position, Vector3.down,rot  * Time.deltaTime);
                    rot++;
            }

            // Y-axis
            if (Input.GetKey(KeyCode.Keypad9))
            {
                    transform.RotateAround(pivot.position, Vector3.up, 180  * Time.deltaTime);
                    rot++;
            }

            // Z-axis
            if (Input.GetKey(KeyCode.Keypad8))
            {
                    transform.RotateAround(pivot.position, Vector3.right, rot  * Time.deltaTime);
                    rig.AddForce(Vector3.right);
                    rot++;
            }

            // Z-axis
            if (Input.GetKey(KeyCode.Keypad2))
            { 
                transform.RotateAround(pivot.position, Vector3.left, rot   * Time.deltaTime);
                    rot++;
            }

            // X-axis
            if (Input.GetKey(KeyCode.Keypad4))
            {
                    transform.RotateAround(pivot.position, Vector3.forward, rot   * Time.deltaTime);
                         rot++;
            }

            // X-axis
            if (Input.GetKey(KeyCode.Keypad6))
            {
                    transform.RotateAround(pivot.position, Vector3.back, rot  * Time.deltaTime);
                    rot++;
            }

        }



        if (rotor.krasch)
        {
                rig.useGravity = rig.useGravity;
        }
    }


}


