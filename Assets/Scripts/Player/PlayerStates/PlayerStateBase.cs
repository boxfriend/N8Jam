using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateBase : PlayerState
{

    public PlayerStateBase (Rigidbody2D _body) : base(_body)
    {

    }

    public override IEnumerator Start()
    {
        yield break;
    }
}
