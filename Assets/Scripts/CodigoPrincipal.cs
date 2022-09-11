using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoPrincipal : MonoBehaviour
{
    float pontuacaoCookie = 0;
    float pontuacaoCaixa = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (pontuacaoCookie > 0) {
            StartCoroutine(diminuiPontuacaoCookie());
        }
        if (pontuacaoCaixa > 0)
        {
            StartCoroutine(apagaPontuacaoCaixa());
        }

        if (ObjetoQueFoiTocado() == "Cookie_Imagem") 
        {
            Debug.Log("O Cookie foi tocado!");
        }
    }

    IEnumerator diminuiPontuacaoCookie()
    {
        while (pontuacaoCookie >= 0) {
            yield return new WaitForSeconds(1);
            pontuacaoCookie = pontuacaoCookie - 0.001f;
        }
    }

    IEnumerator apagaPontuacaoCaixa()
    {
        while (pontuacaoCaixa > 0)
        {
            yield return new WaitForSeconds(5);
            pontuacaoCaixa = 0;
        }
    }

    string ObjetoQueFoiTocado() {
        if (Input.touchCount > 0)
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
