using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightwave : MonoBehaviour {
    float movespeed = 2f;
    float acce = 5f;
   bool isfront = true;
    // Use this for initialization
  public lightwave setdir(bool dir)
    {
        isfront = dir;
        return this;
    }
    void Start () {
        Debug.Log("start");
    }
	
	// Update is called once per frame
	void Update () {
        if (isfront)
        {
            this.transform.Translate(new Vector2(movespeed * Time.deltaTime, 0));
        }
        else
        {
            this.transform.Translate(new Vector2(-movespeed * Time.deltaTime, 0));
        }
       
        movespeed += acce * Time.deltaTime;
	}
}
