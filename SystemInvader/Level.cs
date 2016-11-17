using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace VirusInvader
{
    public class Level
    {
        int[,] map = new int[,]
        {
           //0,1,2,3,4,5,6,7,8,9,0,1,2,3,4,5,6,7,8,9,0,1,2,3,4
            {0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},//0
            {0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},//1
            {0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},//2
            {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},//3
            {0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},//4
            {0,1,0,0,1,0,0,0,0,1,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0},//5
            {0,1,0,0,1,0,0,0,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0},//6
            {0,1,1,1,1,0,0,0,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0},//7
            {0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,1,0,0,0,0,0,0},//8
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0},//9
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0},//10
            {0,0,0,0,0,1,1,1,1,1,1,1,1,0,0,0,1,0,1,0,0,0,0,1,0},//11
            {0,0,0,0,1,1,0,0,0,0,0,0,1,0,0,0,1,1,1,0,0,0,0,1,0},//12
            {0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0},//12
            {0,0,0,0,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0} //13
        };
        //chung ta se tao mot lop QUEUE de type Vector2
        private Queue<Vector2> waypoints = new Queue<Vector2>();
        //Sau do them vao elements
        //QUEUE   ->=====-> first in first out
        public Level()
        {
            waypoints.Enqueue(new Vector2(2, 0) * 32);
            waypoints.Enqueue(new Vector2(2, 2) * 32);
            waypoints.Enqueue(new Vector2(4, 2) * 32);
            waypoints.Enqueue(new Vector2(4, 7) * 32);
            waypoints.Enqueue(new Vector2(1, 7) * 32);
            waypoints.Enqueue(new Vector2(1, 4) * 32);
            waypoints.Enqueue(new Vector2(9, 4) * 32);
            waypoints.Enqueue(new Vector2(9, 8) * 32);
            waypoints.Enqueue(new Vector2(14, 8) * 32);
            waypoints.Enqueue(new Vector2(14, 5) * 32);
            waypoints.Enqueue(new Vector2(18, 5) * 32);
            waypoints.Enqueue(new Vector2(18, 12) * 32);
            waypoints.Enqueue(new Vector2(16, 12) * 32);
            waypoints.Enqueue(new Vector2(16, 10) * 32);
            waypoints.Enqueue(new Vector2(23, 10) * 32);
            waypoints.Enqueue(new Vector2(23, 14) * 32);
            waypoints.Enqueue(new Vector2(12, 14) * 32);
            waypoints.Enqueue(new Vector2(12, 11) * 32);
            waypoints.Enqueue(new Vector2(5, 11) * 32);
            waypoints.Enqueue(new Vector2(5, 12) * 32);
            waypoints.Enqueue(new Vector2(4, 12) * 32);
            waypoints.Enqueue(new Vector2(4, 12) * 32);

        }
        public Queue<Vector2> Waypoints => waypoints;

        private List<Texture2D> TileTexture = new List<Texture2D>();
        
        

        public void AddTexture(Texture2D texture)
        {
            TileTexture.Add(texture);
        }

        public int Width => map.GetLength(1);
        public int Height => map.GetLength(0);

        public void Draw(SpriteBatch batch)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    int textureIndex = map[j, i];
                    Texture2D texture = TileTexture[textureIndex];

                    batch.Draw(texture, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
                }
            }
        }




    }
}
