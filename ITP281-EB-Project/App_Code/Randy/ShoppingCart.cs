using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public class ShoppingCart
{
    public List<ShoppingCartItems> Items { get; private set; }

    //public static readonly ShoppingCart Instance;
    public static ShoppingCart Instance;

    // A Static Default ShoppingCart Constructor. Meaning developers need not use the New keyword.
    static ShoppingCart()
    {
        if (HttpContext.Current.Session["ShoppingCart"] == null)
        {
            Instance = new ShoppingCart();
            Instance.Items = new List<ShoppingCartItems>();
            HttpContext.Current.Session["ShoppingCart"] = Instance;
        }
        else
        {
            Instance = (ShoppingCart)HttpContext.Current.Session["ShoppingCart"];
        }
    }

    protected ShoppingCart() { }

    public ShoppingCartItems getAShopptingCartItem(string ItemID)
    {

        //ShoppingCartItem newItem = new ShoppingCartItem(ItemID, prod);

        if (!Items.Equals(null))
        {
            foreach (ShoppingCartItems item in Items)
            {
                if (item.ItemID == ItemID)
                {
                    return item;
                }
            }
        }
        return null;
    }
    public void AddItem(string ItemID, CourseClass course)
    {
        ShoppingCartItems newItem = new ShoppingCartItems(ItemID, course);

        if (Items.Contains(newItem))
        {
            foreach (ShoppingCartItems item in Items)
            {
                if (item.Equals(newItem))
                {
                    item.Quantity++;
                    return;
                }
            }
        }
        else
        {
            newItem.Quantity = 1;
            Items.Add(newItem);
        }
    }

    public void SetItemQuantity(string ItemID, int quantity)
    {
        if (quantity == 0)
        {
            RemoveItem(ItemID);
            return;
        }

        ShoppingCartItems updatedItem = new ShoppingCartItems(ItemID);

        foreach (ShoppingCartItems Item in Items)
        {
            if (Item.Equals(updatedItem))
            {
                Item.Quantity = quantity;
                return;
            }
        }
    }

    // Remove a ShoppingCartItem from the ShoppingCart Instance by providing a Product ID 
    public void RemoveItem(string ItemID)
    {
        Items.Remove(ShoppingCart.Instance.getAShopptingCartItem(ItemID));
    }

    public decimal GetSubTotal()
    {
        decimal subTotal = 0;
        foreach (ShoppingCartItems item in Items)
        {
            subTotal += item.TotalPrice;
        }
        return subTotal;
    }
}