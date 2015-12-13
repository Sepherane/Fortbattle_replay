using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class PlayerObject : MonoBehaviour {

    Side side;

    public void SetSide(Side s)
    {
        this.side = s;
        if (s == Side.Attack)
        {
            Material m = GetComponent<MeshRenderer>().material;
            m.color = Color.red;
            GetComponent<MeshRenderer>().material = m;
        }
        else
        {
            Material m = GetComponent<MeshRenderer>().material;
            m.color = Color.blue;
            GetComponent<MeshRenderer>().material = m;
        }
    }
}
