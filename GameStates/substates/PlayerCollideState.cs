using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game2
{
    class PlayerCollideState:IStates
    {

         public PlayerCollideState()
        {
           PerformCollisionAction();
        }
        public void Update()
        {
       
            CollisionManager.GetCollisionManager().AddTargets();
            EventBroadcaster.GetBroadcaster().ChangeEvent(new PlayerOnStickState(), false);
        }

       public  void Render()
       {
          
            GameAppFramework.GetGameAppFramework().RenderWholeWorld();
        }
      
        public void OnNotify(Event ievent)
        {
           if (((KeyPressedEvent)ievent).key == Keys.key.Escape)
            {
                EventBroadcaster.GetBroadcaster().ChangeEvent(null, false);
            }
        }

        private void PerformCollisionAction()
        {
            var targets =TargetsManager.CreateTargets();
            PlayerManager player =PlayerManager.CreatePlayerManager();
            int row = CollisionManager.GetCollisionManager().RowNumber;
            int column = CollisionManager.GetCollisionManager().ColumnNumber;
            Destroy(row,column,targets,player);
        }


        void Destroy(int row,int column,TargetsManager targets,PlayerManager player)
        {
            if (row>=0 && column>=0 && column<targets.MoodieList[0].Count && 
                targets.MoodieList[row][column].getShowFlag() == true &&
                targets.MoodieList[row][column].GetType() == player.GetType())
            {
                targets.MoodieList[row][column].DisableShowFlag();
                ScoreManager.GetScoreManager().Update();
                Destroy(row,column-1,targets,player);
                Destroy(row, column + 1, targets, player);
                Destroy(row-1, column, targets, player);

                if (row !=targets.MoodieList.Count-1)
                    Destroy(row+1,column,targets,player);
            }
           
        }
    }
}
