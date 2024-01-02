using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System
{
    internal class Items
    {
        private int id = 0;
        private string name;
        private float price;
        private int qnt;

        public Items(int id, string name, float price, int qnt) {
            this.id = id;
            this.name = name;   
            this.price = price;
            this.qnt = qnt;
        }

        //getter
        public int getId() { return id; }
        public string getName() { return name; }
        public float getPrice() { return price; }
        public int getQnt() {  return qnt; }

        //setter
        public void setId(int id) { this.id = id; } 
        public void setName(string name) {  this.name = name; }
        public void setPrice(float price) {  this.price = price; }
        public void setQnt(int qnt) {  this.qnt = qnt; }

        //Object Details
        public String ToString()
        {
            return (" | Name:" + this.name + " | price:" + this.price + " | Quantity:" + this.qnt);
        }
    }
}
