using UnityEngine;

public class player2 : MonoBehaviour
{
    //ponto inicial
    public Transform[] start;

    //ponto final
    public Transform final;

    //velocidade
    public float speed = 1f;

    //momento em que o movimento come�a
    private float startTime;

    //distancia
    private float distance;

    //array para verificar se cada objeto alcan�ou o ponto final
    private bool[] hasReachedTarget;    

    void Start()
    {
        //inicializa o array para cada objeto
        hasReachedTarget = new bool[start.Length];

        for (int i = 0; i < start.Length; i++)
        {
            //grava o momento inicial do movimento.
            startTime = Time.time;

            //comprimento total
            distance = Vector3.Distance(start[i].position, final.position);

            //marca que o objeto ainda n�o alcan�ou o ponto final
            hasReachedTarget[i] = false;
        }
    }

    void Update()
    {
        //move objetos do ponto inicial at� o ponto final
        for (int i = 0; i < start.Length; i++)
        {
            //verifica se o objeto alcan�ou o ponto final
            if (!hasReachedTarget[i])
            {
                //calcula a dist�ncia percorrida pelo objeto
                float distanceCovered = (Time.time - startTime) * speed;
                float fractionOfJourney = distanceCovered / distance;

                //move o objeto
                start[i].position = Vector3.Lerp(start[i].position, final.position, fractionOfJourney);

                //verifica se o objeto alcan�ou o ponto final
                if (fractionOfJourney >= 1.0f)
                {
                    //marca que o objeto alcan�ou o ponto final
                    hasReachedTarget[i] = true;
                }
            }
        }
    }
}
