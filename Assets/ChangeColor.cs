using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    List<Color> colorList;
    Light lightSource;
    Color currentColor;
    Color nextColor;

    public float waitTime = 10.0f;
    public float transitionTime = 3.0f;
    public float cooldownCount = 0.0f;
    public float transitionTimeLeft;
    public bool inTransition = false;

    private float rSpeed, gSpeed, bSpeed;


    // Start is called before the first frame update
    void Start()
    {
        Color blue = new Color(0.2f, 0.18f, 0.5f);
        Color red = new Color(0.69f, 0.13f, 0.22f);
        Color green = new Color(0.13f, 0.69f, 0.13f);
        colorList = new List<Color>{ blue, red, green };

        currentColor = blue;

        lightSource = this.gameObject.GetComponent<Light>();
        lightSource.color = blue;
    }

    // Update is called once per frame
    void Update()
    {
        if (inTransition)
        {
            if (transitionTimeLeft <= Time.deltaTime)
            {
                // transition complete
                // assign the target color
                lightSource.color = nextColor;

                // start a new transition
                currentColor = nextColor;
                nextColor = GetNextColor();
                transitionTimeLeft = transitionTime;
                cooldownCount = 0.0f;
                inTransition = false;
            }
            else
            {
                // transition in progress
                // calculate interpolated color
                lightSource.color = Color.Lerp(lightSource.color, nextColor, Time.deltaTime / transitionTimeLeft);

                // update the timer
                transitionTimeLeft -= Time.deltaTime;
            }
        } else
        {
            cooldownCount += Time.deltaTime;
            if (cooldownCount >= waitTime)
            {
                inTransition = true;
            }
        }

    }
    Color GetNextColor()
    {
        int curInd = colorList.IndexOf(currentColor);
        if (curInd == (colorList.Count-1))
        {
            curInd = 0;
        } else
        {
            curInd += 1;
        }
        return colorList[curInd];
    }
}
