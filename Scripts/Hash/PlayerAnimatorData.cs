using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorData : MonoBehaviour
{
    public class  Params
    {           
        public static readonly int IsJumping = Animator.StringToHash("Jumping");
        public static readonly int Melee = Animator.StringToHash("Melee");
        public static readonly int Shoot = Animator.StringToHash("Shoot");
        public static readonly int IsDead = Animator.StringToHash("IsDead");
        public static readonly int Attack = Animator.StringToHash("Attack");
    }
}
