using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeaBox
{
    class AnimalBase: MonoBehaviour
    {

    }

    class ToolsAnimal:AnimalBase
    {
        
    }

    class GoldAnimal:AnimalBase
    {
        public AnimalHealthStatus curHealthStatus = AnimalHealthStatus.None;
        public int curHungerValue;

        public virtual void FreeMove()
        {
            Console.WriteLine("GoldAnimal FreeMove");
        }
    }
}