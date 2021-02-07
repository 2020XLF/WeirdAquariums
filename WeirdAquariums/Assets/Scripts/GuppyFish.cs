using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SeaBox
{
    class GuppyFish:GoldAnimal
    {
        
        public float refreshTime;
        public int GrowValue;
        public Transform movePos;
        private GuppyFishGrowStatus curGrowStatus = GuppyFishGrowStatus.MiniFish;
        private Animator myAnim;
        private GuppyFishController controllerFish;
        // Start is called before the first frame update
        void Start()
        {
            //Init Status
            curHealthStatus = AnimalHealthStatus.Normal;
            curGrowStatus = GuppyFishGrowStatus.MiniFish;
            movePos.position = GameStaticUtil.Instance.GetRandomPos();

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
            FreeMove();
        }

        void SwitchActiveWay()
        {
            if(this.curHealthStatus = AnimalHealthStatus.Hunger)
            {
                controllerFish.AnimFindFood();
            }
            else if(this.curHealthStatus == AnimalHealthStatus.Death)
            {
                controllerFish.AnimToSeeGod();
            }
            else if(this.curHealthStatus == AnimalHealthStatus.Dangerous)
            {
                controllerFish.AnimAvoidDanger();
            }
            else
            {
                FreeMove();
                controllerFish.AnimHappySwim();
            }
        }
        public override void FreeMove()
        {
            
            if(Vector2.Distance(transform.position, movePos.position) < 0.1f)
            {
                if(waitTime <= 0)
                {
                    movePos.position = GameStaticUtil.Instance.GetRandomPos();
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);
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