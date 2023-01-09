using UnityEngine;
using UnityEngine.SceneManagement;
public class BeanPlant : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetMouseButtonDown(0)){
            Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit)){
            Debug.Log("hit something");
            if(hit.transform.name=="BeanPlant"){
                harvest();
            }
            }
        }*/
    }

    public void Harvest()
    {
        //Give items and destroy self.
        var seed = Resources.Load<Item>("Items/Scriptable Objects/BeanSeed");
        var crop = Resources.Load<Item>("Items/Scriptable Objects/Bean");
        Inventory.instance.Add(seed);
        Inventory.instance.Add(crop);

        // Remove coordinate from used coords.
        Vector3Int tileMapCoord = Planter.instance.grid.WorldToCell(transform.position);
        Planter.instance.removeCoordFromList(tileMapCoord);

        Destroy(gameObject);
    }
}
