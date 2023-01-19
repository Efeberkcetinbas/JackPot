using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Obstacleable
{
    public Wall()
    {
        interactionTag="Knife";
    }

    internal override void DoAction(Player player)
    {
        player.GetComponent<KnifeMove>().speed=0;
        player.GetComponent<KnifeMove>().canDamage=false;
    }
}
