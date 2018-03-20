using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeSpawner : MonoBehaviour {

    public GameObject Letters;
    public Text text;
    public string letter;

    public float spawnTime = 2f;
    public float timer = 0f;
    public bool Spawned = false;

    private GameObject newLetter;
    private int pickNum = 0;
    private float precision = 0;


    //Debug.Log, Random.Range, GameObject.Instantiate,
    //GameObject.Destroy, Input.GetKeyDown, Transform.Translate
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        if (timer >= spawnTime && !Spawned)
        {
            spawnIt();
        }

        if(Spawned)
        {
            if (newLetter.transform.position.y < 0f)
            {
                doom();
            }
            if (Input.GetKeyDown(letter))
            {
                HandleInput();
            }
        }


	}


    void spawnIt()
    {
        spawnTime = Random.Range(0f, 2f);
        newLetter = GameObject.Instantiate(Letters);
        newLetter.transform.SetParent(gameObject.transform);
        newLetter.transform.position = transform.position;
        newLetter.transform.rotation = transform.rotation;
        Spawned = true;
    }

    void HandleInput()
    {
        if (newLetter.transform.position.y < 200f && newLetter.transform.position.y > 0f)
        {
            if (newLetter.transform.position.y >= 100f)
                precision = newLetter.transform.position.y - 100f;
            else
                precision = 100f - newLetter.transform.position.y;

            Debug.Log("Precision: " + precision);
            text.text = ("[" + letter + "]Precision: " + precision);
            doom();
        }
    }

    void doom()
    {
        GameObject.Destroy(newLetter);
        Spawned = false;
        timer = 0;
    }
}
