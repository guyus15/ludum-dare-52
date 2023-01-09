using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectComparer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float distanceFromGameObject(GameObject mainGameObject, GameObject target)
    {
        float result = Vector3.Distance(target.transform.position, mainGameObject.transform.position);
        return result;
    }
}
