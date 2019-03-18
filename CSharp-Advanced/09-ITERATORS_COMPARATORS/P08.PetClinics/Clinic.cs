using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P08.PetClinics
{
    public class Clinic : IEnumerable<Pet>
    {
        private Pet[] rooms;
        private int roomsCount;

        public string Name { get; private set; }
        public int RoomsCount
        {
            get => this.roomsCount;
            private set
            {
                if (value % 2 != 1)
                {
                    throw new ArgumentException("Invalid Operation!");
                }
                this.roomsCount = value;
            }
        }

        public Clinic(string name, int rooms)
        {
            this.Name = name;
            this.RoomsCount = rooms;
            this.rooms = new Pet[rooms];
        }

        public bool Add(Pet pet)
        {
            int moves = 0;
            int middleRoomIndex = RoomsCount / 2;
            var accomodatedPet = rooms[middleRoomIndex];

            if (accomodatedPet == null)
            {
                rooms[middleRoomIndex] = pet;
                return true;
            }

            while (true)
            {
                moves++;
                var roomOnLeft = middleRoomIndex - moves;
                var roomOnRight = middleRoomIndex + moves;

                if (roomOnLeft < 0 || roomOnRight > this.RoomsCount)
                {
                    return false;
                }

                if (rooms[roomOnLeft] == null)
                {
                    rooms[roomOnLeft] = pet;
                    return true;
                }
                else if (rooms[roomOnRight] == null)
                {
                    rooms[roomOnRight] = pet;
                    return true;
                }
            }
        }

        public bool Release()
        {
            int middleRoomIndex = RoomsCount / 2;

            var accomodatedPet = rooms[middleRoomIndex];

            if (accomodatedPet != null)
            {
                rooms[middleRoomIndex] = null;
                return true;
            }

            for (int i = 1; i < this.RoomsCount; i++)
            {
                int nextRoomIndex = (middleRoomIndex + i) % this.RoomsCount;
                accomodatedPet = rooms[nextRoomIndex];

                if(accomodatedPet != null)
                {
                    rooms[nextRoomIndex] = null;
                    return true;
                }
            }

            return false;
        }

        public bool HasEmptyRooms()
        {
            for (int i = 0; i < this.rooms.Length; i++)
            {
                if(rooms[i] != null)
                {
                    return false;
                }
            }
            return true;
        }

        public string PrintRoomContent(int roomNumber)
        {
            if (roomNumber - 1 >= this.roomsCount)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            var petInRoom = this.rooms[roomNumber - 1];

            if (petInRoom == null)
            {
                throw new ArgumentException("Room empty");
            }

            return petInRoom.ToString();
        }

        public IEnumerator<Pet> GetEnumerator()
        {
            for (int i = 0; i < this.rooms.Length; i++)
            {
                yield return this.rooms[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
