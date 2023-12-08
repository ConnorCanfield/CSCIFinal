using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSmooth : MonoBehaviour
{
    public Transform Target; //Target object's transform component
    public float Smooth;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position, Smooth * Time.deltaTime); //Smoothly move this object's position to that of 'Target' smoothly. A higher 'Smooth' value results in a faster movement
        //note: 'Transform' is a type. 'transform' is a reference to the Transform on the same object this script is attached to
    }
}
