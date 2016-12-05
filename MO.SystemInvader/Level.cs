using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MO.SystemInvader
{
    public class Level
    {
        int[,] map = new int[,]
        {
           //00,01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34
            {03,03,03,03,04,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08},//0
            {10,00,10,10,12,03,04,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08},//1
            {17,17,06,01,10,10,11,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08},//2
            {08,08,16,17,06,10,11,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08},//3
            {08,02,03,03,13,00,12,03,03,03,03,04,08,08,08,08,02,03,03,03,03,03,03,03,04,08,08,08,08,08,08,08,08,08,08},//4
            {08,09,10,00,10,00,10,10,10,00,10,11,08,08,08,08,09,10,10,00,10,00,00,01,11,08,08,08,08,08,08,08,08,08,08},//5
            {08,09,10,05,06,01,05,17,17,06,00,11,08,08,08,08,09,00,05,17,17,17,06,10,11,08,08,08,08,08,08,08,08,08,08},//6
            {08,09,00,12,13,10,11,08,08,09,01,12,03,03,03,03,13,10,11,08,08,08,09,10,11,08,08,08,08,08,08,08,08,08,08},//7
            {08,09,10,10,00,00,11,08,08,09,10,10,01,00,00,10,01,10,11,08,08,08,09,01,11,08,08,08,08,08,08,08,08,08,08},//8
            {08,16,17,17,17,17,18,08,08,16,17,17,17,17,17,17,17,17,18,08,08,08,09,00,11,08,08,08,08,08,08,08,08,08,08},//9
            {08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,02,03,03,03,03,13,00,12,03,03,03,03,03,03,03,04,08,08},//10
            {08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,09,00,10,01,00,10,00,01,10,00,10,00,01,10,10,11,08,08},//11
            {08,08,08,08,08,02,03,03,03,03,03,03,03,03,04,08,08,09,00,05,17,17,06,10,05,17,17,17,17,17,06,10,11,08,08},//12
            {08,08,08,08,02,13,10,10,10,00,00,01,10,00,11,08,08,09,10,19,20,08,09,01,11,08,08,08,08,08,09,00,11,08,08},//13
            {08,08,08,08,09,10,01,05,17,17,17,17,06,10,11,08,08,23,24,00,19,20,09,10,11,08,08,08,08,08,09,10,11,08,08},//14
            {08,08,08,08,09,10,05,18,08,08,08,08,09,00,11,08,08,08,23,24,10,19,13,00,11,08,08,08,08,08,09,01,11,08,08},//15
            {08,08,08,08,09,00,11,08,08,08,08,08,09,10,11,08,08,08,08,23,24,01,00,10,11,08,08,08,08,08,09,10,11,08,08},//16
            {08,08,08,08,09,00,11,08,08,08,08,08,09,01,11,08,08,08,08,08,23,17,17,17,18,08,08,08,08,08,09,10,11,08,08},//17
            {08,08,08,08,09,01,11,08,08,08,08,08,09,10,12,03,03,03,03,03,03,03,03,03,03,03,03,03,03,03,13,00,11,08,08},//18
            {08,08,08,08,09,10,11,08,08,08,08,08,09,00,00,10,01,10,00,00,10,01,00,00,10,00,01,10,10,10,10,01,11,08,08},//19
            {08,08,08,08,09,10,11,08,08,08,08,08,16,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,18,08,08},//20
        };

        Queue<Vector2> waypoints = new Queue<Vector2>();

        public int Width => map.GetLength(1);
        public int Height => map.GetLength(0);
        public Texture2D _texture;

        public Vector2 AtTheEnd => new Vector2(5, 20) * 32;
        List<Texture2D> _listTexture;

        public Queue<Vector2> Waypoints => waypoints;
        public int WindowWidth => Width * 32;
        public int WindowHeight => Height * 32;

        public Level()
        {
            AddWaypoints();
            _listTexture = new List<Texture2D>();
        }

        public void AddWaypoints()
        {
            waypoints.Enqueue(new Vector2(0, 1) * 32);
            waypoints.Enqueue(new Vector2(3, 1) * 32);
            waypoints.Enqueue(new Vector2(3, 2) * 32);
            waypoints.Enqueue(new Vector2(5, 2) * 32);
            waypoints.Enqueue(new Vector2(5, 8) * 32);
            waypoints.Enqueue(new Vector2(2, 8) * 32);
            waypoints.Enqueue(new Vector2(2, 5) * 32);
            waypoints.Enqueue(new Vector2(10, 5) * 32);
            waypoints.Enqueue(new Vector2(10, 8) * 32);
            waypoints.Enqueue(new Vector2(17, 8) * 32);
            waypoints.Enqueue(new Vector2(17, 5) * 32);
            waypoints.Enqueue(new Vector2(23, 5) * 32);
            waypoints.Enqueue(new Vector2(23, 16) * 32);
            waypoints.Enqueue(new Vector2(21, 16) * 32);
            waypoints.Enqueue(new Vector2(18, 13) * 32);
            waypoints.Enqueue(new Vector2(18, 11) * 32);
            waypoints.Enqueue(new Vector2(31, 11) * 32);
            waypoints.Enqueue(new Vector2(31, 19) * 32);
            waypoints.Enqueue(new Vector2(13, 19) * 32);
            waypoints.Enqueue(new Vector2(13, 13) * 32);
            waypoints.Enqueue(new Vector2(6, 13) * 32);
            waypoints.Enqueue(new Vector2(6, 14) * 32);
            waypoints.Enqueue(new Vector2(5, 14) * 32);
            waypoints.Enqueue(new Vector2(5, 20) * 32);
        }

        public void AddTexture(List<Texture2D> listTexture)
        {
            _listTexture = listTexture;
        }


        //Draw/////////////////////////////////////////////////////////////////////////////////
        public void Draw(SpriteBatch batch)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    int _textureIndex = map[j, i];
                    _texture = _listTexture[_textureIndex];
                    batch.Draw(_texture, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
                }
            }
        }
    }
}
