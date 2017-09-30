using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ball : MonoBehaviour
{

    public float Speed;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        Fire();
	}

    void Fire()
    {
        Vector2 dir = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        dir = Vector2.ClampMagnitude(dir, Speed);
        rb.velocity = dir;
    }
	
}
