using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoPrincipal : MonoBehaviour
{
    float pontuacaoCookie = 0;
    float pontuacaoCaixa = 0;

    bool dominuindoPontosCookie = false;
    bool zerandoPontosCaixa = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (pontuacaoCookie > 0 && !dominuindoPontosCookie) {
            dominuindoPontosCookie = true;
            StartCoroutine(diminuiPontuacaoCookie());
        }
        if (pontuacaoCaixa > 0 && !zerandoPontosCaixa)
        {
            zerandoPontosCaixa = true;
            StartCoroutine(apagaPontuacaoCaixa());
        }

        if (ObjetoQueFoiTocado() == "Cookie_Imagem") 
        {
            pontuacaoCookie = pontuacaoCookie + 1;
        }
    }

    IEnumerator diminuiPontuacaoCookie()
    {
        yield return new WaitForSeconds(1);
        pontuacaoCookie = pontuacaoCookie - 0.01f;
        Debug.Log("Pontuação do cookie diminuida: " + pontuacaoCookie);
        dominuindoPontosCookie = false;
    }

    IEnumerator apagaPontuacaoCaixa()
    {
        yield return new WaitForSeconds(5);
        pontuacaoCaixa = 0;
        Debug.Log("Pontuação da caixa zerada" + pontuacaoCookie);
        zerandoPontosCaixa = false;
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
