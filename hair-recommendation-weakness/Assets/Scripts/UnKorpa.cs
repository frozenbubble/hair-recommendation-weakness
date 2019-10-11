﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnKorpa : Tool
{
    [SerializeField]
    private float _radius = 0.04f;

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
                var impactedObjects = Physics.OverlapSphere(hit.point, _radius);

                foreach (var obj in impactedObjects)
                {
                    var tile = obj.GetComponent<GridTile>();

                    tile.ClearKorpa();
                }
            }
        }
    }
}
