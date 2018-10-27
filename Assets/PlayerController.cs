using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float strength = 1.0f;
    Rigidbody r;
    List<Camera> cameras;
    int current_camera_index = 0;
    float rotation_speed = 50.0f;

    // Offset for Main Camera
    float yOffset = 10.0f;

    // Use this for initialization
    void Start()
    {
        r = GetComponentInChildren<Rigidbody>();
        // Main Camera/cameras[0] ==> top-down view
        // Camera2/cameras[1] ==> first person view
        // Camera3/cameras[2] ==> first person view, rolls with ball
        cameras = new List<Camera> { GameObject.Find("Player/Main Camera").GetComponent<Camera>(),
            GameObject.Find("Player/Camera2").GetComponent<Camera>(),
            GameObject.Find("Player/Ball/Camera3").GetComponent<Camera>() };
        cameras[0].enabled = true;
        cameras[1].enabled = false;
        cameras[2].enabled = false;
        cameras[1].transform.SetPositionAndRotation(GameObject.Find("Ball").transform.position, Quaternion.Euler(0, 180, 0));
        cameras[0].transform.SetPositionAndRotation(new Vector3(GameObject.Find("Ball").transform.position.x, GameObject.Find("Ball").transform.position.y + yOffset, GameObject.Find("Ball").transform.position.z), Quaternion.Euler(90, 180, 0));
    }

    // Update is called once per frame
    void Update()
    {
        GameObject ball = GameObject.Find("Ball");
        cameras[1].transform.position = ball.transform.position;
        cameras[0].transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y + yOffset, ball.transform.position.z);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            r.AddForce(cameras[1].transform.forward * strength, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            r.AddForce(cameras[1].transform.forward * -strength, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            r.AddForce(cameras[1].transform.right * -strength, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            r.AddForce(cameras[1].transform.right * strength, ForceMode.Impulse);
        }
        if(Input.GetKey(KeyCode.Space)) {
            r.AddForce(cameras[1].transform.up * strength, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            switchCamera();
        }
        if(Input.GetKey(KeyCode.A)) {
            for (int i = 1; i < cameras.Count; i++) {
                cameras[i].transform.Rotate(-Vector3.up * rotation_speed * Time.deltaTime, Space.World);
            }
            ball.transform.Rotate(-Vector3.up * rotation_speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)) {
            for (int i = 1; i < cameras.Count; i++) {
                cameras[i].transform.Rotate(Vector3.up * rotation_speed * Time.deltaTime, Space.World);
            }
            ball.transform.Rotate(Vector3.up * rotation_speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S)) {
            for (int i = 1; i < cameras.Count; i++) {
                cameras[i].transform.Rotate(Vector3.right * rotation_speed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.W)) {
            for (int i = 1; i < cameras.Count; i++) {
                cameras[i].transform.Rotate(-Vector3.right * rotation_speed * Time.deltaTime);
            }
        }
    }

    // switches between cameras
    void switchCamera() {
        switch (current_camera_index) {
            case 0:
                cameras[0].enabled = false;
                cameras[1].enabled = true;
                cameras[2].enabled = false;
                current_camera_index++;
                break;
            case 1:
                cameras[0].enabled = false;
                cameras[1].enabled = false;
                cameras[2].enabled = true;
                current_camera_index++;
                break;
            case 2:
                cameras[0].enabled = true;
                cameras[1].enabled = false;
                cameras[2].enabled = false;
                current_camera_index = 0;
                break;
        }
    }
}
