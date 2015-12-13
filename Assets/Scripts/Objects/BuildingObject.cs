using UnityEngine;
using System.Collections;

public class BuildingObject : MonoBehaviour {

    public GameObject building;
    public GameObject[] sides;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetSize(float height, Vector2 size)
    {
        building.transform.localScale = new Vector3(size.x, height, size.y);
        transform.position = new Vector3(transform.position.x, height / 2f, transform.position.z);

        foreach (GameObject s in sides)
        {
            float newX = 0;
            float newZ = 0;
            if (Mathf.Abs(s.transform.localPosition.x) > 0)
                newX = s.transform.localPosition.x + 0.5f * (size.x - 2) * (s.transform.localPosition.x > 0 ? 1 : -1);
            if (Mathf.Abs(s.transform.localPosition.z) > 0)
                newZ = s.transform.localPosition.z + 0.5f * (size.y - 2) * (s.transform.localPosition.z > 0 ? 1 : -1);

            s.transform.localPosition = new Vector3(newX, height / 2f + s.transform.localScale.y/2f, newZ);
            s.transform.localScale = new Vector3(s.transform.localScale.x, s.transform.localScale.y, (Mathf.Abs(s.transform.localPosition.z) > 0 ? size.x : size.y));
        }
    }
}
