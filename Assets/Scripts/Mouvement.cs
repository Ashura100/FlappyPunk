using UnityEngine;

public class Mouvement : MonoBehaviour
{
    [Header("Bird Settings")]
    public float flapForce = 5f; // La force du saut
    public float gravity = -9.8f; // La force gravitationnelle personnalisée
    public float maxFallSpeed = -10f; // Vitesse maximale de chute

    [Header("Rotation Settings")]
    public float tiltSmooth = 5f; // Vitesse de rotation de l'oiseau
    public float tiltAngle = 45f; // Angle de rotation lors du saut

    [SerializeField] private Rigidbody rb;
    private Quaternion upRotation;
    private Quaternion downRotation;
    private Vector3 velocity;

    void Start()
    {
        upRotation = Quaternion.Euler(tiltAngle, 0, 0);
        downRotation = Quaternion.Euler(-tiltAngle, 0, 0);

        // Vérifier si le Rigidbody est attribué
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        // Détecte le saut
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Flap();
        }

        // Rotation de l'objet en fonction de la direction verticale
        float currentVerticalSpeed = velocity.y;
        transform.rotation = Quaternion.Lerp(transform.rotation,
            currentVerticalSpeed > 0 ? upRotation : downRotation,
            tiltSmooth * Time.deltaTime);
    }

    void FixedUpdate()
    {
        // Appliquer la gravité personnalisée
        if (velocity.y > maxFallSpeed)
        {
            rb.AddForce(new Vector3(0, gravity * rb.mass, 0), ForceMode.Force);
        }
    }

    void Flap()
    {
        // Appliquer une impulsion au Rigidbody
        rb.AddForce(Vector3.up * flapForce * rb.mass, ForceMode.Impulse);
    }
}