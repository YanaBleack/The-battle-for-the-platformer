using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonVamp : MonoBehaviour
{
    [SerializeField] private VampirismAbility _vampirism;

    public void OnButtonClickVamp()
    {
        _vampirism.StartVampirismAbility();
    }
}