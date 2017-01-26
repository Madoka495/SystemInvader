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
    public class TowerDisplay
    {
        List<Tower> _placedTowers;
        Player _player;
        SpriteFont _timerFont;
        Tower _towerChoice;


        public TowerDisplay(Player player)
        {
            _player = player;
        }

        public List<Tower> placedTower => _placedTowers;


        public void Draw(SpriteBatch spriteBatch, List<Tower> towers, SpriteFont timerFont)
        {

            _timerFont = timerFont;
            _placedTowers = towers;
            MouseState stateMouse = Mouse.GetState();
            foreach (Tower tower in _placedTowers)
            {
                if (stateMouse.X >= tower.GetPos.X &&
                stateMouse.X <= tower.GetPos.X + tower.GiveWidth &&
                stateMouse.Y >= tower.GetPos.Y - tower.GiveHeight &&
                stateMouse.Y <= tower.GetPos.Y)
                {
                    if (stateMouse.LeftButton == ButtonState.Pressed)
                    {
                        _towerChoice = tower;
                    }
                }

                if (stateMouse.LeftButton == ButtonState.Released)
                {
                    if (_towerChoice != null)
                    {
                        spriteBatch.Draw(_towerChoice.GiveTextureTower, new Rectangle(36 * 32, 32, _towerChoice.GiveWidth, _towerChoice.GiveHeight), Color.White);
                        spriteBatch.DrawString(_timerFont, "Attack Damage : " + tower.GiveDamage, new Vector2(39 * 32, 10), Color.MediumOrchid);
                        spriteBatch.DrawString(_timerFont, "Range : " + tower.GiveRange, new Vector2(39 * 32, 20), Color.White);
                        spriteBatch.DrawString(_timerFont, "Rate : " + tower.GiveRate, new Vector2(39 * 32, 30), Color.Gold);
                    }
                }
            }


        }

    }
}
