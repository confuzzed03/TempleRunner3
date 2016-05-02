﻿using UnityEngine;
using System.Collections;

public class GroundControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    //Material texture offset rate
    public float speed = .5f;

    //Offset the material texture at a constant rate
    void Update()
    {
        float offset = Time.time * speed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, -offset);
    }
}
