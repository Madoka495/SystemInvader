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
    public class UpgradeTower
    {
        List<Tower> _placedTowers;
        List<Tower> _listContaintTower;
        Player _player;

        bool _choice = false;
        bool _tracked = false;

        public UpgradeTower(TowersData towersData, Player player)
        {
            _player = player;
        }

        internal void Update(List<Tower> towers)
        {
            _placedTowers = towers;
            MouseState stateMouse = Mouse.GetState();
            foreach (Tower tower in _placedTowers)
            {
                _listContaintTower = tower.GiveListContient;
                if (stateMouse.LeftButton == ButtonState.Pressed)
                {
                    if (stateMouse.X >= tower.GetPos.X &&
                    stateMouse.X <= tower.GetPos.X + tower.GiveWidth &&
                    stateMouse.Y >= tower.GetPos.Y &&
                    stateMouse.Y <= tower.GetPos.Y + tower.GiveHeight)
                    {
                        if (_tracked == false)
                            _choice = false;
                        else
                            _choice = true;
                    }
                    else
                    {
                        _choice = false;
                    }
                }
                else
                {
                    if (_tracked == false)
                        _tracked = true;
                }

                if (_choice == true &&
                    _player.CurrentGold >= tower.GivePrice &&
                    tower.GiveUpgrade < 3)
                {
                    _player.CurrentGold -= tower.GivePrice;
                    Tower TowerAdd = _listContaintTower[tower.GiveUpgrade + 1];
                    TowerAdd.ChangePosition(tower.GetPos);
                    tower.GiveTextureTower = TowerAdd.GiveTextureTower;
                    tower.GiveTextureBullet = TowerAdd.GiveTextureBullet;
                    tower.GetPos = TowerAdd.GetPos;
                    tower.GiveRate = TowerAdd.GiveRate;
                    tower.GiveRate = TowerAdd.GiveRange;
                    tower.Givetype = TowerAdd.GiveRate;
                    tower.GivePrice = TowerAdd.GivePrice;
                    tower.GiveWidth = TowerAdd.GiveWidth;
                    tower.GiveHeight = TowerAdd.GiveHeight;
                    tower.GiveUpgrade = TowerAdd.GiveUpgrade;
                    _tracked = false;
                }
            }
        }
        public void UpdateListTower(List<Tower> placedTower, List<Tower> placedTowerUpdated)
        {
            placedTower = placedTowerUpdated;
        }
        public List<Tower> placedTower => _placedTowers;
    }
}
