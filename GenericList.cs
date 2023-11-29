using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenericList
{
    class GenericList<T>
    {
        private List<T> items;
        private int CapacityInc;

        public GenericList(int currentCap = 4, int capacityInc = 0)
        {
            items = new List<T>(currentCap);
            CapacityInc = capacityInc;
        }

        public int Count 
        { 
            get { return items.Count; }
        }

        public int Capacity 
        { 
            get { return CapacityInc; } 
        }



        public void Add(T item)
        {
            items.Add(item);
            if(Count == CapacityInc)
            {
                items.Capacity += CapacityInc;
            }
        }



        public T Find(Predicate<T> match)
        {
            return items.Find(match);
        }


        public List<T> FindAll(Predicate<T> match)
        {
            return items.FindAll(match);
        }



        public bool Contains(T item)
        {
            return items.Contains(item);
        }



        public bool Exists(Predicate<T> match)
        {
            return items.Exists(match);
        }



        public bool Remove(T item)
        {
            bool removed = items.Remove(item);

            if(removed && Count + CapacityInc < Capacity)
            {
                items.Capacity -= CapacityInc;
            }

            return removed;
        }

    }
}
