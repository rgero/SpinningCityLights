using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuildings : MonoBehaviour
{
    public int RowSize = 100;
    public GameObject prefabObject;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = -RowSize; i < RowSize; i++)
        {
            for(int j = -RowSize; j < RowSize; j++)
            {

                GameObject newObject = Instantiate(prefabObject, this.gameObject.transform);
                Vector3 objPos = new Vector3(i, 1, j);
                newObject.transform.position = objPos;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
