using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kajujam.Concrates.Combats
{
    public class Damage : MonoBehaviour
    {
        [SerializeField]public int damage;
  
        public int DamageOfHit => damage;

        public void HittingTarget(Health health)
        {
            health.TakingHit(this);
        }
    }
}
