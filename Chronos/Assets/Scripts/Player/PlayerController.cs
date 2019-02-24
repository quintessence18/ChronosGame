using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]//requires my player motor script
public class PlayerController : MonoBehaviour
{

    [SerializeField]//my variable will show up in the inspector even though it is private
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;//allows me to determine the look sensitivity 


    private PlayerMotor motor;

    void Start()
    {
        //get motor from beginning
        motor = GetComponent<PlayerMotor>();//we don't have to check for playermotor since w know its there
    }

    void Update()
    {
        //calculate movement velocity as 3D Vector
        float xMov = Input.GetAxisRaw("Horizontal"); //store horizontal movement as float, raw val to allow movemnt smoothing control if wanted
        float zMov = Input.GetAxisRaw("Vertical"); //store Vertical movement as float, raw val to allow movemnt smoothing control if wanted

        Vector3 movHorizontal = transform.right * xMov;//takes into consideration on where we are facing opposed to vector3.right, relative to player not world
        Vector3 movVertical = transform.forward * zMov;

        //movment vector final
        Vector3 _velocity = (movHorizontal + movVertical).normalized * speed; //total length of combine vector should be one, thus a direction vector multiplied by speed


        //apply movement
        motor.Move(_velocity);



        //calculate rotation as 3D Vector to be able to turn around.
        float yRot = Input.GetAxisRaw("Mouse X"); //takes the mouse input of it's position

        Vector3 _rotation = new Vector3(0f, yRot, 0f) * lookSensitivity;//calculates

        //apply Rotation
        motor.Rotate(_rotation);

        //calculate  camera rotation as 3D Vector to be able to look up.
        float xRot = Input.GetAxisRaw("Mouse Y"); //takes the mouse input of it's position
        Vector3 _cameraRotation = new Vector3(xRot, 0f, 0f) * lookSensitivity;//calculates

        //apply cameraRotation
        motor.RotateCamera(_cameraRotation);
    }

}
