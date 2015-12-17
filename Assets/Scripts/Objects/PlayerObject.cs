using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class PlayerObject : MonoBehaviour {

    Side side;
    private bool moving;
    private Vector3 moveToPosition;

    void Update()
    {
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveToPosition, Time.deltaTime*5f);
            if (transform.position == moveToPosition)
                moving = false;
        }
    }

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

    public void MoveTo(Vector3 newPosition)
    {
        moveToPosition = newPosition + new Vector3(0, 0.5f, 0);
        moving = true;
    }
}
