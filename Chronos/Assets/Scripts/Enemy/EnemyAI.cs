using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//allows me to use the AI library;

public class EnemyAI : MonoBehaviour
{
    public float lookRadius = 30f;// the AI will have a detection radius of 30 

    Transform target;// create a new transformation called target used to move AI to target
    NavMeshAgent agent;// calls the NavmeshAgent Component and assigns it to the name agent

    //use this for initialization
    void Start()
    {
        target = PlayerWatch.instance.player.transform;//calls my Playermanager Script, Player = Target
        agent = GetComponent<NavMeshAgent>();//Gets my Enemy and calls my NavMeshAgent Component
    }

    void Update()
    {
        //Uses a Vector3 to get my targets position and turn it into a distance assigning it to float
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)//checks if the distance is less than look rad
        {
            agent.SetDestination(target.position);//sets the EnemyAI destination to the player
        }
    }

    void FaceTarget()
    {
        //gets the direction using normals(Vector Mathematical Calculation)
        Vector3 direction = (target.position - transform.position).normalized;
        //finds the anfle betweent he front of the enemy and its target
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        //transforms the Enemy's position to the given direction and rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmos()//allows me to see the look radius in the engine
    {
        Gizmos.color = Color.red;//the radius will be coloured in red
        Gizmos.DrawWireSphere(transform.position, lookRadius);//draws the radius
    }
}
