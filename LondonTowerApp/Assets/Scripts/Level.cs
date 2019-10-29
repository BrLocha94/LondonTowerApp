using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    private Ring[] rings_tower_01;
    [SerializeField]
    private Ring[] rings_tower_02;
    [SerializeField]
    private Ring[] rings_tower_03;

    [SerializeField]
    private Ring[] initial_config_tower_01;
    [SerializeField]
    private Ring[] initial_config_tower_02;
    [SerializeField]
    private Ring[] initial_congif_tower_03;

    public Ring[] getRingsTower(int param)
    {
        if (param == 0)
            return rings_tower_01;
        else if (param == 1)
            return rings_tower_02;
        else
            return rings_tower_03;
    }

    public Ring[] getInitialConfigTower(int param)
    {
        if (param == 0)
            return initial_config_tower_01;
        else if (param == 1)
            return initial_config_tower_02;
        else
            return initial_congif_tower_03;
    }
}
