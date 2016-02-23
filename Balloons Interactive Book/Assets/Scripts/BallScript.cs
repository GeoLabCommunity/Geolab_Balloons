using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    public float Speed;

    // Tamashis gashvebisas pirveli eshveba punqcia Start (aseve arsebobs funcia Awake romelic Start amdeeshveba, sachiroebis shemtxvevashi iyeneben)
	void Start () {
       // gameObject.AddComponent<Rigidbody2D>();
       // gameObject.GetComponent<Rigidbody2D>().gravityScale = 2;

        int Jami = Random.Range(1, 11);

        int pirveli = Random.Range(0, Jami);
        int meore = Jami - pirveli;
        string magaliti = pirveli + "+" + meore;

        gameObject.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = magaliti;
	
	}
	
	//yovel Framze (kadrze) rac xdeba icereba update-Shi
	void Update () {
        // Translate - umatebs trasform.positions imdens ramdensac gadascemt parametrad 
        gameObject.transform.Translate(new Vector2(0, 1) * Speed);
	}

    // obieqtze mausit an tapit (telefonit) dajeris dapiqsireba - aucilebelia obieqtze idos raime tipis Collider i rom dapiqsirdes dachera
    void OnMouseDown()
    {
        print(gameObject.name);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
