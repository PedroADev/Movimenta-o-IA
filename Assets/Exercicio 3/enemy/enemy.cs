using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    public Transform target;

    void Update()
    {

        //inimigo olha até o alvo
        transform.LookAt(target);

        //move o inimigo até o alvo
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    //método de colisão
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("jogador"))
        {
            Destroy(gameObject);
        }
    }
}


