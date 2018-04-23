using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCube : MonoBehaviour {
    private Renderer _Renderer;
    public float _ScrollSpeed = 0.5F;
    // Use this for initialization
    void Start ()
    {
        _Renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        float offset = Time.time * _ScrollSpeed;
        _Renderer.material.SetTextureOffset("_MainTex", new Vector2(0, -offset));

    }
}
