using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ClickManager : MonoBehaviour {
    void start() {
    }
    void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null) {
                string nameOfHitObject = hit.collider.gameObject.name;
                Debug.Log(nameOfHitObject);
                if (nameOfHitObject == "BeanPlant(Clone)")
                {
                    BeanPlant instance = hit.collider.gameObject.GetComponent<BeanPlant>();
                    if (instance != null)
                    {
                        instance.harvest();
                    }
                }
                else
                {
                    Grid gridObject;
                    gridObject = GameObject.Find("Grid").GetComponent<Grid>();
                    Vector3Int cellPosition = gridObject.WorldToCell(mousePos2D);
                    //Planter.plant(cellPosition);
                    Debug.Log(cellPosition);
                    
                }
            }
        }
    }

}
