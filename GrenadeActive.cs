using System.Collections;
using UnityEngine;

public class GrenadeActive : MonoBehaviour
{
    public float Speed;
    public float currentSpeed;
    public float timer;
    private void Awake()
    {

    }
    void Start()
    {
        timer = 1f;
        currentSpeed = Speed;
    }
    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator UpdateFrame()
    {
        timer += Time.deltaTime;
        transform.position = new Vector3(transform.position.x,
            transform.position.y + currentSpeed * Mathf.Sin(60f * Mathf.Deg2Rad) - (9.8f * timer),//(currentSpeed * timer * Mathf.Sin(60f * Mathf.Deg2Rad) - (9.8f * Mathf.Pow(timer, 2) / 2f)),
            transform.position.z + (currentSpeed * Mathf.Sin(60f * Mathf.Deg2Rad))); //* Mathf.Cos(60f * Mathf.Deg2Rad)*timer));
        if (transform.position.y <= 0f)
        {
            currentSpeed /= 3f;
            if (currentSpeed <= 0.0000001f)
            {
                currentSpeed = 0f;
            }
            timer = Time.deltaTime;
        }
        yield return null;
    }
}
