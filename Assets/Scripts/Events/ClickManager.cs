using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ClickManager : MonoBehaviour {
    Planter planter;
    Grid gridObject;
    void Start() {
        planter = GameObject.Find("Planter").GetComponent<Planter>();
        gridObject = GameObject.Find("Grid").GetComponent<Grid>();
    }
    void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null) {
                string nameOfHitObject = hit.collider.gameObject.name;
                string tagOfHitObject = hit.collider.gameObject.tag;
                Debug.Log("raycast hit " + nameOfHitObject);
                if (nameOfHitObject == "BeanPlant(Clone)")
                {
                    BeanPlant instance = hit.collider.gameObject.GetComponent<BeanPlant>();
                    if (instance != null)
                    {
                        Debug.Log("Attempting harvest");
                        instance.Harvest();
                        Vector3Int cellPosition = gridObject.WorldToCell(mousePos2D);
                        planter.removeCoordFromList(cellPosition);
                    }
                    else
                    {
                        Debug.Log("Bean Plant Instance is Null");
                    }
                }
                else if (tagOfHitObject == "PlantableZone") //Keep this one at the bottom
                {
                    engagePlanter(mousePos2D);
                }
            }
            else
            {
                engagePlanter(mousePos2D);
            }
            
        }
    }

    void engagePlanter(Vector2 mousePos2D)
    {
        Vector3Int cellPosition = gridObject.WorldToCell(mousePos2D);
        Debug.Log(cellPosition);
        planter.Plant(cellPosition, gridObject);
    }
}

