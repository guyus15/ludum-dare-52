using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Planter : MonoBehaviour
{
    public List<Vector3Int> coordsBeingUsed = new List<Vector3Int>();
    // NavMesh.SamplePosition if true seed can be placed
    public void Plant(Vector3Int cellPosition, Grid gridObject)
    {
        if(!coordsBeingUsed.Contains(cellPosition)) //There are no duplicates
        {
            Vector3 worldPos = gridObject.CellToWorld(cellPosition); //Get actual world position
            Item currentItem = Equipment.instance.CurrentlyActiveItem;
            if (currentItem != null)
            {
                if (currentItem.itemType == ItemType.Plantable)
                {
                    var seed = currentItem.itemObject;
                    if (seed == null)
                    {
                        Debug.Log("currentItem.itemType is null");
                    }
                    worldPos.x += 0.5f;
                    worldPos.y += 0.5f;
                    Instantiate(seed, worldPos, transform.rotation);
                    coordsBeingUsed.Add(cellPosition); //Add to the list
                }
                
            }
            //var newBeanSeed = Resources.Load<Seed>("Prefabs/Plants/BeanPlant");
            //Instantiate(newBeanSeed, transform.position, transform.rotation);
        }
        else
        {
            Debug.Log("Seed already Present");
        }
    }

    public void removeCoordFromList(Vector3Int coord)
    {
        //The issue is that because we check if raycast hits plant rather than the grid the plant is in we get different values for gird position 
        if(coordsBeingUsed.Contains(coord))
        {
            coordsBeingUsed.Remove(coord);

        }
        else
        {
            Debug.Log("coordinates not in coord list, cannot remove.");
        }
    }
    //FOR the GATato have a circle collider that detects when something enters, checks if its a enemy, then makes it it's target until it dies or goes out of range.
}
