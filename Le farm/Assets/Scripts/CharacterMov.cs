using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMov : MonoBehaviour
{
    public float speed = 5;
    private Vector3 direction;


    private void Update()
    {
        //player input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //vector of the direction
        direction = new Vector3(horizontal, vertical, 0);

    }
    private void FixedUpdate()
    {
        //player movement
        this.transform.position += direction * speed * Time.deltaTime;
    }
}
