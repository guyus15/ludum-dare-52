using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEventBroadcaster : MonoBehaviour
{
    // Start is called before the first frame update
    // Next update in second
    private int nextUpdate=1;
    PlantGrowthEvent growthEvt = Events.s_PlantGrowthEvent;
    // Update is called once per frame
    void Start()
    {

    }
    void Update(){
        // If the next update is reached
        if(Time.time>=nextUpdate){
            // Change the next update (current second+1)
            nextUpdate=Mathf.FloorToInt(Time.time)+1; //CHANGE THIS BACK TO 10
            // Call your fonction
            UpdateEveryTenSecond();
        }
     
    }
    // Update is called once per second
    void UpdateEveryTenSecond(){
        Debug.Log("Grow event");
        EventManager.Broadcast(growthEvt);
    }

}
