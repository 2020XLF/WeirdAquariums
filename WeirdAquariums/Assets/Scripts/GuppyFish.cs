using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SeaBox
{
    class GuppyFish:GoldAnimal
    {
        
        public float refreshTime;
        public int GrowValue;
        private GuppyFishGrowStatus curGrowStatus = GuppyFishGrowStatus.MiniFish;
        private Animator myAnim;
        private GuppyFishController controllerFish;
        // Start is called before the first frame update
        void Start()
        {
            //Init Status
            curHealthStatus = AnimalHealthStatus.Normal;
            curGrowStatus = GuppyFishGrowStatus.MiniFish;

            myAnim = GetComponent<Animator>();

            //new Animation Controller
            controllerFish = new GuppyFishController();
            controllerFish.initWithData(this,myAnim);


            //Begin Timer
            StartCoroutine(CoroutineTimer());
        }

        // Update is called once per frame
        void Update()
        {
            controllerFish.refreshFishStatus();
            SwitchActiveWay();
        }

        void SwitchActiveWay()
        {
            if(this.curHealthStatus = AnimalHealthStatus.Hunger)
            {
                controllerFish.FindFood();
            }
            else if(this.curHealthStatus == AnimalHealthStatus.Death)
            {
                controllerFish.ToSeeGod();
            }
            else if(this.curHealthStatus == AnimalHealthStatus.Dangerous)
            {
                controllerFish.AvoidDanger();
            }
            else
            {
                controllerFish.HappySwim();
            }
        }
        private void CoroutineTimer() 
        {
            while(true)
            {
                yield return new WaitForSeconds(refreshTime);
                controllerFish.refreshHungerValue();
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Food") && this.curHealthStatus == AnimalHealthStatus.Hunger)
            {
                this.curHealthStatus = AnimalHealthStatus.Normal;
                this.curHungerValue +=7;
                this.GrowValue +=1;
            }
        }
    }
}