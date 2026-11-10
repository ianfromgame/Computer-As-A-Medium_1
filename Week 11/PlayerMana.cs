using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerMana : MonoBehaviour
{
    public int mana = 100;
    public TMP_Text manaText;
    public Animator manaAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manaText.text = "Mana: " + mana;
    }

    // Update is called once per frame
    void Update()
    {
        manaText.text = "Mana: " + mana;

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            if (mana >= 10)
            {
                mana -= 10;
                manaAnimator.SetTrigger("Special");
            }
        }
    }
    
        
    
}
