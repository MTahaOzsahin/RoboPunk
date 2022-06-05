using Kajujam.Concrates.Combats;
using Kajujam.Concrates.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kajujam.Concrates.ExtensionMethods
{
    public static class ColliderExtensionMethod
    {
        
        public static bool HasHitPlayer(this Collision collision)
        {
            return collision.collider.GetComponent<PlayerFpsController>() != null;
        }
        public static bool HasHitEnemy(this Collision collision)
        {
            return collision.collider.GetComponent<EnemyController>() != null;
        }
        public static bool HasHitBullet(this Collision collision)
        {
            return collision.collider.GetComponent<Bullet>();
        }
        public static Health ObjectHasHealth(this Collision collision)
        {
            Health health = collision.collider.GetComponent<Health>();
            if (health != null)
            {
                return health;
            }
            return null;
        }
    }
}
