﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using TermProjectLibrary;
using System.Data.SqlClient;

namespace _3342DevStepFinal
{
    public partial class Hotel : System.Web.UI.Page
    {
        Hotels.HotelService proxy = new Hotels.HotelService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Searches for hotels with avaliable rooms
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            string city = txtCity.Text;
            string state = ddlState.SelectedItem.Text;
            string bed = ddlBed.SelectedItem.Text;
            int hotelID = 0;
            int optionsCount = 0;

            if (cbCoffee.Checked)
                optionsCount++;
            if (cbSmoking.Checked)
                optionsCount++;
            if (cbWifi.Checked)
                optionsCount++;
            if (cbKitchen.Checked)
                optionsCount++;
            if (cbBreakfast.Checked)
                optionsCount++;

            for (int i = 0; i < gvRoomResults.Rows.Count; i++)
            {
                if (gvRoomResults.Rows[i].FindControl("btnAddToCart") == sender)
                {
                    hotelID = int.Parse(gvRoomResults.Rows[i].Cells[0].Text);
                }
            }

            if (optionsCount == 0)
            {
                Hotels.Amenities amen = new Hotels.Amenities();
                gvRoomResults.DataSource = proxy.FindRooms(amen, city, state);
            }

            else
            {
                Hotels.Amenities amenities = new Hotels.Amenities();
                amenities.HasFreeCoffee = cbCoffee.Checked;
                amenities.IsSmoking = cbSmoking.Checked;
                amenities.HasFreeWifi = cbWifi.Checked;
                amenities.BedSize = bed;
                amenities.HasKitchen = cbKitchen.Checked;
                amenities.FreeBreakfast = cbBreakfast.Checked;
                gvRoomResults.DataSource = proxy.FindRooms(amenities, txtCity.Text, ddlState.Text);
            }

            gvRoomResults.DataBind();
        }

        //protected void btnSearchforRooms_Click(object sender, EventArgs e)
        //{
        //    gvHotelResults.Visible = false;
        //    gvRoomResults.Visible = true;
        //    int hotelID = 0;
        //    Hotel thehotel ;

        //    for (int i = 0; i < gvHotelResults.Rows.Count; i++)
        //    {
        //        if (gvHotelResults.Rows[i].FindControl("btnSearchforRooms") == sender)
        //        {
        //            hotelID = int.Parse(gvHotelResults.Rows[i].Cells[0].Text);
        //        }
        //        else
        //        {
        //            DataSet myDS = proxy.FindRoomsByHotel();
        //        }
        //    }
        //    gvRoomResults.DataBind();
        //}

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {

        }
    }
}