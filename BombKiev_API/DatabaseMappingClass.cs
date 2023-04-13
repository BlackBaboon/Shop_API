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
    public class CreateComment
    {
        public int UserId { get; set; } // UserId (Primary key)
        public int GoodId { get; set; } // GoodId (Primary key)
        public int Rate { get; set; } // Rate
        public int? Comment_ { get; set; } // Comment
    }

    // Goods
    public class CreateGood
    {
        public int Id { get; set; } // ID (Primary key)
        public string Title { get; set; } // Title (length: 100)
        public decimal Price { get; set; } // Price
        public int Amount { get; set; } // Amount
        public string Descryption { get; set; } // Descryption
    }

    // GoodsList
    public class CreateGoodsList
    {
        public int UserId { get; set; } // UserId (Primary key)
        public int GoodId { get; set; } // GoodId (Primary key)
        public int Amount { get; set; } // Amount
    }

    // LikedList
    public class CreateLikedList
    {
        public int UserId { get; set; } // UserId (Primary key)
        public int GoodId { get; set; } // GoodId (Primary key)
    }

    // SavedAdresses
    public class CreateSavedAdress
    {
        public int UserId { get; set; } // UserId (Primary key)
        public string Title { get; set; } // Title (Primary key) (length: 20)
        public string City { get; set; } // City (length: 50)
        public string Street { get; set; } // Street (length: 50)
        public int House { get; set; } // House
        public int? Building { get; set; } // Building
        public int? Front { get; set; } // Front
        public int? Apartament { get; set; } // Apartament
    }

    // Ships
    public class CreateShip
    {
        public int Id { get; set; } // ID (Primary key)
        public int UserId { get; set; } // UserId (Primary key)
        public int GoodId { get; set; } // GoodId (Primary key)
        public int? Amount { get; set; } // Amount
        public DateTime ShipDate { get; set; } // ShipDate
        public string Status { get; set; } // Status (length: 100)
    }

    // Users
    public class CreateUser
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
    }

    public class GetComment
    {
        public int UserId { get; set; } // UserId (Primary key)
        public int GoodId { get; set; } // GoodId (Primary key)
        public int Rate { get; set; } // Rate
        public int? Comment_ { get; set; } // Comment
    }

    // Goods
    public class GetGood
    {
        public int Id { get; set; } // ID (Primary key)
        public string Title { get; set; } // Title (length: 100)
        public decimal Price { get; set; } // Price
        public int Amount { get; set; } // Amount
        public string Descryption { get; set; } // Descryption
    }

    // GoodsList
    public class GetGoodsList
    {
        public int UserId { get; set; } // UserId (Primary key)
        public int GoodId { get; set; } // GoodId (Primary key)
        public int Amount { get; set; } // Amount
    }

    // LikedList
    public class GetLikedList
    {
        public int UserId { get; set; } // UserId (Primary key)
        public int GoodId { get; set; } // GoodId (Primary key)
    }

    // SavedAdresses
    public class GetSavedAdress
    {
        public int UserId { get; set; } // UserId (Primary key)
        public string Title { get; set; } // Title (Primary key) (length: 20)
        public string City { get; set; } // City (length: 50)
        public string Street { get; set; } // Street (length: 50)
        public int House { get; set; } // House
        public int? Building { get; set; } // Building
        public int? Front { get; set; } // Front
        public int? Apartament { get; set; } // Apartament
    }

    // Ships
    public class GetShip
    {
        public int Id { get; set; } // ID (Primary key)
        public int UserId { get; set; } // UserId (Primary key)
        public int GoodId { get; set; } // GoodId (Primary key)
        public int? Amount { get; set; } // Amount
        public DateTime ShipDate { get; set; } // ShipDate
        public string Status { get; set; } // Status (length: 100)
    }

    // Users
    public class GetUser
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
    }

}