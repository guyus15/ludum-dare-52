using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanSeed : MonoBehaviour, ISeed
{
    int currentGrowth = 0;
    int growthStages = 3;

    void Awake()
    {
        EventManager.AddListener<PlantGrowthEvent>(AdvanceStage);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AdvanceStage(PlantGrowthEvent evt) 
    {
        if (currentGrowth >= growthStages)
        {
            //Destroy self and put plant in it's place.
            Debug.Log("Fully Grown!");
            var newBeanPlant = Resources.Load<BeanPlant>("BeanPlant");

            Instantiate(newBeanPlant, transform.position, transform.rotation); //Place BeanPlant at same position as the seed.
            EventManager.RemoveListener<PlantGrowthEvent>(AdvanceStage);
            Destroy(gameObject);
        }
        else
        {
            currentGrowth++;
        }
    }
}
