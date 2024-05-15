using UnityEngine;

public class MRU : MonoBehaviour
{
    public Transform[] puntosDeControl;
    public float velocidad = 5f;

    private int indicePuntoActual = 0;

    void Update()
    {
        if (indicePuntoActual < puntosDeControl.Length)
        {
            Transform puntoDeControlObjetivo = puntosDeControl[indicePuntoActual];
            float paso = velocidad * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, puntoDeControlObjetivo.position, paso);

           
            float distanciaAlObjetivo = Vector3.Distance(transform.position, puntoDeControlObjetivo.position);

          
            float tiempoEstimado = distanciaAlObjetivo / velocidad;

            

            if (transform.position == puntoDeControlObjetivo.position)
            {
                Debug.Log("Distancia al objetivo: " + distanciaAlObjetivo + " metros");
                Debug.Log("Tiempo estimado para llegar al objetivo: " + tiempoEstimado + " segundos");
                indicePuntoActual++;
                if (indicePuntoActual >= puntosDeControl.Length)
                {
                    indicePuntoActual = 0;
                }
            }
        }
    }
}
