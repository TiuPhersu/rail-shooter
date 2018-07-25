using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {
    int score;
    Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();//get the text from the UI
        scoreText.text = score.ToString();//store text and show to the UI
	}

    public void ScoreHit(int scoreIncrease){//access from all other classes
        score = score + scoreIncrease;//count by scoreby hit
        scoreText.text = score.ToString();//update
    }
}

