using UnityEngine;

public class player1 : MonoBehaviour
{
    //ponto inicial
    public Transform start;

    //ponto final
    public Transform final;

    //velocidade de movimento do objeto
    public float speed = 1f;

    //momento em que o movimento começa
    private float startTime;

  
    private float distance;   

    //calcula a distancia entre os dois pontos
    void Start()
    {
  
        startTime = Time.time;

 
        distance = Vector3.Distance(start.position, final.position);
    }

    void Update()
    {
        //move o cubo de um ponto a outro

        float distanceCovered = (Time.time - startTime) * speed;


        float fractionOfJourney = distanceCovered / distance;


        transform.position = Vector3.Lerp(start.position, final.position, fractionOfJourney);
    }
}
