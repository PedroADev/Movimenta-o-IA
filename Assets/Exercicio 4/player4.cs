using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player4 : MonoBehaviour
{
    //array com os pontos
    public Transform[] points;

    //velocidade do cubo
    public float speed = 1.0f; 

    //ponto atual
    private int currentPoint = 0;

    //checa se esta em movimento
    private bool isMoving = true;

    private void Update()
    {
        if (isMoving)
        {
            //movimentação do objeto até o proximo ponto
            Vector3 direction = points[currentPoint].position - transform.position;

            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

            //muda a cor do ponto
            if (Vector3.Distance(transform.position, points[currentPoint].position) < 0.1f)
            {
                points[currentPoint].GetComponent<Renderer>().material.color = Color.green;
                currentPoint++;

                
                if (currentPoint >= points.Length)
                {
                    currentPoint = points.Length - 2;
                    isMoving = false;
                }
            }
        }
    }
}
