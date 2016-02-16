using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    public float Speed;

	void Start () {
       // gameObject.AddComponent<Rigidbody2D>();
       // gameObject.GetComponent<Rigidbody2D>().gravityScale = 2;
	
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.Translate(new Vector2(0, 1) * Speed);
	}


    void OnMouseDown()
    {
        print(gameObject.name);
    }

}
