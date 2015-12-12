using UnityEngine;
using System.Collections;

/// <summary>
/// Move the camera based on user input
/// </summary>
public class UserInput : MonoBehaviour {

    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public float moveSpeed = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public float speed = 1.5f;
    public float spacing = 1.0f;
    private Vector3 pos;

    void Start()
    {
        pos = transform.position;
    }
    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");
        }
        if (Input.GetMouseButton(2))
        {
            pos -= Input.GetAxis("Mouse X") * transform.right;
            pos -= Input.GetAxis("Mouse Y") * transform.up;
        }

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        if (Input.GetKey(KeyCode.W))
            pos.y += spacing;
        if (Input.GetKey(KeyCode.S))
            pos.y -= spacing;
        if (Input.GetKey(KeyCode.A))
            pos -= spacing * transform.right;
        if (Input.GetKey(KeyCode.D))
            pos += spacing * transform.right;

        pos += Input.GetAxis("Mouse ScrollWheel") * transform.forward*5;

        transform.position = Vector3.MoveTowards(transform.position, pos, 1);
    }
}