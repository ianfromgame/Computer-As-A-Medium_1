using UnityEngine;
using TMPro;

public class Task2 : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public TMP_Text trapMessage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerHealth.health -= 30;
            trapMessage.text = "You hit a trap! -30 Health";
            Destroy(gameObject);
        }

    }
}
