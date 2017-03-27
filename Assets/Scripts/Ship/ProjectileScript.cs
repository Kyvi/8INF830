﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    public GameObject Reticle;
    public GameObject Gauge;
    public float dammage;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider entity)
    {      
        //entity.gameObject.GetComponent<AsteroidsDesintegration>().health -= 5;
        Debug.Log(entity.gameObject.name);
        //Debug.Log(entity.gameObject.GetComponent<AsteroidsDesintegration>().health);
        //Destroy(gameObject)
        Entity temp = entity.GetComponentInParent<Entity>();
        if(temp != null)
        {
            temp.takeDammage((int)dammage);
            if (Reticle != null)
            {
                Reticle.GetComponent<OnHitColorChange>().OnHit();
            }
            if (Gauge != null && temp.name != "Asteroid") {
                Gauge.GetComponent<HealthGaugeDisplay>().DisplayHealthOnHit(temp.health, temp.maxHP, temp.name);
            }
        }

        Destroy(gameObject);
    }


    public void SetParent(GameObject _reticle,GameObject _gauge)
    {
        Reticle = _reticle;
        Gauge = _gauge;
    }
    

}
