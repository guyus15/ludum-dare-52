using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BeanPlant : MonoBehaviour, PlantInterface
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
                harvest();
            }
            }
        }
    }
    public void harvest()
    {
        //Give items and destroy self.
        var seed = Resources.Load<Item>("Items/Scriptable Objects/BeanSeed");
        var crop = Resources.Load<Item>("Items/Scriptable Objects/Bean");
        Inventory.instance.Add(seed);
        Inventory.instance.Add(crop);
        Destroy(gameObject);
    }
}
