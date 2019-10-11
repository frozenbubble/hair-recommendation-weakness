using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GridTile;

public class Plant : Tool
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, 100))
            {
                var tile = hit.collider.GetComponent<GridTile>();

                if (tile != null && tile.State != GridState.TechnicalNode && tile.KorpaLevel <= 1)
                {
                    tile.SetState(GridState.Hair);
                }
            }
        }
    }
}
