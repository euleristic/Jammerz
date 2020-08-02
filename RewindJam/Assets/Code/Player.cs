using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        var moveX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var posX = transform.position.x + moveX;
        var moveY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        var posY = transform.position.y + moveY;
        transform.position = new Vector2(posX, posY); 
    }
}
