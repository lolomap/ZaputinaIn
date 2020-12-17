using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public static class Constants
    {
        public const string UPGRADE_BUY_BUTTON_TEXT = "Купить";

        public const int START_COST = 10, FST_EMP_COST = 25, MORE_EMP_COST = 100, MOBIL_COST = 1000;
        public const int GARAGE_COST = 50;

        public const int UP_BUTTON_SIZE = 100;
        //public const int UPS_COUNT = 4;

        public static readonly Dictionary<string, List<string>> UP_CONNECTIONS = new Dictionary<string, List<string>>
        {
            {"start_up", new List<string>() {"fst_emp_up", "garage_up"} },
            {"fst_emp_up", new List<string>() {"more_emp_up"} },
            {"more_emp_up", new List<string>() {"mobil_up"} }
        };
    }
}