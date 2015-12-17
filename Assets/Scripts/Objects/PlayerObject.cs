using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class PlayerObject : MonoBehaviour {

    Side side;
    private bool moving;
    private Vector3 moveToPosition;
    private bool shooting;
    private float shotEnd;
    private Vector3 shotStart;
    private Vector3 shotTarget;

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

    public void ShootAt(GameObject opponent)
    {
        /*shooting = true;
        shotEnd = Time.time + 0.5f;*/
        shotStart = transform.position;
        shotTarget = opponent.transform.position;

        GameObject go = new GameObject();
        LineRenderer lines = (LineRenderer)go.AddComponent<LineRenderer>();
        lines.material.color = (side == Side.Attack ? Color.red : Color.blue);
        lines.useWorldSpace = false;
        lines.SetWidth(0.1f, 0.1f);
        lines.SetVertexCount(2);
        lines.SetPosition(0, shotStart);
        lines.SetPosition(1, shotTarget);
        Destroy(go, 0.5f);
    }
}
