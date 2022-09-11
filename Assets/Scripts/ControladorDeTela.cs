using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControladorDeTela : MonoBehaviour
{
    public TMP_Text textoPontuacaoCookie;
    public TMP_Text textoPontuacaoCaixa;
    public TMP_Text textoRecordeCaixa;
    public GameObject painelPontuacaoCookie;


    public void AtualizaPontuacaoCookie(float pontuacao) 
    {
        textoPontuacaoCookie.text = ((int)pontuacao).ToString();
    }

    public void AtualizaPontuacaoCaixa(int pontuacao)
    {
        textoPontuacaoCaixa.text = pontuacao.ToString() + " caixa(s)";
    }

    public void MostraPainelPontuacaoCaixa()
    {
        painelPontuacaoCookie.SetActive(true);
        GameObject GrupoDeCaixas = painelPontuacaoCookie.transform.GetChild(0).gameObject;
    }

    public void EscondePainelPontuacaoCaixa()
    {
        painelPontuacaoCookie.SetActive(false);
    }

    public void AtualizaRecordeDeCaixa(int pontuacao)
    {
        textoRecordeCaixa.text = "recorde: " + pontuacao.ToString() + " CAIXA(S)";
    }
}
