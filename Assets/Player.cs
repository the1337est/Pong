using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType
{
    PlayerOne,
    PlayerTwo
}

public class Player : MonoBehaviour
{

    public PlayerType Type;

    public float Speed;

	void Update ()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Type == PlayerType.PlayerTwo)
            {
                transform.position += Vector3.up * Time.deltaTime * Speed;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (Type == PlayerType.PlayerTwo)
            {
                transform.position += Vector3.down * Time.deltaTime * Speed;
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (Type == PlayerType.PlayerOne)
            {
                transform.position += Vector3.up * Time.deltaTime * Speed;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (Type == PlayerType.PlayerOne)
            {
                transform.position += Vector3.down * Time.deltaTime * Speed;
            }
        }

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.69f, 3.69f), 0f);

    }
}
