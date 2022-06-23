using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyComponent
{
    [Inject]
    public IStatsComponent Stats { get; set; }
}
