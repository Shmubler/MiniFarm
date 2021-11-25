using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeTileOnClick : MonoBehaviour
{
    public Grid grid;
    public Tilemap ground;
    public Tile tile;

    bool isTileChangeable;

    // Start is called before the first frame update
    void Start()
    {
        isTileChangeable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleTileChange() {
        isTileChangeable = !isTileChangeable;
    }

    void OnMouseDown() {
        if (isTileChangeable) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
            Vector3Int position = grid.WorldToCell(worldPoint);
            ground.SetTile(position, tile);
            ToggleTileChange();
        }
    }
}
