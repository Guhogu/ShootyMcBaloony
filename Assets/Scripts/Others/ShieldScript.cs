using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {

    [SerializeField]
    EnergyCore energyCore;

    [SerializeField]
    Animator anim;

    float cooldown = 1;

    int timeHit = 0;

    // Use this for initialization

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (timeHit + cooldown < Time.time && collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Player_Script>().diving)
        {
            energyCore.durability -= 1;
            if (energyCore.durability <= 0)
            {
                energyCore.EnablePortal();
                anim.SetTrigger("Destroyed");
                GameController.destroyedShield[energyCore.scrollingIndex] = true;
            }
            else
                anim.SetTrigger("Hit");

        }

    }
}
