using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanSeed : MonoBehaviour
{
    int currentGrowth = 0;
    int growthStages = 3;
    // Start is called before the first frame update

    void Awake()
    {
        EventManager.AddListener<PlantGrowthEvent>(AdvanceStage);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdvanceStage(PlantGrowthEvent evt) 
    {
        Debug.Log("Broadcast Recieved!");
        if (currentGrowth >= growthStages)
        {
            //Destroy self and put plant in it's place.
            Debug.Log("Fully Grown!");
            var newBeanPlant = Resources.Load<BeanPlant>("BeanPlant");

            Instantiate(newBeanPlant, transform.position, transform.rotation); //Place BeanPlant at same position as the seed.
            Debug.Log("Bout to KMS!");
            EventManager.RemoveListener<PlantGrowthEvent>(AdvanceStage);
            Destroy(gameObject);
        }
        else
        {
            currentGrowth++;
            Debug.Log("Growing!");
        }
    }
}
