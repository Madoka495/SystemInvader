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
            {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},//0
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
            {0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0},//13
            {0,0,0,0,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0} //14
        };
        //chung ta se tao mot lop QUEUE de type Vector2
        private Queue<Vector2> waypoints = new Queue<Vector2>();
        //Sau do them vao elements
        //QUEUE   ->=====-> first in first out

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
