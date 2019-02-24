using UnityEngine;

public class TimeEffect : MonoBehaviour
{
    public float FrozenTime;//variable to control the factor of how fast time moves
    public float TimeUnfrozen;//variable to control the factor of normal time etc

    void Update()
    {
        if (Input.GetKey(KeyCode.A))//when the A button is pressed
        {
            Time.timeScale = TimeUnfrozen;//the slow motion effect on time will go back to normal
        }
        if (Input.GetKey(KeyCode.D))
        {
            Time.timeScale = TimeUnfrozen;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Time.timeScale = TimeUnfrozen;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Time.timeScale = TimeUnfrozen;
        }
        if (Input.anyKey == false)//however if any key is not being pressed
        {
            Time.timeScale = FrozenTime;//time is frozen by the set factor i put into the inspector
        }
    }
}
