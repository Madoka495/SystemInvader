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
    public class MouseMove
    {
        List<TowerShop> _towers;
        List<Tower> _placedTowers;
        Player _player;
        Level _level;
        TowersData _towersData;

        public MouseMove(Player player, Level level, TowersData towersData)
        {
            _towersData = towersData;
            _towers = new List<TowerShop>();
            _towers.Add(new TowerShop(new Vector2(220, 550), _towersData.Tower1[0], 1));
            _towers.Add(new TowerShop(new Vector2(320, 550), _towersData.Tower2[0], 1));
            _towers.Add(new TowerShop(new Vector2(420, 550), _towersData.Tower3[0], 1));
            _towers.Add(new TowerShop(new Vector2(520, 550), _towersData.TowerGreatArrow[0], 1));
            _towers.Add(new TowerShop(new Vector2(620, 550), _towersData.TowerExplosive[0], 1));
            _towers.Add(new TowerShop(new Vector2(720, 550), _towersData.TowerLight[0], 1));

            _placedTowers = new List<Tower>();
            _player = player;
            _level = level;
        }

        internal void Update()
        {
            MouseState stateMouse = Mouse.GetState();
            foreach (TowerShop tower in _towers)
            {
                if (stateMouse.LeftButton == ButtonState.Pressed)
                {
                    if (tower.Old.X != -1000 &&
                        tower.Old.Y != -1000 &&
                        tower.IsSetup == false)
                    {
                        if (tower.Old.X != stateMouse.X)
                        {
                            tower.Position = new Vector2(tower.ConvertToNearestTile(stateMouse.X), tower.Position.Y);
                        }
                        if (tower.Old.Y != stateMouse.Y)
                        {
                            tower.Position = new Vector2(tower.Position.X, tower.ConvertToNearestTile(stateMouse.Y));
                        }
                    }
                    if (stateMouse.X >= tower.Position.X &&
                        stateMouse.X <= tower.Position.X + tower.GiveTower.GiveWidth &&
                        stateMouse.Y >= tower.Position.Y &&
                        stateMouse.Y <= tower.Position.Y + tower.GiveTower.GiveHeight)
                    {
                        tower.Old = new Vector2(stateMouse.X, stateMouse.Y);
                    }
                    else
                    {
                        tower.IsSetup = true;
                    }
                }
                else
                {
                    if (tower.Old.X != -1000 &&
                    tower.Old.Y != -1000 &&
                    tower.Position != tower.Original &&
                    !_level.IsInPaths(tower.Position, tower.GiveTower))
                    {
                        if (_player.CurrentGold >= tower.GiveTower.GivePrice)
                        {
                            _player.CurrentGold -= tower.GiveTower.GivePrice;
                            Tower TowerAdd = tower.GiveTower;
                            TowerAdd.ChangePosition(tower.Position);
                            _placedTowers.Add(new Tower(
                                TowerAdd.GiveTextureBullet, 
                                TowerAdd.GiveTextureTower,
                                TowerAdd.GetPos,
                                TowerAdd.GiveRate,
                                TowerAdd.GiveRange,1,
                                TowerAdd.GivePrice,
                                TowerAdd.GiveWidth, 
                                TowerAdd.GiveHeight,
                                TowerAdd.GiveUpgrade,
                                TowerAdd.GiveListContient,
                                TowerAdd.GiveDamage));
                        }
                    }
                    tower.Position = tower.Original;
                    tower.Old = new Vector2(-1000, -1000);
                    tower.IsSetup = false;
                }
            }
        }

        public List<TowerShop> Towers
        {
            get { return _towers; }
            set { _towers = value; }
        }
        public List<Tower> PlacedTowers() => _placedTowers;
    }
}
