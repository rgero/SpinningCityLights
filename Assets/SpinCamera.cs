using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCamera : MonoBehaviour
{
    public GameObject circleObject;
    public float radiusDisance = 20.0f;
    public float cameraHeight = 6.0f;
    public float timeDelay = 15.0f;
    private bool direction = true;
    private float currentTime = 0.0f;
    public float minRate = 5.0f;
    public float maxRate = 22.0f;
    public float speedOffset = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(0, cameraHeight, radiusDisance);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeDelay)
        {
            currentTime = 0.0f;
            direction = (Random.value > 0.5f);
            Debug.Log("Changing Direction");
            timeDelay = Random.Range(minRate, maxRate);
        }

        this.gameObject.transform.LookAt(circleObject.transform);
        if (direction)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speedOffset);
        } else
        {
            transform.Translate(Vector3.left * Time.deltaTime * speedOffset);
        }
    }
}
