using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsComponent : IStatsComponent
{
    #region Interface Properties
    public float HP { get; set; }
    public float Speed { get; set; }
    public float Strength { get; set; }
    #endregion
}
