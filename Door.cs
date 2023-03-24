﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_v2
{
    internal class Door : Interactable
    {
        protected int destinationWorldX = 0;
        protected int destinationWorldY = 0;
        protected int destinationLocalX = 0;
        protected int destinationLocalY = 0;

        public Door()
        {
            type = "door";
            worldX = 0;
            worldY = 0;
            localX = 0;
            localY = 0;

            icon = '▀';
            color = ConsoleColor.DarkGray;
        }

        public int GetDestinationWorldX()
        {
            return destinationWorldX;
        }

        public int GetDestinationWorldY()
        {
            return destinationWorldY;
        }

        public int GetDestinationLocalX()
        {
            return destinationLocalX;
        }

        public int GetDestinationLocalY()
        {
            return destinationLocalY;
        }

        public void SetDestinationWorldX(int x)
        {
            destinationWorldX = x;
        }

        public void SetDestinationWorldY(int y)
        {
           destinationWorldY = y;
        }

        public void SetDestinationLocalX(int x)
        {
            destinationLocalX = x;
        }

        public void SetDestinationLocalY(int y)
        {
            destinationLocalY = y;
        }

        public override void Interact(Interactable input)
        {
            Player player = GameManager.GetPlayer();

            List<Door> doors = WorldManager.GetDoors();
            int destinationWorldX = 1;
            int destinationWorldY = 1;
            int destinationLocalX = 1;
            int destinationLocalY = 1;

            foreach (Door door in doors)
            {
                if (door == input)
                {
                    destinationWorldX = door.GetDestinationWorldX();
                    destinationWorldY = door.GetDestinationWorldY();
                    destinationLocalX = door.GetDestinationLocalX();
                    destinationLocalY = door.GetDestinationLocalY();
                }
            }

            player.SetWorldX(destinationWorldX);
            player.SetWorldY(destinationWorldY);
            player.SetX(destinationLocalX);
            player.SetY(destinationLocalY);
            MapManager.SetWorld(destinationWorldX, destinationWorldY);
            MapManager.SetRedraw(true);
            
        }
    }
}
