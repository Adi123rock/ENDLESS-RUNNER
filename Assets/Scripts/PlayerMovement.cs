using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerspeed = 2;
    public float horizontalSpeed = 3;
    public float limit = 5.5f;
    public bool isJumping = false;
    public bool comingDown = false;
    // bool sliding = false;
    Vector3 pos;
    [SerializeField] GameObject player;
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * playerspeed, Space.World);//Space.World makes it relative to the world
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > -limit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < limit)
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
            }
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            // player.GetComponent<Animator>().Play("Jump");
            if (!isJumping)
            {
                isJumping = true;
                player.GetComponent<Animator>().Play("Jump");
                StartCoroutine(JumpSequence());
            }
        }
        if (isJumping)
        {
            if (!comingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
            }
            else
            {
                transform.Translate(Vector3.up * Time.deltaTime * -3, Space.World);
            }
        }

        // if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        // {
        //     // transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
        //     pos = player.GetComponent<Transform>().position;
        //     pos.z += 6.37f;
        //     Debug.Log(pos);
        //     player.GetComponent<Animator>().Play("Running Slide");
        //     // sliding = true;
        //     // StartCoroutine(Slide());
        // }
        // if (sliding)
        // {
        //     // transform.Translate(player.GetComponent<Transform>().position);
        // }
    }
    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.54f);
        comingDown = true;
        yield return new WaitForSeconds(0.54f);
        isJumping = false;
        comingDown = false;
        pos=transform.position;
        Debug.Log(pos);
        pos.y = 1.5f;
        Debug.Log(pos);
        transform.Translate(pos);
        Debug.Log(transform.position);
        player.GetComponent<Animator>().Play("Running");
    }
    // IEnumerator Slide()
    // {
    //     yield return new WaitForSeconds(0.76f);
    //     transform.Translate(pos);
    //     sliding = false;
    // }
}
