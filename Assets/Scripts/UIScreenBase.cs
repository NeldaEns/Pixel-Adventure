﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreenBase : MonoBehaviour
{
    public virtual void Hide()
    {
        Destroy(gameObject);
    }

    public virtual void OnShow()
    {
        
    }
}