using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float xAxis, yAxis;
    Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = PlayerInput.instance.playerRotateinput.x;
        yAxis = PlayerInput.instance.playerRotateinput.y;
        yAxis = Mathf.Clamp(yAxis, 70, 70);
    }
}
