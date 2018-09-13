using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This line enables use of uGUI features.

public class Basket : MonoBehaviour {
    [Header("Set Dynamically")]
    public Text scoreGT;

	// Use this for initialization
	void Start () {
        // Find a reference to the ScoreCounter GameObject
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Get the Text Component of that GameObject
        scoreGT = scoreGO.GetComponent<Text>();
        // Set the starting number of points to 0
        scoreGT.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
        // Get the currect screen position of the mouse from Input
        Vector3 mousePos2d = Input.mousePosition;

        // The Camera's z position sets how far to push the mouse into 3d
        mousePos2d.z = -Camera.main.transform.position.z;

        // Convert the point from 2D screen space into 3d game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2d);

        // Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
	}

    private void OnCollisionEnter(Collision coll)
    {
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            // Parse the text of the scoreGT into an int
            int score = int.Parse(scoreGT.text);
            //add points for catching the apple
            score += 100;
            // Convert the score back to a string and display it
            scoreGT.text = score.ToString();

            // Track the high score
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
