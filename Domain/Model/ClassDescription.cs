﻿// Licence file C:\Users\oleg\Documents\ReversePOCO.txt not found.
// Please obtain your licence file at www.ReversePOCO.co.uk, and place it in your documents folder shown above.
// Defaulting to Trial version.
// <auto-generated>
// ReSharper disable All


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Model
{

    // ****************************************************************************************************
    // This is not a commercial licence, therefore only a few tables/views/stored procedures are generated.
    // ****************************************************************************************************

    // Comments
    public class Comment
    {
        public int UserId { get; set; } // UserId (Primary key)
        public int GoodId { get; set; } // GoodId (Primary key)
        public int Rate { get; set; } // Rate
        public string Comment_ { get; set; } // Comment

        // Foreign keys

        /// <summary>
        /// Parent Good pointed by [Comments].([GoodId]) (FK__Comments__GoodId__46E78A0C)
        /// </summary>
        public Good Good { get; set; } // FK__Comments__GoodId__46E78A0C

        /// <summary>
        /// Parent User pointed by [Comments].([UserId]) (FK__Comments__UserId__45F365D3)
        /// </summary>
        public User User { get; set; } // FK__Comments__UserId__45F365D3
    }

    // Goods
    public class Good
    {
        public int Id { get; set; } // ID (Primary key)
        public string Category { get; set; } //Category
        public string Title { get; set; } // Title (length: 100)
        public decimal Price { get; set; } // Price
        public int Amount { get; set; } // Amount
        public string Descryption { get; set; } // Descryption

        // Reverse navigation

        /// <summary>
        /// Child Comments where [Comments].[GoodId] point to this entity (FK__Comments__GoodId__46E78A0C)
        /// </summary>
        public ICollection<Comment> Comments { get; set; } // Comments.FK__Comments__GoodId__46E78A0C

        /// <summary>
        /// Child GoodsLists where [GoodsList].[GoodId] point to this entity (FK__GoodsList__GoodI__3F466844)
        /// </summary>
        public ICollection<GoodsList> GoodsLists { get; set; } // GoodsList.FK__GoodsList__GoodI__3F466844

        /// <summary>
        /// Child LikedLists where [LikedList].[GoodId] point to this entity (FK__LikedList__GoodI__4316F928)
        /// </summary>
        public ICollection<LikedList> LikedLists { get; set; } // LikedList.FK__LikedList__GoodI__4316F928

        /// <summary>
        /// Child Ships where [Ships].[GoodId] point to this entity (FK__Ships__GoodId__4AB81AF0)
        /// </summary>
        public ICollection<Ship> Ships { get; set; } // Ships.FK__Ships__GoodId__4AB81AF0

        public Good()
        {
            Comments = new List<Comment>();
            GoodsLists = new List<GoodsList>();
            LikedLists = new List<LikedList>();
            Ships = new List<Ship>();
        }
    }

    // GoodsList
    public class GoodsList
    {
        public int UserId { get; set; } // UserId (Primary key)
        public int GoodId { get; set; } // GoodId (Primary key)
        public int Amount { get; set; } // Amount

        // Foreign keys

        /// <summary>
        /// Parent Good pointed by [GoodsList].([GoodId]) (FK__GoodsList__GoodI__3F466844)
        /// </summary>
        public Good Good { get; set; } // FK__GoodsList__GoodI__3F466844

        /// <summary>
        /// Parent User pointed by [GoodsList].([UserId]) (FK__GoodsList__UserI__3E52440B)
        /// </summary>
        public User User { get; set; } // FK__GoodsList__UserI__3E52440B
    }

    // LikedList
    public class LikedList
    {
        public int UserId { get; set; } // UserId (Primary key)
        public int GoodId { get; set; } // GoodId (Primary key)

        // Foreign keys

        /// <summary>
        /// Parent Good pointed by [LikedList].([GoodId]) (FK__LikedList__GoodI__4316F928)
        /// </summary>
        public Good Good { get; set; } // FK__LikedList__GoodI__4316F928

        /// <summary>
        /// Parent User pointed by [LikedList].([UserId]) (FK__LikedList__UserI__4222D4EF)
        /// </summary>
        public User User { get; set; } // FK__LikedList__UserI__4222D4EF
    }

    // SavedAdresses
    public class SavedAdress
    {
        public int UserId { get; set; } // UserId (Primary key)
        public string Title { get; set; } // Title (Primary key) (length: 20)
        public string City { get; set; } // City (length: 50)
        public string Street { get; set; } // Street (length: 50)
        public int House { get; set; } // House
        public int? Building { get; set; } // Building
        public int? Front { get; set; } // Front
        public int? Apartament { get; set; } // Apartament

        // Foreign keys

        /// <summary>
        /// Parent User pointed by [SavedAdresses].([UserId]) (FK__SavedAdre__UserI__398D8EEE)
        /// </summary>
        public User User { get; set; } // FK__SavedAdre__UserI__398D8EEE
    }

    // Ships
    public class Ship
    {
        public int Id { get; set; } // ID (Primary key)
        public int UserId { get; set; } // UserId (Primary key)
        public int GoodId { get; set; } // GoodId (Primary key)
        public int? Amount { get; set; } // Amount
        public DateTime ShipDate { get; set; } // ShipDate
        public string Status { get; set; } // Status (length: 100)

        // Foreign keys

        /// <summary>
        /// Parent Good pointed by [Ships].([GoodId]) (FK__Ships__GoodId__4AB81AF0)
        /// </summary>
        public Good Good { get; set; } // FK__Ships__GoodId__4AB81AF0

        /// <summary>
        /// Parent User pointed by [Ships].([UserId]) (FK__Ships__UserId__49C3F6B7)
        /// </summary>
        public User User { get; set; } // FK__Ships__UserId__49C3F6B7
    }

    // Users
    public class User
    {
        public int Id { get; set; } // ID (Primary key)
        public string Nickname { get; set; } // Nickname (length: 20)
        public string Surname { get; set; } // Surname (length: 20)
        public string Name { get; set; } // Name (length: 20)
        public string Email { get; set; } // Email (length: 50)
        public string Password { get; set; } // Password (length: 50)
        public string Phonenumber { get; set; } // Phonenumber (length: 50)
        public bool Authed { get; set; } // Authed
        public bool IsAdmin { get; set; } // IsAdmin
        public bool IsDelete { get; set; } // IsDelete

        // Reverse navigation

        /// <summary>
        /// Child Comments where [Comments].[UserId] point to this entity (FK__Comments__UserId__45F365D3)
        /// </summary>
        public ICollection<Comment> Comments { get; set; } // Comments.FK__Comments__UserId__45F365D3

        /// <summary>
        /// Child GoodsLists where [GoodsList].[UserId] point to this entity (FK__GoodsList__UserI__3E52440B)
        /// </summary>
        public ICollection<GoodsList> GoodsLists { get; set; } // GoodsList.FK__GoodsList__UserI__3E52440B

        /// <summary>
        /// Child LikedLists where [LikedList].[UserId] point to this entity (FK__LikedList__UserI__4222D4EF)
        /// </summary>
        public ICollection<LikedList> LikedLists { get; set; } // LikedList.FK__LikedList__UserI__4222D4EF

        /// <summary>
        /// Child SavedAdresses where [SavedAdresses].[UserId] point to this entity (FK__SavedAdre__UserI__398D8EEE)
        /// </summary>
        public ICollection<SavedAdress> SavedAdresses { get; set; } // SavedAdresses.FK__SavedAdre__UserI__398D8EEE

        /// <summary>
        /// Child Ships where [Ships].[UserId] point to this entity (FK__Ships__UserId__49C3F6B7)
        /// </summary>
        public ICollection<Ship> Ships { get; set; } // Ships.FK__Ships__UserId__49C3F6B7

        public User()
        {
            Comments = new List<Comment>();
            GoodsLists = new List<GoodsList>();
            LikedLists = new List<LikedList>();
            SavedAdresses = new List<SavedAdress>();
            Ships = new List<Ship>();
        }
    }

}
// </auto-generated>
