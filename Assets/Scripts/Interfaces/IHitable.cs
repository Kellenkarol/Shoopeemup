using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

namespace Interfaces
{
    public interface IHitable
    {
        void DeliverDamage(float damageValue);
        void DeliverBonus(ColectableType colectableType, float value);
    }
}