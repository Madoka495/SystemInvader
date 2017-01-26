using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MO.SystemInvader;
using Microsoft.Xna.Framework.Content;

namespace SystemInvader
{
    public class PlaceTower
    {
        List<TowerShop> _towers;
        List<Tower> _placedTowers;
        List<Tower> _evolutions;
        List<Tower> _2ndEvolutions;
        Player _player;
        Level _level;
        bool _towerSelected;
        TowerShop _selectedTower = null;

        public PlaceTower(Player player, Level level, ContentManager content)
        {
            _towers = new List<TowerShop>(); // position, sprite, rate, range, power, speed, type, price, comment

            _evolutions = new List<Tower>();
            _2ndEvolutions = new List<Tower>();
            _2ndEvolutions.Add(new Tower(new Vector2(780, 755), content.Load<Texture2D>("Sprites/tower2-3"), new List<Tower>(), 14, 350, 20, 16, 400, 8, "Elemental bullets ! This tower can fire\r\nbullets with different effects.", _player));
            _evolutions.Add(new Tower(new Vector2(710, 749), content.Load<Texture2D>("Sprites/tower2-2"), _2ndEvolutions, 16, 350, 18, 12, 250, 7, "Bullets from another dimension...\r\nFaster and stronger than the previous\r\nones.", _player));
            _towers.Add(new TowerShop(new Vector2(150, 970), content.Load<Texture2D>("Sprites/tower2"), _evolutions, 40, 175, 10, 8, 1, 100, "Multi-shot. Fire bullets all around\r\nthe tower."));

            _evolutions = new List<Tower>();
            _2ndEvolutions = new List<Tower>();
            _evolutions.Add(new Tower(new Vector2(710, 770), content.Load<Texture2D>("Sprites/tower5-2"), _2ndEvolutions, 10, 9999, 16, 16, 400, 6, "Fire a literal storm of bullets at the\r\nentire map !", _player));
            _2ndEvolutions = new List<Tower>();
            _evolutions.Add(new Tower(new Vector2(810, 770), content.Load<Texture2D>("Sprites/tower5-3"), _2ndEvolutions, 120, 600, 2000, 25, 300, 9, "A living tower that fire extremely\r\npowerful bullets, but needs to load\r\nthem.", _player));
            _towers.Add(new TowerShop(new Vector2(230, 970), content.Load<Texture2D>("Sprites/tower5"), _evolutions, 30, 400, 5, 16, 2, 150, "Teleport bullets right on the foe."));

            _evolutions = new List<Tower>();
            _towers.Add(new TowerShop(new Vector2(310, 930), content.Load<Texture2D>("Sprites/tower6"), _evolutions, 8, 250, 12, 24, 3, 50, "Bullets will slow down the foe."));

            _evolutions = new List<Tower>();
            _towers.Add(new TowerShop(new Vector2(390, 930), content.Load<Texture2D>("Sprites/tower4"), _evolutions, 60, 300, 24, 24, 4, 75, "Bullets will freeze the foe,\r\nmaking it unable to move for 2 seconds."));

            _evolutions = new List<Tower>();
            _towers.Add(new TowerShop(new Vector2(470, 930), content.Load<Texture2D>("Sprites/tower3"), _evolutions, 10, 250, 12, 8, 5, 75, "Bullets will poison the foe,\r\nwhich will progressively deal it damage."));

            _evolutions = new List<Tower>();
            _towers.Add(new TowerShop(new Vector2(550, 940), content.Load<Texture2D>("Sprites/tower7"), _evolutions, 8, 250, 16, 10, 10, 50, "Bullets will change the foe\r\ninto gold, making its drop two times\r\nbigger."));

            _placedTowers = new List<Tower>();
            _player = player;
            _level = level;
        }
 
        internal void Update()
        {
            MouseState stateMouse = Mouse.GetState();
            _towerSelected = false;
            foreach (TowerShop tower in _towers)
            {
                if (tower.Price <= _player.CurrentGold)
                {
                    if (stateMouse.LeftButton == ButtonState.Pressed)
                    {
                        if (tower.Old.X != -1000 && tower.Old.Y != -1000 && tower.WasPressed == false)
                        {
                            if (tower.Old.X < stateMouse.X)
                            {
                                tower.Position = new Vector2(tower.Position.X + (stateMouse.X - tower.Old.X), tower.Position.Y);
                            }
                            else if (tower.Old.X > stateMouse.X)
                            {
                                tower.Position = new Vector2(tower.Position.X - (tower.Old.X - stateMouse.X), tower.Position.Y);
                            }

                            if (tower.Old.Y < stateMouse.Y)
                            {
                                tower.Position = new Vector2(tower.Position.X, tower.Position.Y + (stateMouse.Y - tower.Old.Y));
                            }
                            else if (tower.Old.Y > stateMouse.Y)
                            {
                                tower.Position = new Vector2(tower.Position.X, tower.Position.Y - (tower.Old.Y - stateMouse.Y));
                            }
                        }
                        if (stateMouse.X >= tower.Position.X && stateMouse.X <= tower.Position.X + tower.Sprite.Width && stateMouse.Y >= tower.Position.Y && stateMouse.Y <= tower.Position.Y + tower.Sprite.Height)
                        {
                            tower.Old = new Vector2(stateMouse.X, stateMouse.Y);
                            _towerSelected = true;

                            if (_selectedTower == null)
                            {
                                _selectedTower = tower;
                            }
                        }
                        else
                        {
                            tower.WasPressed = true;
                        }
                    }
                    else
                    {
                        if (tower.Old.X != -1000 && tower.Old.Y != -1000 && tower.Position != tower.Original && !_level.IsInPaths(tower.Position, tower.Sprite))
                        {
                            bool isOccuped = false;
                            foreach (Tower placedTower in _placedTowers)
                            {
                                if (placedTower.InGame() == true)
                                {
                                    float newX1 = tower.Position.X + 5;
                                    float newX2 = tower.Position.X + tower.Sprite.Width - 5;
                                    float newY1 = tower.Position.Y + (tower.Sprite.Height / 2);
                                    float newY2 = tower.Position.Y + tower.Sprite.Height - 5;
                                    float towerX1 = placedTower.GetPos().X + 5;
                                    float towerX2 = placedTower.GetPos().X + placedTower.Sprite.Width - 5;
                                    float towerY1 = placedTower.GetPos().Y + (placedTower.Sprite.Height / 2);
                                    float towerY2 = placedTower.GetPos().Y + placedTower.Sprite.Height - 5;

                                    if ((newX1 > towerX1 && newX1 < towerX2) || (newX2 > towerX1 && newX2 < towerX2) || (towerX1 > newX1 && towerX1 < newX2) || (towerX2 > newX1 && towerX2 < newX2))
                                    {
                                        if ((newY1 > towerY1 && newY1 < towerY2) || (newY2 > towerY1 && newY2 < towerY2) || (towerY1 > newY1 && towerY1 < newY2) || (towerY2 > newY1 && towerY2 < newY2))
                                        {
                                            isOccuped = true;
                                        }
                                    }
                                }
                            }
                            if (_player.CurrentGold >= tower.Price && isOccuped == false)
                            {
                                _player.CurrentGold -= tower.Price;
                                _placedTowers.Add(new Tower(tower.Position, tower.Sprite, tower.Evolutions, tower.Rate, tower.Range, tower.Power, tower.Speed, tower.Price, tower.Type, tower.Comment, _player));
                            }
                        }
                        tower.Position = tower.Original;
                        tower.Old = new Vector2(-1000, -1000);
                        tower.WasPressed = false;
                        _selectedTower = null;
                    }
                }
            }
            
        }

        public List<TowerShop> Towers()
        {
            return _towers;
        }
        public List<Tower> PlacedTowers()
        {
            return _placedTowers;
        }
        public TowerShop SelectedTower()
        {
            return _selectedTower;
        }
        public bool Selected()
        {
            return _towerSelected;
        }
    }
}
