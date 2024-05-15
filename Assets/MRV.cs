using UnityEngine;

public class MRV : MonoBehaviour
{
    public Transform[] puntosDeControl;
    public float velocidadInicial = 5f;
    public float aceleracion = 2f;

    private float velocidadActual;
    private int indicePuntoActual = 0;

    void Start()
    {
        velocidadActual = velocidadInicial;
        Distanciacalculo();
    }

    void Update()
    {
        
        if (puntosDeControl.Length == 0) return;

        Transform puntoDeControlObjetivo = puntosDeControl[indicePuntoActual];
        Vector3 direccion = (puntoDeControlObjetivo.position - transform.position).normalized;
        velocidadActual += aceleracion * Time.deltaTime;
        transform.position += direccion * velocidadActual * Time.deltaTime;

        if (Vector3.Distance(transform.position, puntoDeControlObjetivo.position) < 0.1f)
        {
            Distanciacalculo();
            indicePuntoActual++;
            if (indicePuntoActual >= puntosDeControl.Length)
            {
                indicePuntoActual = 0;
            }
        }
    }

    
    float CalcularTiempoParaDestino(Vector3 destino, float aceleracion)
    {
       
        float distanciaAlDestino = Vector3.Distance(transform.position, destino);

       
        float tiempoParaAlcanzarDestino = Mathf.Sqrt(2 * distanciaAlDestino / aceleracion);

        return tiempoParaAlcanzarDestino;
    }

    
   public void Distanciacalculo()
    {
        
        float tiempoParaPrimerPuntoDeControl = CalcularTiempoParaDestino(puntosDeControl[0].position, aceleracion);
        Debug.Log("Tiempo para alcanzar el primer punto de control: " + tiempoParaPrimerPuntoDeControl + " segundos");
    }
}
