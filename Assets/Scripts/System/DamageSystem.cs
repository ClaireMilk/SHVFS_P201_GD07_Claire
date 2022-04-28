using System;
using HackMan.Scripts.Events;
using UnityEngine;

namespace HackMan.Scripts.Systems
{
    public class DamageSystem : Singleton<DamageSystem>
    {
        private void OnEnable()
        {
            Evently.Instance.Subscribe<DamageEvent>(OnDamaged);
        }

        private void OnDisable()
        {
            Evently.Instance.Unsubscribe<DamageEvent>(OnDamaged);
        }

        private void OnDamaged(DamageEvent damageEvent)
        {
            Evently.Instance.Publish(new GameOverEvent(false));
        }
    }
}