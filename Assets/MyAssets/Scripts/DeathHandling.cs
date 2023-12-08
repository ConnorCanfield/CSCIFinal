using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // needed to reload the scene
using UnityEngine.UI; //needed to reference the 'Image' type

public class DeathHandling : MonoBehaviour
{
    public Image Effect; //A UI Image

    void OnTriggerEnter()
    {
        Effect.enabled = true; //enable the image (this is the red flash effect that's seen when the player is hit)
        Invoke("Death", .1f); //call the Death() function on a 0.1 second delay
    }

    void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Reload the current scene (used to restart the level)
    }
}
