using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStep : IComparable<PlayerStep>
{
    public float  posX;
    public int    posZ;

    public PlayerStep(float PosX, int PosZ)
    {
        posX = PosX;
        posZ = PosZ;
    }
    public int CompareTo(PlayerStep other)
    {
        if (other == null)
        {
            return 1;
        }


        return 0;
    }

}
