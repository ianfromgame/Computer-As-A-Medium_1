using System.Collections;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public int enemyHealth = 10;
    public TMP_Text deathMessage;

    private bool isDead = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sword") && !isDead)
        {
            enemyHealth -= 10;

            if (enemyHealth <= 0)
            {
                StartCoroutine(Death());
            }
        }
    }

    IEnumerator Death()
    {
        isDead = true;
        deathMessage.text = "I have been bested...";
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        deathMessage.text = "";
    }
}
