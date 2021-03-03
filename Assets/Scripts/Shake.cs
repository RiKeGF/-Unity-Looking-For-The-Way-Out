using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour
{
    private float tremerIntensidade = 0.05f;
    private float tremerVelocidade = 0.005f;
    private float tremerFator;
    private Vector3 posicaoOriginal;
    private Quaternion rotacaoOriginal;

    void Update()
    {
        

        if (tremerFator > 0)
        {
            transform.position = posicaoOriginal + Random.insideUnitSphere * tremerFator;
            transform.rotation = new Quaternion(
            rotacaoOriginal.x + Random.Range(-tremerFator, tremerFator) * .2f,
            rotacaoOriginal.y + Random.Range(-tremerFator, tremerFator) * .2f,
            rotacaoOriginal.z + Random.Range(-tremerFator, tremerFator) * .2f,
            rotacaoOriginal.w + Random.Range(-tremerFator, tremerFator) * .2f);
            tremerFator -= tremerVelocidade;
        }
    }

    public void Tremer()
    {
        posicaoOriginal = transform.position;
        rotacaoOriginal = transform.rotation;
        tremerFator = tremerIntensidade;// .3f;
    }
}