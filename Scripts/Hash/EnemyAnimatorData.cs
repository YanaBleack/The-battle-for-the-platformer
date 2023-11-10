using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorData : MonoBehaviour
{
    public class Params
    {
        public static readonly int IsDead = Animator.StringToHash("IsDead");
        public static readonly int Attack = Animator.StringToHash("Attack");

    }
}
