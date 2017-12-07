
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
        float i = Random.Range(0f, 1f) > 0.5 ? 1f : -1f;
        Vector2 dir = new Vector3(Random.Range(4f * i, 10f * i), Random.Range(-6f, 6f));
        dir = Vector2.ClampMagnitude(dir, Speed);
        rb.velocity = dir;
    }

    public void Restart()
    {
        if (!GameManager.Instance.Over)
        {
            transform.position = Vector3.zero;
            Fire();
        }
    }

    private void Update()
    {
        if (!GameManager.Instance.Over)
        {
            if (transform.position.x < -6f)
            {
                GameManager.Instance.Score2 = GameManager.Instance.Score2 + 1;
            }
            if (transform.position.x > 6f)
            {
                GameManager.Instance.Score1 = GameManager.Instance.Score1 + 1;
            }
        }
    }

}
