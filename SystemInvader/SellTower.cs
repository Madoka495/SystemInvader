using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MO.SystemInvader;
using Data.SystemInvader;

namespace SystemInvader
{
    public class SellTower
    {
        List<Tower> _placedTowers;
        Player _player;
        Tower _towerSold;

        bool _choice;
        bool _tracked;

        public SellTower(Player player)
        {
            _player = player;
        }

        internal void Update(List<Tower> towers)
        {
            _placedTowers = towers;
            MouseState stateMouse = Mouse.GetState();
            foreach (Tower tower in _placedTowers)
            {
                if (stateMouse.X >= tower.GetPos.X &&
                        stateMouse.X <= tower.GetPos.X + tower.GiveWidth &&
                        stateMouse.Y >= tower.GetPos.Y &&
                        stateMouse.Y <= tower.GetPos.Y + tower.GiveHeight)
                {
                    if (stateMouse.LeftButton == ButtonState.Pressed && _tracked == false)
                        _choice = false;
                    if (stateMouse.LeftButton == ButtonState.Released && _tracked == false)
                        _tracked = true;
                    if (stateMouse.LeftButton == ButtonState.Pressed && _tracked == true)
                        _choice = true;
                }
                else
                {
                    _choice = false;
                }

                if (_choice)
                {
                    _player.CurrentGold += tower.GivePrice;
                    _towerSold = tower;
                }
            }
        }

        public Tower TowerSold => _towerSold;

        public List<Tower> EraseTowerFromList(Tower towerSold, List<Tower> towersList)
        {
            towersList.Remove(towerSold);
            _placedTowers = towersList;
            return _placedTowers;
        }

    }
}
