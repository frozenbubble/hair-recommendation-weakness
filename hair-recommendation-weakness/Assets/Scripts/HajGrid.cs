using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HajGrid : MonoBehaviour
{
	
	public int x_size = 2;
	public int y_size = 2;
	
	public float grid_tile_size = 1.1f;
	
	public GameObject BottomLeft;
	public GameObject TopRight;
	
	public GameObject Fejbub;
	
	
	public GameObject[,] Grids;
	
	
	public float fromXAngle = 0;
	public float toXAngle = 180;
	
	public float fromYAngle = 0;
	public float toYAngle = 180;
	
	public float R = 3f;
	
	
	public float TilesScale = 0.8f;
	
	
	// Start is called before the first frame update
	void Start()
	{
		SetupGrid();
	}
	
	
	
	void SetupGrid(){
	
		if(Grids == null){
			Grids = new GameObject[x_size + 1,y_size + 1];
		}
		
		var xAngleStep = (toXAngle - fromXAngle) / (x_size);
		var yAngleStep = (toYAngle - fromYAngle) / (y_size);
		
		int arri = 0;
		int arrj = 0;
		
		for(float i = fromXAngle; i <= toXAngle; i += xAngleStep){
			for(float j = fromYAngle; j <= toYAngle; j += yAngleStep){
				
				var spherePos = new Vector3(
					R*Mathf.Sin(i * Mathf.Deg2Rad)*Mathf.Cos(j* Mathf.Deg2Rad),
					R*Mathf.Sin(i* Mathf.Deg2Rad)*Mathf.Sin(j* Mathf.Deg2Rad),
					R*Mathf.Cos(i* Mathf.Deg2Rad)
				);
				
				GameObject instance = Instantiate(Resources.Load("Prefabs/HajGridTile", typeof(GameObject))) as GameObject;
				instance.transform.parent = transform;
				instance.transform.position= transform.position + spherePos;
				instance.transform.localScale = new Vector3(TilesScale * instance.transform.localScale.x, 
				                                            TilesScale * instance.transform.localScale.y,
				                                            TilesScale * instance.transform.localScale.z);
				
				instance.transform.rotation = Quaternion.FromToRotation (transform.up, spherePos.normalized) * instance.transform.rotation;
			
				Grids[arri, arrj] = instance;
				arrj++;
			}
			arrj = 0;
			arri++;
		}
	}
	
	

	// Update is called once per frame
	void Update()
	{

	}
}
