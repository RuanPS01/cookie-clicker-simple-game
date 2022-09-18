using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoPrincipal : MonoBehaviour
{
    float pontuacaoCookie = 0; // diminuir cada vez mais rapido quando for aumentando a quantidade da pontuacao
    float pontuacaoCaixa = 0; // ganhar caixa de 10 em 10 pontos de cookies (se 10 ptsCookie = 1 caixa, e se 20 ptsCookie = 2 caixas)

    void Start()
    {
        
    }

    void Update()
    {
        if (ObjetoQueFoiTocado() == "Cookie_Imagem") 
        {
            Debug.Log("O Cookie foi tocado!");
        }
    }

    string ObjetoQueFoiTocado() {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            RaycastHit2D hit = Physics2D.Raycast(touch.position, Vector2.zero);
            if (hit)
            {
                return hit.transform.gameObject.name;
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector2.zero);
            if (hit)
            {
                return hit.transform.gameObject.name;
            }
        }
            return "";
    } 

}
