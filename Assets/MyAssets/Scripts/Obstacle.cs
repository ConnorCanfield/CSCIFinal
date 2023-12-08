using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //public Vector2Int Config; // (width, height)
    public float Speed; // Obstacle Speed
    public GameObject ObstacleInstance; //The object that will be duplicated to spawn the obstacles
    [Range(1, 8)] //Attribute limiting the range of a numerical value
    public int BlockCount = 1; //The amount of blocks to spawn for this obstacle
    public List<GameObject> Blocks;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10f); //deletes the gameobject this script is attached to in 10 seconds. This is for making sure that obstacles that pass the player are eventually deleted
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                GameObject G = Instantiate(ObstacleInstance, transform.position + new Vector3(x - 1f, y - 1f, 0f), Quaternion.identity, transform); // create blocks in a 3x3 grid
                Blocks.Add(G); //add the new blocks to a list for later
            }
        }
        int Failsafe = 0; //int used to track how many times the loop runs (a runaway 'while' loop can freeze Unity)
        while (Blocks.Count > BlockCount && Failsafe < 30) //loops until the correct amount of blocks have been removed
        {
            if (Random.Range(0, 2) == 1) // 50% change to call
            {
                int I = Random.Range(0, Blocks.Count);
                //Random.Range gets a random value between the specified min and max. For integers, the max is exclusive instead of inclusive

                Destroy(Blocks[I]); //Remove the object from the game
                Blocks.RemoveAt(I); //Remove the empty space in the list from the deleted block
            }
            Failsafe++;
        }
    }

    void FixedUpdate() //called at a fixed interval (is called at the same rate as the physics, so movement is done here)
    {
        transform.Translate(new Vector3(0, 0, -Speed * Time.deltaTime)); //Moves the objects position based on a vector
        // Time.deltaTime is the amount of time the previous frame took. Multiplying by this keeps movement speed from being effected by framerate
    }
}
