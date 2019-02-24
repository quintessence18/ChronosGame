using UnityEngine;

[RequireComponent(typeof(Rigidbody))]//we want to have a rigid body using our player motor
public class PlayerMotor : MonoBehaviour
{
    //player controller uses velocity to contorl player
    private Vector3 velocity = Vector3.zero; //defaults the velocity to 0 if not moving
    private Vector3 rotation = Vector3.zero; //defaults rotation to 0 if not moving
    private Vector3 cameraRotation = Vector3.zero;//defaults rotation to 0 if not moving

    [SerializeField]
    private Camera cam;//allows me to assign the pllayer's camera in the inspeco

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();//we know we have a rigidbody
    }

    //gets movement vector
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;//assigns inputted velocity and assigns it to velocity variable
    }


    //takes the rotation vector for the camera's horizontal
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;//assigns passed camera rotation and assigns it to rotation variable
    }

    //takes the rotation vector for the camera's vertical
    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;//assigns passed camera rotation and assigns it to rotation variable
    }


    //computes calculations per frame, used for rigidbodies
    void Update()
    {
        //performs movement
        PerformMovement();
        PerformRotation();
    }

    //perform movement based on velicocity var
    void PerformMovement()
    {
        if (velocity != Vector3.zero) //checks if the ridgibody is still
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);//moves position on the fixed rate by the vector var
        }
    }

    //perfrom rotation Method
    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));//calculates the roation angles for us
        cam.transform.Rotate(-cameraRotation);
    }
}
