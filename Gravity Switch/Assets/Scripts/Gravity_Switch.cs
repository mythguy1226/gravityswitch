using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Switch : MonoBehaviour
{
    // Fields

    public Rigidbody player;
    public static bool normalGravity;

    // Bool will be used to determine whether gravity switch is on/off
    public bool gravitySwitch;

    public float flipped = 1.0f ;

    float smooth = 5.0f;

    GameObject model;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        model = transform.GetChild(1).gameObject;
        gravitySwitch = false;
        normalGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Once the C Key is Pressed the gravity will reverse and send the player in the other direction
        if(Input.GetKeyDown(KeyCode.C) && ThirdPersonCharacterController.canJump)
        {
            // Send Player Upwards
            if (normalGravity)
            {
                Physics.gravity = new Vector3(0, 9.8F, 0);
                normalGravity = false;
            }
            else // Send Player Downwards
            {
                Physics.gravity = new Vector3(0, -9.8F, 0);
                normalGravity = true;
            }
            ThirdPersonCharacterController.canJump = false;
        }
        if(transform.rotation.z != 0)Debug.Log(transform.rotation.z);

        Quaternion targetRotate;
        Vector3 targetHeight;
        if (normalGravity)
        {
            targetRotate = new Quaternion(0, model.transform.rotation.y, 0, model.transform.rotation.w);
            targetHeight = new Vector3(model.transform.position.x, transform.position.y - 1, model.transform.position.z);
        }
        else
        {
            targetRotate = new Quaternion(0, model.transform.rotation.y, 180.0f, model.transform.rotation.w);
            targetHeight = new Vector3(model.transform.position.x, transform.position.y + 1, model.transform.position.z);
        }
        model.transform.rotation = targetRotate;
        model.transform.position = targetHeight;

        /*
        // Will run if Q key is presed and gravity switch is off
        if(Input.GetKeyDown(KeyCode.Q) )//&& gravitySwitch == false)
        {
            //Physics.gravity = new Vector3(0, -1.0f, 0);

            // Will make player float up
            //player.useGravity = false;
            Physics.gravity = new Vector3(0, -9.8F, 0);
            // Will set gravity switch to true
            //gravitySwitch = true;

            // Effect values for jumping in opposite direction
        }

        if (Input.GetKeyDown(KeyCode.E))//&& gravitySwitch == false)
        {
            //Physics.gravity = new Vector3(0, -1.0f, 0);

            // Will make player float down (normal gravity)
            //player.useGravity = true;
            Physics.gravity = new Vector3(0, 9.8F, 0);

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
        //}*/
    }
}
