using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float speed;
    public Text vidasText;

    //variavel de vidas
    private int vidas;

    void Start()
    {
        //3 vidas inicias
        vidas = 3;
        SetvidasText();
    }

    void Update()
    {

        //movimenta��o com o bot�o esquerdo do mouse
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);

                //lookAt faz o objeto rotaciona para encarar a dire��o do clique
                transform.LookAt(targetPosition);

                //move o cubo at� a dire��o do clique utilizando vector3
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
        }
    }

    //verifica a colis�o com objetos com a tag inimigo
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("inimigo"))
        {
            vidas--;
            SetvidasText();
            if (vidas == 0)
            {
                Debug.Log("Game Over!");
            }
        }
    }

    void SetvidasText()
    {
        vidasText.text = "vidas: " + vidas.ToString();
    }
}
