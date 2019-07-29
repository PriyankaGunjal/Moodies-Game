using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game2
{
    class CollisionManager
    {
        private PlayerManager player;
        private TargetsManager targets;
        private static CollisionManager _collide;
        public int RowNumber, ColumnNumber;
        private CollisionManager()
        {
            player =PlayerManager.CreatePlayerManager();
            targets=TargetsManager.CreateTargets();

        }

        public static CollisionManager GetCollisionManager()
        {
            if(_collide==null)
                _collide=new CollisionManager();
            return _collide;
        }

        public void Reset()
        {
            RowNumber = -1;
            ColumnNumber = -1;
        }
        public void HandleCollision()
        {

            //int listNumber = 0, moodieNumber = 0, flag = 0;
            //for (listNumber = 0; listNumber < targets.MoodieList.Count; listNumber++)
            //{
            //    flag = 0;
            //    for (moodieNumber = 0; moodieNumber < targets.MoodieList[listNumber].Count; moodieNumber++)
            //    {
            //        if (listNumber == targets.MoodieList.Count - 1 || listNumber != targets.MoodieList.Count - 1 &&
            //            targets.MoodieList[listNumber + 1][moodieNumber].getShowFlag() == false)
            //        {
            //            if (targets.MoodieList[listNumber][moodieNumber].GetYCoordinate() >= player.GetPlayerY() - 36 &&
            //                Enumerable.Range(player.GetPlayerX() - 50, player.GetPlayerX() + 50).Contains(targets.MoodieList[listNumber][moodieNumber].GetXCoordinate()) &&
            //                targets.MoodieList[listNumber][moodieNumber].getShowFlag() == true)
            //            {

            //                if (targets.MoodieList[listNumber][moodieNumber].GetType() == player.GetType())
            //                {
            //                    rowNumber = listNumber;
            //                    columnNumber = moodieNumber;
            //                    EventBroadcaster.GetBroadcaster().ChangeEvent(new PlayerCollideState(), false);
            //                    flag = 1;
            //                    break;

            //                }
            //                else
            //                {
            //                    EventBroadcaster.GetBroadcaster().ChangeEvent(new PlayerOnStickState(), false);
            //                }
            //            }

            //        }
            //    }
            //    if (flag == 1)
            //        break;
            //}



            int listnumber = targets.MoodieList.Count - 1;
            while (listnumber >= 0)
            {
                int moodieNumber = player.GetPlayerX() / 50;

                if (targets.MoodieList[listnumber][moodieNumber].getShowFlag() == true &&
                    targets.MoodieList[listnumber][moodieNumber].GetType() == player.GetType())
                {


                    RowNumber = listnumber;
                    ColumnNumber = moodieNumber;
                    EventBroadcaster.GetBroadcaster().ChangeEvent(new PlayerCollideState(), false);
                    break;
                }
                else if (targets.MoodieList[listnumber][moodieNumber].getShowFlag() == false)
                {
                    listnumber--;
                }
                else if (targets.MoodieList[listnumber][moodieNumber].getShowFlag() == true &&
                         targets.MoodieList[listnumber][moodieNumber].GetType() != player.GetType())
                {
                    EventBroadcaster.GetBroadcaster().ChangeEvent(new PlayerOnStickState(), false);
                    break;
                }

            }
            EventBroadcaster.GetBroadcaster().ChangeEvent(new PlayerOnStickState(), false);

        }

        public void AddTargets()
        {
            bool check = true;

            for (int i = 0; i < targets.MoodieList[0].Count; i++)
            {
                if (targets.MoodieList[targets.MoodieList.Count - 1][i].getShowFlag() == true)
                    check = false;

            }

            if (check)
            {
                targets.MoodieList.RemoveAt(targets.MoodieList.Count - 1);
                targets.AddTargetList();
               
            }
        }

        public void CheckHangingMoodie()
        {

            int listNumber = 0, moodieNumber = 0, flag = 0;
            for (listNumber = 0; listNumber < targets.MoodieList.Count; listNumber++)
            {
                for (moodieNumber = 0; moodieNumber < targets.MoodieList[listNumber].Count; moodieNumber++)
                {
                    if ( listNumber>0 && moodieNumber>0&& moodieNumber >targets.MoodieList[0].Count-1 &&
                        targets.MoodieList[listNumber][moodieNumber + 1].getShowFlag() == false &&
                        targets.MoodieList[listNumber][moodieNumber + 1].getShowFlag() == false &&
                        targets.MoodieList[listNumber-1][moodieNumber].getShowFlag() == false)
                    {
                        HangingMoodie.CreatehHangingMoodie().AddHangingMoodie(targets.MoodieList[listNumber][moodieNumber]);
                        targets.MoodieList[listNumber][moodieNumber].DisableShowFlag();
                        ScoreManager.GetScoreManager().Update();
                    }
                }

            }
        }
    }
}
