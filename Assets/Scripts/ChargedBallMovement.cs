using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChargedBallMovement : MonoBehaviour
{
    public float forceMultiplier;
    public GameObject movementSurface;
    private float surfaceRadius;

    // Start is called before the first frame update
    void Start()
    {
        this.surfaceRadius = this.movementSurface.transform.lossyScale.y / 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        var allBalls = GameObject.FindGameObjectsWithTag("ChargedBall");
        var balls = allBalls.Where(obj => !obj.Equals(this.gameObject));

        foreach (var ball in balls)
        {
            var heading = ball.transform.position - this.transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance; // This is now the normalized direction.

            var forceWithDistance = -direction / heading.sqrMagnitude;
            this.GetComponent<Rigidbody>().AddForce(forceWithDistance * this.forceMultiplier * Time.deltaTime);
        }
    }

    void LateUpdate()
    {
        var surfaceHeading = this.movementSurface.transform.position - this.transform.position;
        var surfaceDistance = surfaceHeading.magnitude;
        if (surfaceDistance > this.surfaceRadius)
        {
            this.transform.position = 
                Vector3.MoveTowards(this.transform.position, this.movementSurface.transform.position, surfaceDistance - this.surfaceRadius);
        }
    }
}
