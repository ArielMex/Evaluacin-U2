using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoRojo : MonoBehaviour
{
    public float velocidad = 8f; 
    private Rigidbody2D rb;
    private Vector2 movimiento;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMoveRojo(InputValue value)
    {
        Vector2 inputBruto = value.Get<Vector2>();

        if (Mathf.Abs(inputBruto.x) > 0)
        {
            movimiento = new Vector2(inputBruto.x, 0); 
        }
        else
        {
            movimiento = new Vector2(0, inputBruto.y); 
        }

        if (movimiento != Vector2.zero)
        {
            float angulo = Mathf.Atan2(movimiento.y, movimiento.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angulo + 180f);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movimiento * velocidad;
    }
}