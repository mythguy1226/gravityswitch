using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Switch : MonoBehaviour
{
    // Fields

    public Rigidbody player;

    // Bool will be used to determine whether gravity switch is on/off
    public bool gravitySwitch;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        gravitySwitch = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Will run if Q key is presed and gravity switch is off
        if(Input.GetKeyDown(KeyCode.Q) )//&& gravitySwitch == false)
        {
            //Physics.gravity = new Vector3(0, -1.0f, 0);

            // Will make player float up
            player.useGravity = false;

            // Will set gravity switch to true
            //gravitySwitch = true;

            // Effect values for jumping in opposite direction
        }

        if (Input.GetKeyDown(KeyCode.E))//&& gravitySwitch == false)
        {
            //Physics.gravity = new Vector3(0, -1.0f, 0);

            // Will make player float down (normal gravity)
            player.useGravity = true;

            // Will set gravity switch to true
            //gravitySwitch = true;

            // Effect values for jumping in opposite direction
        }

        //if (Input.GetKeyDown(KeyCode.Q) && gravitySwitch == true)
        //{
        //    //Physics.gravity = new Vector3(0, -1.0f, 0);
        //
        //    // Will make player float down
        //    player.useGravity = true;
        //
        //    // Will set gravity switch to false
        //    gravitySwitch = false;
        //
        //    // Effect values for jumping normally (if needed)
        //}
    }
}
