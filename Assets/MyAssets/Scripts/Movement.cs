using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Keyboard Keys for different movement directions
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Right;
    public KeyCode Left;

    // Update is called once per frame
    void Update()
    {
        Vector3 MoveVector = Vector3.zero; //Vector used to log the movement
        if(Input.GetKeyDown(Up)) //Call if the key specified for 'Up' is pressed
        {
            MoveVector.y += 1; 
        }
        if(Input.GetKeyDown(Down))
        {
            MoveVector.y -= 1; 
        }
        if(Input.GetKeyDown(Right))
        {
            MoveVector.x += 1; 
        }
        if(Input.GetKeyDown(Left))
        {
            MoveVector.x -= 1; 
        }

        if (!Physics.Linecast(transform.position, transform.position + MoveVector)) //Hitscan. If this hits nothing, the player moves
        {
            transform.Translate(MoveVector); //adds the diven vector to the position for the specified Transform. Transforms track position, rotation, and scale of objects
        }
    }
}
