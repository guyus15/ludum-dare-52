using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ClickManager : MonoBehaviour {
    Grid gridObject;
    void Start() {
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

                if (nameOfHitObject == "BeanPlant(Clone)")
                {
                    BeanPlant instance = hit.collider.gameObject.GetComponent<BeanPlant>();
                    if (instance != null)
                    {
                        instance.Harvest();
                        Vector3Int cellPosition = gridObject.WorldToCell(mousePos2D);
                        Planter.instance.removeCoordFromList(cellPosition);
                    }
                }
                else
                {
                    engagePlanter(mousePos2D);
                }
            }
            else
            {

                Debug.Log("Area collider is null");
                engagePlanter(mousePos2D);
            }
            
        }
    }

    void engagePlanter(Vector2 mousePos2D)
    {
        Vector3Int cellPosition = gridObject.WorldToCell(mousePos2D);
        Planter.instance.Plant(cellPosition, gridObject);
    }
}

