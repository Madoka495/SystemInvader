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
           //00,01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,27,28,30,31,32,33,34,35,36,37,38,39,40,41,42
            {03,03,03,03,04,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,29,28,28,28,28,28,28,30},//0
            {10,00,10,10,12,03,04,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,27,00,00,00,00,00,00,27},//1
            {17,17,06,01,10,10,11,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,27,00,00,00,00,00,00,27},//2
            {08,08,16,17,06,10,11,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,27,00,00,00,00,00,00,27},//3
            {08,02,03,03,13,00,12,03,03,03,03,04,08,08,08,08,02,03,03,03,03,03,03,03,04,08,08,08,08,08,08,08,08,08,08,27,00,00,00,00,00,00,27},//4
            {08,09,10,00,10,00,10,10,10,00,10,11,08,08,08,08,09,10,10,00,10,00,00,01,11,08,08,08,08,08,08,08,08,08,08,27,00,00,00,00,00,00,27},//5
            {08,09,10,05,06,01,05,17,17,06,00,11,08,08,08,08,09,00,05,17,17,17,06,10,11,08,08,08,08,08,08,08,08,08,08,27,00,00,00,00,00,00,27},//6
            {08,09,00,12,13,10,11,08,08,09,01,12,03,03,03,03,13,10,11,08,08,08,09,10,11,08,08,08,08,08,08,08,08,08,08,27,00,00,00,00,00,00,27},//7
            {08,09,10,10,00,00,11,08,08,09,10,10,01,00,00,10,01,10,11,08,08,08,09,01,11,08,08,08,08,08,08,08,08,08,08,27,00,00,00,00,00,00,27},//8
            {08,16,17,17,17,17,18,08,08,16,17,17,17,17,17,17,17,17,18,08,08,08,09,00,11,08,08,08,08,08,08,08,08,08,08,27,00,00,00,00,00,00,27},//9
            {08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,02,03,03,03,03,13,00,12,03,03,03,03,03,03,03,04,08,08,27,00,00,00,00,00,00,27},//10
            {08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,08,09,00,10,01,00,10,00,01,10,00,10,00,01,10,10,11,08,08,27,00,00,00,00,00,00,27},//11
            {08,08,08,08,08,02,03,03,03,03,03,03,03,03,04,08,08,09,00,05,17,17,06,10,05,17,17,17,17,17,06,10,11,08,08,27,00,00,00,00,00,00,27},//12
            {08,08,08,08,02,13,10,10,10,00,00,01,10,00,11,08,08,09,10,19,20,08,09,01,11,08,08,08,08,08,09,00,11,08,08,27,00,00,00,00,00,00,27},//13
            {08,08,08,08,09,10,01,05,17,17,17,17,06,10,11,08,08,23,24,00,19,20,09,10,11,08,08,08,08,08,09,10,11,08,08,27,00,00,00,00,00,00,27},//14
            {08,08,08,08,09,10,05,18,08,08,08,08,09,00,11,08,08,08,23,24,10,19,13,00,11,08,08,08,08,08,09,01,11,08,08,27,00,00,00,00,00,00,27},//15
            {08,08,08,08,09,00,11,08,08,08,08,08,09,10,11,08,08,08,08,23,24,01,00,10,11,08,08,08,08,08,09,10,11,08,08,27,00,00,00,00,00,00,27},//16
            {08,08,08,08,09,00,11,08,08,08,08,08,09,01,11,08,08,08,08,08,23,17,17,17,18,08,08,08,08,08,09,10,11,08,08,27,00,00,00,00,00,00,27},//17
            {08,08,08,08,09,01,11,08,08,08,08,08,09,10,12,03,03,03,03,03,03,03,03,03,03,03,03,03,03,03,13,00,11,08,08,27,00,00,00,00,00,00,27},//18
            {08,08,08,08,09,10,11,08,08,08,08,08,09,00,00,10,01,10,00,00,10,01,00,00,10,00,01,10,10,10,10,01,11,08,08,27,00,00,00,00,00,00,27},//19
            {08,08,08,08,09,10,11,08,08,08,08,08,16,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,18,08,08,32,28,28,28,28,28,28,31},//20
        };

        Queue<Vector2> waypoints = new Queue<Vector2>();

        public int WidthMap => map.GetLength(1);
        public int HeightMap => map.GetLength(0);

        public Texture2D _textureMap;
        public Texture2D _textureScreen;


        private Vector2 _supplement = new Vector2(1, 1) * 16;
        public Vector2 AtTheEnd => new Vector2(5, 20) * 32 + new Vector2(1, 1) * 16;

        List<Texture2D> _listTextureMap;
        List<Texture2D> _listTextureScreen; 
        List<Vector2> _listPaths = new List<Vector2>();

        public Queue<Vector2> Waypoints => waypoints;
        public int WindowWidth => WidthMap * 32;
        public int WindowHeight => HeightMap * 32;

        public Level()
        {
            AddWaypoints();
            _listTextureMap = new List<Texture2D>();
        }

        private bool IsInPaths2(int value)
        {
            for (int i = 0; i < 27; i++)
            {
                if (value == 7 || value == 8)
                    return false;
            }
            return true;
        }

        public bool IsInPaths(Vector2 vectorPos, Tower tower)
        {
            Vector2 vectorBase = vectorPos;
            for (int i = 0; i < WidthMap; i++)
            {
                for (int j = 0; j < HeightMap; j++)
                {
                    if (IsInPaths2(map[j, i]))
                    {
                        int tileX = i;
                        int tileY = j;
                        if (((tileX * 32) == vectorBase.X && (tileY * 32) == vectorBase.Y - 64) ||
                            ((tileX + 1) * 32 == vectorBase.X + 64 && (tileY * 32) == vectorBase.Y - 64) ||
                            ((tileX * 32) == vectorBase.X && (tileY + 1) * 32 == vectorBase.Y) ||
                            ((tileX + 1) * 32 == vectorBase.X + 64 && (tileY + 1) * 32 == vectorBase.Y))
                            return true;
                        /*if (vector.X >= i*32 &&
                            vector.X <= i*32 + 32 &&
                            vector.Y >= j*32 &&
                            vector.Y <= j*32 + 32)
                            return true;*/
                        //_listPaths.Add(new Vector2(i, j) * 32);
                    }
                }
            }
            return false;
        }

        public void AddWaypoints()
        {
            waypoints.Enqueue(new Vector2(0, 1) * 32 + _supplement);
            waypoints.Enqueue(new Vector2(3, 1) * 32 + _supplement);
            waypoints.Enqueue(new Vector2(3, 2) * 32 + _supplement);
            waypoints.Enqueue(new Vector2(5, 2) * 32 + _supplement);
            waypoints.Enqueue(new Vector2(5, 8) * 32 + _supplement);
            waypoints.Enqueue(new Vector2(2, 8) * 32 + _supplement);
            waypoints.Enqueue(new Vector2(2, 5) * 32 + _supplement);
            waypoints.Enqueue(new Vector2(10, 5) * 32 + _supplement);
            waypoints.Enqueue(new Vector2(10, 8) * 32 + _supplement);
            waypoints.Enqueue(new Vector2(17, 8) * 32 + _supplement);
            waypoints.Enqueue(new Vector2(17, 5) * 32 + _supplement);
            waypoints.Enqueue(new Vector2(23, 5) * 32 + _supplement);
            waypoints.Enqueue(new Vector2(23, 16) * 32 + _supplement);
            waypoints.Enqueue(new Vector2(21, 16) * 32 + _supplement);
            waypoints.Enqueue(new Vector2(27, 13) * 32 + _supplement);
            waypoints.Enqueue(new Vector2(27, 11) * 32 + _supplement);
            waypoints.Enqueue(new Vector2(31, 11) * 32 + _supplement);
            waypoints.Enqueue(new Vector2(31, 28) * 32 + _supplement);
            waypoints.Enqueue(new Vector2(13, 28) * 32 + _supplement);
            waypoints.Enqueue(new Vector2(13, 13) * 32 + _supplement);
            waypoints.Enqueue(new Vector2(6, 13) * 32 + _supplement);
            waypoints.Enqueue(new Vector2(6, 14) * 32 + _supplement);
            waypoints.Enqueue(new Vector2(5, 14) * 32 + _supplement);
            waypoints.Enqueue(new Vector2(5, 20) * 32 + _supplement);
        }

        public void AddTextureMap(List<Texture2D> listTexture)
        {
            _listTextureMap = listTexture;
        }

        public void AddTextureScreen(List<Texture2D> listTextureScreen)
        {
            _listTextureScreen = listTextureScreen;
        }
        //Draw/////////////////////////////////////////////////////////////////////////////////
        public void Draw(SpriteBatch batch)
        {
            for (int i = 0; i < WidthMap; i++)
            {
                for (int j = 0; j < HeightMap; j++)
                {
                    int _textureIndexMap = map[j, i];
                    _textureMap = _listTextureMap[_textureIndexMap];
                    batch.Draw(_textureMap, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
                }
            }
        }


    }
}
