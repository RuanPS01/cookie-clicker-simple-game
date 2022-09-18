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

    public ControladorDeTela tela;
    public Animator cookieObjectAnimator;

    void Start()
    {
        
    }

    void Update()
    {
        tela.AtualizaPontuacaoCookie(pontuacaoCookie);
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
            if (cookieObjectAnimator.GetCurrentAnimatorStateInfo(0).IsName("Cookie_Anim"))
            {
                cookieObjectAnimator.SetBool("Apertando", true);
            }
        }
        if (cookieObjectAnimator.GetCurrentAnimatorStateInfo(0).IsName("CookieClick_Anim"))
        {
            cookieObjectAnimator.SetBool("Apertando", false);
        }
    }

    IEnumerator mostraPontuacaoCaixaEAtualizaRecorde() 
    {
        tela.AtualizaPontuacaoCaixa(pontuacaoCaixa);
        tela.MostraPainelPontuacaoCaixa();
        yield return new WaitForSeconds(2);
        tela.EscondePainelPontuacaoCaixa();
        if (pontuacaoCaixa > maiorPontuacaoCaixa)
        {
            maiorPontuacaoCaixa = pontuacaoCaixa;
            tela.AtualizaRecordeDeCaixa(maiorPontuacaoCaixa);
        }
    }
    
    void pontuaCaixa() 
    {
        int verificadorDeNovaCaixa = (int)(pontuacaoCookie / (10 * (pontuacaoCaixa+1)));
        if (verificadorDeNovaCaixa > 1)
        {
            pontuacaoCaixa = pontuacaoCaixa + 1;
            tempoParaNovaCaixa = tempoParaNovaCaixa + 1;
            StartCoroutine(mostraPontuacaoCaixaEAtualizaRecorde());
        }
    }

    IEnumerator diminuiPontuacaoCookie()
    {
        yield return new WaitForSeconds(1);
        pontuaCaixa();
        pontuacaoCookie = pontuacaoCookie - 0.1f * pontuacaoCookie;
        dominuindoPontosCookie = false;
    }

    IEnumerator apagaPontuacaoCaixa()
    {
        yield return new WaitForSeconds(tempoParaNovaCaixa*(pontuacaoCaixa + 1));
        pontuacaoCaixa = 0;
        zerandoPontosCaixa = false;
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
