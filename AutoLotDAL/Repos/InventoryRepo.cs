﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.Models;

namespace AutoLotDAL.Repos
{
    public class InventoryRepo : BaseRepo<Inventory>
    {
        public override List<Inventory> GetAll() 
            => Context.Cars.OrderBy(x=>x.PetName).ToList();
        public List<Inventory> GetNotAll(int id)
        {
            return (Context.Cars.Where(c => c.Id == id).ToList());
        }
    }
}
