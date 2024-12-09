using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mouvement : MonoBehaviour
{
    private Rigidbody rb;
    private bool cooldown;

    private GameObject lookAt;
    public GameObject Cube1;
    public GameObject Cube2;
    private int speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Gravité personnalisée.
        Vector3 currentVelocity = rb.linearVelocity;
        currentVelocity.y += -15f * Time.deltaTime; // Appliquer la gravité.
        rb.linearVelocity = currentVelocity;

        // Détection de l'appui sur la touche "espace".
        if (Input.GetKeyDown(KeyCode.Space) && !cooldown)
        {
            cooldown = true;
            Vector3 jumpVelocity = rb.linearVelocity;
            jumpVelocity.y = Mathf.Sqrt(2f * 15f * 4f); // Calculer l'impulsion de saut.
            rb.linearVelocity = jumpVelocity; // Appliquer l'impulsion de saut.
            StartCoroutine(CooldownRefresh());
        }

        // Changement du point de regard en fonction de la direction verticale.
        if (rb.linearVelocity.y > 0)
        {
            lookAt = Cube1;
            speed = 5;
        }
        else
        {
            lookAt = Cube2;
            speed = 10;
        }

        // Rotation fluide vers le point de regard.
        Quaternion lookRotation = Quaternion.LookRotation(lookAt.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, speed * Time.deltaTime);
    }

    private IEnumerator CooldownRefresh()
    {
        yield return new WaitForSeconds(0.3f);
        cooldown = false;
    }
}