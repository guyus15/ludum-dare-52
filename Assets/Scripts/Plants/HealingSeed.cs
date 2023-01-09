using UnityEngine;

public class HealingSeed : MonoBehaviour, ISeed
{
    [SerializeField] private int growthStages;
    private int currentGrowth = 0;

    public Sprite[] sprites;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    void Awake()
    {
        EventManager.AddListener<PlantGrowthEvent>(AdvanceStage);
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void AdvanceStage(PlantGrowthEvent evt)
    {
        currentGrowth++;

        if (currentGrowth > growthStages - 1)
        {
            var newHealingPlant = Resources.Load<HealingPlant>("Prefabs/Plants/HealingPlant");

            Instantiate(newHealingPlant, transform.position, transform.rotation);
            EventManager.RemoveListener<PlantGrowthEvent>(AdvanceStage);
            Destroy(gameObject);
        }
        else
        {
            spriteRenderer.sprite = sprites[currentGrowth];
        }
    }
}
