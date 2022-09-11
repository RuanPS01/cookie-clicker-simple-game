using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoPrincipal : MonoBehaviour
{
    float pontuacaoCookie = 0;
    int pontuacaoCaixa = 0;

    bool dominuindoPontosCookie = false;
    bool zerandoPontosCaixa = false;

    float tempoParaNovaCaixa = 1;
    int maiorPontuacaoCaixa = 0;

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

    IEnumerator mostraPontuacaoCaixaQuandoMaior() 
    {
        if (pontuacaoCaixa > maiorPontuacaoCaixa) 
        {
            maiorPontuacaoCaixa = pontuacaoCaixa;
            // Mostra pontuacao de caixas
            Debug.Log("------Mostra pontuacao de caixas------");
            yield return new WaitForSeconds(2);
            // Esconde pontuacao de caixas
            Debug.Log("|||||| Esconde pontuacao de caixas ||||||");
        }
    }

    void pontuaCaixa() 
    {
        int verificadorDeNovaCaixa = (int)(pontuacaoCookie / (10 * (pontuacaoCaixa+1)));
        if (verificadorDeNovaCaixa > 1)
        {
            pontuacaoCaixa = pontuacaoCaixa + 1;
            Debug.Log("pontuacaoCaixa --> " + pontuacaoCaixa);
            tempoParaNovaCaixa = tempoParaNovaCaixa + 1;
            StartCoroutine(mostraPontuacaoCaixaQuandoMaior());
        }
    }

    IEnumerator diminuiPontuacaoCookie()
    {
        yield return new WaitForSeconds(1);
        pontuaCaixa();
        pontuacaoCookie = pontuacaoCookie - 0.1f * pontuacaoCookie;
        Debug.Log("Pontuação do cookie diminuida: " + pontuacaoCookie);
        dominuindoPontosCookie = false;
    }

    IEnumerator apagaPontuacaoCaixa()
    {
        yield return new WaitForSeconds(tempoParaNovaCaixa*(pontuacaoCaixa + 1));
        pontuacaoCaixa = 0;
        Debug.Log("Pontuação da caixa zerada.");
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
