using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeaBox
{
    class AnimalBase: MonoBehaviour
    {
        public virtual void FreeMove()
        {
            Console.WriteLine("AnimalBase FreeMove");
        }
    }

    class ToolsAnimal:AnimalBase
    {
        
    }

    class GoldAnimal:AnimalBase
    {
        public AnimalHealthStatus curHealthStatus = AnimalHealthStatus.None;
        public int curHungerValue;
    }
}