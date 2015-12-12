using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Battle b = new Battle(JSONReader.ConvertJSON("ExampleJSON"));
        Debug.Log(b.attackers.ToString());
	}
	
}