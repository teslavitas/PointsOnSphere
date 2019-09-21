using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform trackingTarget;
    public float speed;
    public float minDistance;

    void Update()
    {
        handlerRotation();
        handleZoom();
    }


    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.LookAt(trackingTarget);
    }

    private void handlerRotation()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        
        Vector3 movement = new Vector3(moveVertical, -moveHorizontal, moveVertical);
        Vector3 movementGlobal = this.transform.TransformDirection(movement);

        transform.RotateAround(trackingTarget.position, movementGlobal, speed * Time.deltaTime);
    }

    private void handleZoom()
    {
        float direction = 0.0f;
        if (Input.GetKey("[") && Vector3.Distance(this.transform.position, this.trackingTarget.position) > this.minDistance)
        {
            //zoom in
            direction = 1.0f;
        }
        else if (Input.GetKey("]"))
        {
            //zoom out
            direction = -1.0f;
        }

        if (direction != 0.0f)
        {
            float step = this.speed * Time.deltaTime * direction * 0.05f;
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.trackingTarget.position, step);
        }
    }
}
