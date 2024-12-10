using System.Collections;
using TMPro;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    private Rigidbody rb;
    private bool cooldown;

    public float jumpForce = 10;

    private int speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        // Détection de l'appui sur la touche "espace".
        if (Input.GetKeyDown(KeyCode.Space) && !cooldown)
        {
            cooldown = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            StartCoroutine(CooldownRefresh());
        }
    }

    private IEnumerator CooldownRefresh()
    {
        yield return new WaitForSeconds(0.3f);
        cooldown = false;
    }
}