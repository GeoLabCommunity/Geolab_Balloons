using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloudController : MonoBehaviour {

    public List<GameObject> Clouds;
    public float AmplitudeX;
    public float AmplitudeY;
    public float CloudSpeed;
    float omega = 0;
	void Start () {
	
	}
	
	void Update () {
        omega += Time.deltaTime;

        Clouds[0].transform.position = new Vector2(Clouds[0].transform.position.x + AmplitudeX*Mathf.Sin(omega * CloudSpeed), Clouds[0].transform.position.y + AmplitudeY * Mathf.Cos(omega * CloudSpeed));
        Clouds[1].transform.position = new Vector2(Clouds[1].transform.position.x + AmplitudeX * Mathf.Cos(omega * CloudSpeed), Clouds[1].transform.position.y + AmplitudeY * Mathf.Sin(omega * CloudSpeed));
        Clouds[2].transform.position = new Vector2(Clouds[2].transform.position.x + AmplitudeX * Mathf.Cos(omega * CloudSpeed), Clouds[2].transform.position.y + AmplitudeY * Mathf.Sin(omega * CloudSpeed));
        Clouds[3].transform.position = new Vector2(Clouds[3].transform.position.x + AmplitudeX * Mathf.Sin(omega * CloudSpeed), Clouds[3].transform.position.y - AmplitudeY * Mathf.Cos(omega * CloudSpeed));

    }


}
