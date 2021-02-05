using System;
using System.Collections.Generic;
using System.Collections;
namespace SeaBox
{
    class GuppyFishController
    {
        private GuppyFish guppyFishObj;
        private Animator guppyFishAnimator;
        public GuppyFishAnimCtrl()
        {

        }
        public void initWithData(GuppyFish guppyFish,Animator Anim){
            guppyFishObj = guppyFish;
            guppyFishAnimator = Anim;
        }
        public void refreshFishStatus()
        {
            refreshGrowStatus();
        }
        
        //--------Begin Refresh Status----------//
        private void refreshHungerValue()
        {
            guppyFishObj.curHungerValue -=1;
            if(guppyFishObj.curHungerValue<=5){
                guppyFishObj.curHealthStatus = AnimalHealthStatus.Hunger;
            }
            else if(guppyFishObj.curHungerValue<=0){
                guppyFishObj.curHealthStatus = AnimalHealthStatus.Death;
            }
            else
            {
                guppyFishObj.curHealthStatus = AnimalHealthStatus.Normal;
            }
        }
        private void refreshGrowStatus()
        {
            if(guppyFishObj.GrowValue>=8){
                guppyFishObj.curGrowStatus = GuppyFishGrowStatus.DiamondFish;
                guppyFishAnimator.SetBool("Diamond", true);
            }
            else if(guppyFishObj.GrowValue>=6){
                guppyFishObj.curGrowStatus = GuppyFishGrowStatus.MaxFish;
                guppyFishAnimator.SetBool("Max", true);
            }
            else if(guppyFishObj.GrowValue>=4){
                guppyFishObj.curGrowStatus = GuppyFishGrowStatus.MidFish;
                guppyFishAnimator.SetBool("Mid", true);
            }
            else if(guppyFishObj.GrowValue>=2){
                guppyFishObj.curGrowStatus = GuppyFishGrowStatus.MiniFish;
                //guppyFishAnimator.SetBool("Mini", true);
            }
        }
        //--------End Refresh Status----------//

        //--------Begin Animator Controller----------//
        private void Eat()
        {
            if(guppyFishObj.curHealthStatus = AnimalHealthStatus.Hunger)
            {
                guppyFishAnimator.SetBool("Eat", true);
            }
        }

        private void Dead()
        {
            if(guppyFishObj.curHealthStatus = AnimalHealthStatus.Death)
            {
                guppyFishAnimator.SetBool("Dead", true);
            }
        }
        private void Idel()
        {
            if(guppyFishObj.curHealthStatus = AnimalHealthStatus.Normal)
            {
                guppyFishAnimator.SetBool("Swim", true);
            }
        }
        //--------End Animator Controller----------//

        //--------Begin Active Controller----------//

        public void FindFood()
        {

        }
        public void ToSeeGod()
        {

        }
        public void AvoidDanger()
        {

        }
        public void HappySwim()
        {
            Idel();
        }
        //--------End Active Controller----------//
    }
}