using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balloon : MonoBehaviour {
    public Text score;
    public Text breath;
    public GameObject balloon;
    public int breaths = 5;

    Vector3 increase = new Vector3(.3f, .3f, .3f);
    Vector3 decrease = new Vector3(.015f, .015f, .015f);
    float timer = 0f;
    bool cooldown = false;
    bool gameover = false;



    //Debug.Log, Mathf.RoundToInt, Input.GetKeyDown,
    //GameObject.Destroy
    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (gameover)
        {
            breath.color = Color.red;
            breath.text = "GAMEOVER!!!!!";
        }
        else
        {
            score.text = ("Balloon life time: " + Mathf.RoundToInt(timer) + "s");
            if (cooldown)
            {
                breath.color = Color.blue;
                breath.text = "Breaths: Cooldown!!";

            }
            else
            {
                breath.color = Color.green;
                breath.text = "Breaths: " + breaths;

            }

            if (balloon.transform.localScale.y > 1.5)
            {
                GameOver();
            }
            if (Input.GetKeyDown(KeyCode.Space) && !cooldown)
            {
                HandleInflate();
            }
            else
            {
                HandleDeflate();
            }
        }

	}

    void GameOver()
    {
        GameObject.Destroy(balloon);
        Debug.Log("Balloon life time: " + Mathf.RoundToInt(timer) + "s");
        gameover = true;
    }

    IEnumerator TakeaBreath(float delay)
    {
        cooldown = true;
        yield return new WaitForSeconds(delay);
        cooldown = false;
    }

    void HandleInflate()
    {
        balloon.transform.localScale += increase;
        breaths -= 1;
        if (breaths <= 0)
            StartCoroutine(TakeaBreath(1f));
    }

    void HandleDeflate()
    {
        if (balloon.transform.localScale.y > 0.01f)
            balloon.transform.localScale -= decrease;
        else
            GameOver();
        if (breaths <= 5 && cooldown)
            breaths += (int)Time.deltaTime + 1;
    }
}
