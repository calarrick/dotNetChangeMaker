using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChangeMaker.Models
{

    
    public class Transaction
    {
        

        private int purchasePrice;
        private int amountTendered;
        private int amountChange;
        private string purchasePriceString;
        private string amountTenderedString;
        private string amountChangeString;
        private int[] changeItems;

        [Required(ErrorMessage = "Purchase price is required.")]
        [RegularExpression(@"\d+\.\d{2}", ErrorMessage = "Please enter dollars and cents divided by a period, e.g. '1.95'.")]
        public string PurchasePriceString
        {
            get
            {
                return purchasePriceString;
            }

            set
            {
                purchasePriceString = value;
            }
        }

        [Required(ErrorMessage = "We need to know the amount of money tendered by the customer.")]
        [RegularExpression(@"\d+\.\d{2}", ErrorMessage = "Please enter dollars and cents divided by a period, e.g. '1.95'.")]
        
        public string AmountTenderedString
        {
            get
            {
                return amountTenderedString;
            }

            set
            {
                amountTenderedString = value;
            }
        }

        public string AmountChangeString
        {
            get
            {
                return amountChangeString;
            }

            set
            {
                amountChangeString = value;
            }
        }

        public int[] ChangeItems
        {
            get
            {
                return changeItems;
            }
            set
            {
                changeItems = value;
            }

         
        }


        public void setNumericValues()
        {

            if (AmountChangeString != null && AmountChangeString != "")
            {
                string[] changeDollarsCents = AmountChangeString.Split('.');

                if (changeDollarsCents.Length == 2)
                {
                    setAmountChange(Int32.Parse(changeDollarsCents[0]), Int32.Parse(changeDollarsCents[1]));
                }
            }
            else
            {
                setAmountChange(0, 0);

            }


            string[] tenderedDollarsCents = AmountTenderedString.Split('.');

            if (tenderedDollarsCents.Length == 2)
            {
               setAmountTendered(Int32.Parse(tenderedDollarsCents[0]), Int32.Parse(tenderedDollarsCents[1]));
            }

            string[] purchaseDollarsCents = PurchasePriceString.Split('.');
            if (purchaseDollarsCents.Length == 2)
            {
                setPurchasePrice(Int32.Parse(purchaseDollarsCents[0]), Int32.Parse(purchaseDollarsCents[1]));
            }

            

        }




        public void setPurchasePrice(int priceDollars, int priceCents)
        {
            this.purchasePrice = (priceDollars * 100) + priceCents;

        }

        public void setAmountTendered(int tenderDollars, int tenderCents)
        {
            this.amountTendered = (tenderDollars * 100) + tenderCents;

        }

        public void setAmountChange(int changeDollars, int changeCents)
        {

            this.amountChange = (changeDollars * 100) + changeCents;

        }

        public void setAmountChange(int totalCents)
        {
            this.amountChange = totalCents;
        }
        

        public int[] calcChange()

        {
            

            int numTwenties = 0;
            int numTens = 0;
            int numFives = 0;
            int numOnes = 0;
            int numQuarters = 0;
            int numDimes = 0;
            int numNickels = 0;
            int numPennies = 0;
            int[] changeItems = new int[10];

            if (amountTendered >= purchasePrice)
            {

                amountChange = amountTendered - purchasePrice;
            }
            else { amountChange = 0; }

            

            //while (amountChange >= 2000)
            //{
            //    numTwenties++;
            //    amountChange = amountChange - 2000;

            //}

            numTwenties = amountChange / 2000;
            amountChange = amountChange % 2000;
            numTens = amountChange / 1000;
            amountChange = amountChange % 1000;
            numFives = amountChange / 500;
            amountChange = amountChange % 500;
            numOnes = amountChange / 100;
            amountChange = amountChange % 100;

            numQuarters = amountChange / 25;
            amountChange = amountChange % 25;
            numDimes = amountChange / 10;
            amountChange = amountChange % 10;
            numNickels = amountChange / 5;
            amountChange = amountChange % 5;
            numPennies = amountChange;
            
                changeItems[0] = numTwenties;
                changeItems[1] = numTens;
                changeItems[2] = numFives;
                changeItems[3] = numOnes;
                changeItems[4] = numQuarters;
                changeItems[5] = numDimes;
                changeItems[6] = numNickels;
                changeItems[7] = numPennies;

            this.ChangeItems = changeItems;

            changeItems[8] = numTwenties * 20 + numTens * 10 + numFives * 5 + numOnes * 1;
            changeItems[9] = numQuarters * 25 + numDimes * 10 + numNickels * 5 + numPennies;

           

                return changeItems;

            
        }


        public int calcTender()
        {
            amountTendered = purchasePrice + amountChange;

            
            return amountTendered;
        }



    }

   
}




    
