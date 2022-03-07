using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public Vector3 centerPt;
    public float radius;
    private Vector3 position;
    private bool isMoving = false;

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            TriggerPosition();
        }

        if(isMoving)
        {
            ItsMove();
        }
    }

    void TriggerPosition()
    {
        position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = transform.position.z;

        isMoving = true;
    }

    void ItsMove()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, position);
        transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);

        if(transform.position == position)
        {
            isMoving = false;
        }

	Vector3 newPos = transform.position;
	Vector3 offset = newPos - centerPt;
	transform.position = centerPt + Vector3.ClampMagnitude(offset, radius);
    }

}
