using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    public Transform target;

    void Update()
    {

        //inimigo olha at� o alvo
        transform.LookAt(target);

        //move o inimigo at� o alvo
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    //m�todo de colis�o
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("jogador"))
        {
            Destroy(gameObject);
        }
    }
}


