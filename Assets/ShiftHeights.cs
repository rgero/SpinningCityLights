using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftHeights : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHeight = 5.0f;
    public float minHeight = 0.75f;
    public float minSpeed = 0.5f;
    public float maxSpeed = 2.5f;
    private bool goingUp;
    private float speed;

    void Start()
    {
        goingUp = (Random.value > 0.5);
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.localScale.y >= maxHeight || this.transform.localScale.y <= minHeight)
        {
            changeDirection();
        }

        Vector3 lScale = this.transform.localScale;
        float scaleChange = Time.deltaTime * speed;
        lScale.y += (goingUp ? scaleChange : -1 * scaleChange);
        this.transform.localScale = lScale;
    }

    void changeDirection()
    {
        Debug.Log("Fired");
        goingUp = !goingUp;
        speed = Random.Range(minSpeed, maxSpeed);
    }
}
