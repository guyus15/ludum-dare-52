using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPlantseed : MonoBehaviour
{
    int currentGrowth = 0;
    int growthStages = 3;
    public Sprite[] sprites;
    // Start is called before the first frame update
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    void Awake()
    {
        EventManager.AddListener<PlantGrowthEvent>(AdvanceStage);
    }
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void AdvanceStage(PlantGrowthEvent evt) 
    {
        currentGrowth++;

        if (currentGrowth > growthStages - 1)
        {
            //Destroy self and put plant in it's place.
            var newPlant = Resources.Load<GunPlant>("Prefabs/Plants/GunPlant");

            Instantiate(newPlant, transform.position, transform.rotation); //Place BeanPlant at same position as the seed.
            EventManager.RemoveListener<PlantGrowthEvent>(AdvanceStage);
            Destroy(gameObject);
        }
        else
        {
            spriteRenderer.sprite = sprites[currentGrowth];
        }
    }
}


