using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public class ShoppingCartItems : IEquatable<ShoppingCartItems>
{
    public int Quantity { get; set; }

    private string _ItemID, _ItemName, _ItemDesc;
    private decimal _ItemPrice;
    public string ItemID

    {
        get { return _ItemID; }
        set { _ItemID = value; }
    }
    public string Product_Name
    {
        get { return _ItemName; }
        set { _ItemName = value; }
    }
    public string Product_Desc
    {
        get { return _ItemDesc; }
        set { _ItemDesc = value; }
    }
    public decimal ItemPrice
    {
        get { return _ItemPrice; }
        set { _ItemPrice = value; }
    }
    public decimal TotalPrice
    {
        get { return ItemPrice * Quantity; }
    }
    public ShoppingCartItems(string productID)
    {
        this.ItemID = productID;
    }

    public ShoppingCartItems(string Item_ID, CourseClass course)
    {
        //this.ItemID = productID;
        this.ItemID = Item_ID;
        this.Product_Name = course.Course_Author;
        this.Product_Desc = course.Course_Desc;
        this.ItemPrice = course.Course_Fee;

    }

    public ShoppingCartItems(string Item_ID, string productName, string productDesc, decimal productPrice, CourseClass course)
    {
        this.ItemID = Item_ID;
        this.Product_Name = course.Course_Author;
        this.Product_Desc = course.Course_Desc;
        this.ItemPrice = course.Course_Fee;

    }

    public bool Equals(ShoppingCartItems anItem)
    {
        return anItem.ItemID == this.ItemID;
    }

    public ShoppingCartItems() { }

}