using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public int speed = 5;
    public float zoomSpeed = 2.5f;
    public float minSize = 5f;
    public float maxSize = 13;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(horizontal, vertical, 0);


        Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 1, 5);
    }
}
