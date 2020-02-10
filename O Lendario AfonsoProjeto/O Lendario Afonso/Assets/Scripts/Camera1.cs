using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script responsável pela movimentação e limitação da posição da Camera

public class Camera1 : MonoBehaviour
{
    //Declaração de variáveis e definição de alguns valores iniciais;
    public Transform target;
    public Vector3 offset;
    Vector3 velocity = Vector3.zero;
    public float smoothTime = .15f;

    public bool YMaxEnable;
    public float YMax;
    public bool YMinEnable;
    public float YMin;
    public bool XMaxEnable;
    public float XMax;
    public bool XMinEnable;
    public float XMin;

    void Start()
    {

    }

    // Update (chamado 1 vez por frame)
    void LateUpdate()
    {
        //POSIÇÃO DA CAMERA SEGUE A POSIÇÃO DO PERSONAGEM
        Vector3 targetPos = target.position; 

        //LIMITAÇÃO VERTICAL DA CAMERA
        if (YMinEnable && YMaxEnable)
        {
            targetPos.y = Mathf.Clamp(target.position.y, YMin, YMax);
        }
        else if (YMinEnable)
        {
            targetPos.y = Mathf.Clamp(target.position.y, YMin, target.position.y);
        }
        else if (YMaxEnable)
        {
            targetPos.y = Mathf.Clamp(target.position.y, target.position.y, YMax);
        }

        //LIMITAÇÃO HORIZONTAL DA CAMERA
        if (XMinEnable && XMaxEnable)
        {
            targetPos.x = Mathf.Clamp(target.position.x, XMin, XMax);
        }
        else if (XMinEnable)
        {
            targetPos.x = Mathf.Clamp(target.position.x, XMin, target.position.x);
        }
        else if (XMaxEnable)
        {
            targetPos.x = Mathf.Clamp(target.position.x, target.position.x, XMax);
        }
        
        //AJUSTE DA DISTANCIA DA CAMERA
        targetPos.z = -10;

        //SUAVIZAÇÃO/DELAY DO MOVIMENTO DA CAMERA 
        this.transform.position = Vector3.SmoothDamp(transform.position, targetPos + offset, ref velocity, smoothTime);
    }
}
