using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bean : MonoBehaviour, PlantInterface
{
    const int growthStages = 4;
    int currentGrowth = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void harvest()
    {
        if (currentGrowth >= growthStages)
        {
            //Drop items and destroy self.
        }
        else
        {
            return;
        }
    }

    void advanceStage() 
    {
        currentGrowth++;
    }
}
