using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private float rotationX;

    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            var rotationHorizontal = 8.00f * Input.GetAxis("Mouse X");
            var rotationVertical = 8.00f * Input.GetAxis("Mouse Y");

            transform.Rotate(Vector3.up * rotationHorizontal, Space.World);

            var rotationY = transform.localEulerAngles.y;

            rotationX += rotationVertical;
            rotationX = Mathf.Clamp(rotationX, -90, 90);

            transform.localEulerAngles = new Vector3(-rotationX, rotationY, 0);
        }

        var moveVector = Vector3.zero;

        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            moveVector.z += 1;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            moveVector.z -= 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D))
        {
            moveVector.x += 1;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A))
        {
            moveVector.x -= 1;
        }

        transform.Translate(moveVector);
    }
}