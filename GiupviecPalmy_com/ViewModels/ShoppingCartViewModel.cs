using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiupviecPalmy_com.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel()
        {
            this.CartItems = new List<osCart>();
        }
        public List<osCart> CartItems { get; set; }
        public float CartTotal { get; set; }
    }
}