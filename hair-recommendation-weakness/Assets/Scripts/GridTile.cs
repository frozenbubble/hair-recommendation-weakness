using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
	
	public enum GridState {
		Empty,
		TechnicalNode,
		Hair,
		Dead,
		Count
	}
	
	
	public GameObject HajRoot;
	public GameObject TileGridRoot;
	public ParticleSystem Korpa;
	
	public Color BaseSkinColor;
	public Color TechnicalNodeColor;
	public Color DeadColor;
	
	public int KorpaLevel = 0;
	
	
	
	public GridState State = GridState.Empty;
	
	
	public float nextKorpaLevelInSec = 0.0f;
	
	private float baseWaitSec = 4.0f;
	
	
    // Start is called before the first frame update
    void Start()
    {
    	
    	var em = Korpa.emission;
    	em.rateOverTime = 0;
    	
    	SetState(State);
    	SetKorpaLevel(1);
    }

    // Update is called once per frame
    void Update()
    {
    	HandleKorpasodas();
    }

    
	void HandleKorpasodas()
	{
		if(State != GridState.Empty){
			nextKorpaLevelInSec = 0.0f;
			return;
		}
		
		if(nextKorpaLevelInSec < 0.01f && KorpaLevel < 7){
			SetKorpaLevel(KorpaLevel + 1);
		}
		
		
		nextKorpaLevelInSec -= Time.deltaTime;
		
	}
	
	
	
	void ClearKorpa(){
		SetKorpaLevel(0);
	}
	
	
    
    void SetState(GridState newState){
    	State = newState;
    	SetupState();
    }
    
    
    
    void SetKorpaLevel(int newLevel){
    
    	var em = Korpa.emission;
    	
    	if(State != GridState.Empty){
    		return;
    	}
    	
    	
    	if(newLevel == 1){
    		em.rateOverTime = 0;
    		nextKorpaLevelInSec = 2*Random.Range(baseWaitSec, baseWaitSec + 4.5f);
    	}
    	
    	if(newLevel == 1){
    		em.rateOverTime = 0;
    		nextKorpaLevelInSec = Random.Range(baseWaitSec, baseWaitSec + 10.5f);
    	}
    	
    	if(newLevel == 2){
    		em.rateOverTime = 2;
    		nextKorpaLevelInSec = Random.Range(baseWaitSec, baseWaitSec + 10.5f);
    	}
    	
    	if(newLevel == 3){
    		em.rateOverTime = 4;
    		nextKorpaLevelInSec = Random.Range(baseWaitSec, baseWaitSec + 5.5f);
    	}
    
    	
    	if(newLevel == 4){
    		em.rateOverTime = 10;
    		nextKorpaLevelInSec = Random.Range(baseWaitSec, baseWaitSec + 5.5f);
    	}
    
    	
    	if(newLevel == 5){
    		em.rateOverTime = 20;
    		nextKorpaLevelInSec = 2*Random.Range(baseWaitSec, baseWaitSec + 5.5f);
    	}
    
    	
    	if(newLevel == 6){
    		em.rateOverTime = 250;
    		nextKorpaLevelInSec = 3*Random.Range(baseWaitSec, baseWaitSec + 5.5f);
    	}
    	
    	
    	if(newLevel == 7){
    		em.rateOverTime = 0;
    		SetState(GridState.Dead);
    	}
    	
    	
    	if(newLevel > 7 || newLevel < 0){
    		throw new UnityException("NO NO NO");
    	}
    	
    	KorpaLevel = newLevel;
    
    }
    
    
    
    void SetupState(){
    	switch(State){
    		case GridState.Empty:
    			HajRoot.SetActive(false);
    			TileGridRoot.SetActive(true);
    			TileGridRoot.GetComponent<MeshRenderer>().material.SetColor("_Color", BaseSkinColor);
    			break;
    		case GridState.TechnicalNode:
    			HajRoot.SetActive(false);
    			TileGridRoot.SetActive(true);
    			TileGridRoot.GetComponent<MeshRenderer>().material.SetColor("_Color", TechnicalNodeColor);
    			break;
    		case GridState.Hair:
    			HajRoot.SetActive(true);
    			TileGridRoot.SetActive(true);
    			TileGridRoot.GetComponent<MeshRenderer>().material.SetColor("_Color", BaseSkinColor);
    			break;
    		case GridState.Dead:
    			HajRoot.SetActive(false);
    			TileGridRoot.SetActive(true);
    			TileGridRoot.GetComponent<MeshRenderer>().material.SetColor("_Color", DeadColor);
    			break;
    		default:
    			throw new UnityException("NO NO");
    			break;
    		
    	
    	
    	}
    }
}
