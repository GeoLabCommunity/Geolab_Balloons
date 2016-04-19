using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = "ყველა სიცოცხლე ამოგეწურა, სცადე კიდევ ერთხელ! \n შენ დააგროვე: " + GlobalParams.Score + "ქულა";

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
