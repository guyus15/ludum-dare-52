using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Planter : MonoBehaviour
{
    List<Vector3Int> coordsBeingUsed = new List<Vector3Int>();
    // NavMesh.SamplePosition if true seed can be placed
    public void Plant(Vector3Int cellPosition, Grid gridObject)
    {
        if(!coordsBeingUsed.Contains(cellPosition)) //There are no duplicates
        {
            Vector3 worldPos = gridObject.CellToWorld(cellPosition); //Get actual world position
            coordsBeingUsed.Add(cellPosition); //Add to the list
            Item currentItem;
            /*if (currentItem.itemType == Plantable)
            {
                var seed = currentItem.itemObject;
                Instantiate(seed, worldPos, transform.rotation);
            }*/
            //var newBeanSeed = Resources.Load<Seed>("Prefabs/Plants/BeanPlant");
            //Instantiate(newBeanSeed, transform.position, transform.rotation);
        }
        else
        {
            
        }
    }
    //FOR the GATato have a circle collider that detects when something enters, checks if its a enemy, then makes it it's target until it dies or goes out of range.
}
