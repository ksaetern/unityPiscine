using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    public float picknum = 0f;


    private void OnEnable()
    {
        
        picknum = Random.Range(5f, 10.0f);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, -picknum, 0);

	}

	
}
