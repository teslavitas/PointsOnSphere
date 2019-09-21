using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObjectButtonClick : MonoBehaviour
{
    public GameObject prefabToAdd;
    public GameObject movementSurface;
    
    public void AddNewObject()
    {
        var randomizedCoordX = Random.value * 10 - 5;
        var randomizedCoordZ = Random.value * 10 - 5;
        Vector3 coordinates = new Vector3(randomizedCoordX, this.movementSurface.transform.lossyScale.y * 0.5f, randomizedCoordZ);
        
        var ball = Instantiate(this.prefabToAdd, coordinates, Quaternion.identity).GetComponent<Rigidbody>();
        ball.GetComponent<ChargedBallMovement>().movementSurface = this.movementSurface;
    }
}
