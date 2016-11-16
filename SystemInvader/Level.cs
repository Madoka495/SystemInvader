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
            {0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,1,0,0,1,0,0,0,0,1,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0},
            {0,1,0,0,1,0,0,0,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0},
            {0,1,1,1,1,0,0,0,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,1,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0},
            {0,0,0,0,0,1,1,1,1,1,1,1,1,0,0,0,1,0,1,0,0,0,0,1,0},
            {0,0,0,0,1,1,0,0,0,0,0,0,1,0,0,0,1,1,1,0,0,0,0,1,0},
            {0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0},
            {0,0,0,0,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0}
        };
        //chung ta se tao mot lop QUEUE de type Vector2
        private Queue<Vector2> waypoints = new Queue<Vector2>();
        //Sau do them vao elements
        //QUEUE   ->=====-> first in first out
        public Level()
        {
            waypoints.Enqueue(new Vector2(2, 0) * 32);//start
            waypoints.Enqueue(new Vector2(2, 1) * 32);
            waypoints.Enqueue(new Vector2(3, 1) * 32);
            waypoints.Enqueue(new Vector2(3, 2) * 32);
            waypoints.Enqueue(new Vector2(4, 2) * 32);
            waypoints.Enqueue(new Vector2(4, 4) * 32);
            waypoints.Enqueue(new Vector2(3, 4) * 32);
            waypoints.Enqueue(new Vector2(3, 5) * 32);
            waypoints.Enqueue(new Vector2(2, 5) * 32);
            waypoints.Enqueue(new Vector2(2, 7) * 32);
            waypoints.Enqueue(new Vector2(7, 7) * 32);//end
            
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
