using UnityEngine;

public class BeanPlant : MonoBehaviour, IPlant
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit)){
            Debug.Log("hit something");
            if(hit.transform.name=="BeanPlant"){
                Debug.Log("HIT!");
                Harvest();
            }
            }
        }
    }

    public void Harvest()
    {
        //Give items and destroy self.
        var seed = Resources.Load<Item>("Items/Scriptable Objects/BeanSeed");
        var crop = Resources.Load<Item>("Items/Scriptable Objects/Bean");
        Inventory.instance.Add(seed);
        Inventory.instance.Add(crop);
        Destroy(gameObject);
    }
}
