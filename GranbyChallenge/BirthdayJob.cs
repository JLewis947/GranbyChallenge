﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GranbyChallenge
{
    public class BirthdayJob : JobTemplate
    {
        public override string Name => "Birthday Job";

        public override int DispatchTime { get; set; }
        public override Stock WarehouseStock { get; set; }

        public BirthdayJob(int dispatchTime)
        {
            DispatchTime = dispatchTime;
            WarehouseStock = Stock.GetInstance();
        }
        public override bool CheckStock()
        {
            // Check that stock is available and return true if available or false if not available
            if (WarehouseStock.ToyStockAmount > 0)
            {
                if(WarehouseStock.BubblewrapStockAmount > 0)
                {
                    if(WarehouseStock.CardboardboxStockAmount > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override bool ProcessOrder()
        {
            try
            {
                WarehouseStock.BubblewrapStockAmount--;
                WarehouseStock.CardboardboxStockAmount--;
                WarehouseStock.ToyStockAmount--;
            } catch
            {
                Console.WriteLine("Stock change has failed");
                return false;
            }
            return true;
        }
    }
}
