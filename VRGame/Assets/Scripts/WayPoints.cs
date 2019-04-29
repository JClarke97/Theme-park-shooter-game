using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{

    //creating a array of game objets 
    public GameObject[] waypoints;
    //the current point of the array the object should be going towards
    int current = 0;
    
    float rotSpeed;
    //speed of game object
    public float speed;
    //giveing a radius to the waypints so the game object doesnt miss the game object
    float WPradius = 1;

    void Update()
    {
        //if the distance beween the current position of the object is less than the waypoint radius
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            //add one to the current value
            current++;
            //check if the int value of current is larger than current then reset the value to 0
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
        //moveing the object to the current waypoints position
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
    }
    
}