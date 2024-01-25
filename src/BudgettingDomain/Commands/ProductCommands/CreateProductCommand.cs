﻿using Budgetting.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgettingDomain.Commands.ProductCommands
{
    public class CreateProductCommand: IRequest<Product>
    {
        public CreateProductCommand()
        {

        }

        public CreateProductCommand(string id,
                                    string name,
                                    string colorCode,
                                    string shortName,
                                    string sKU,
                                    string description,
                                    string categoryId,
                                    int stock,
                                    decimal price,
                                    DateTime createdDate,
                                    string deliveryTimeSpan,
                                    string imageUrl,
                                    string createdBy)
        {
            Id = id;
            Name = name;
            ColorCode = colorCode;
            ShortName = shortName;
            SKU = sKU;
            Description = description;
            CategoryId = categoryId;
            Stock = stock;
            Price = price;
            CreatedDate = createdDate;
            DeliveryTimeSpan = deliveryTimeSpan;
            ImageUrl = imageUrl;
            CreatedBy = createdBy;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string ColorCode { get; set; }
        public string ShortName { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public string DeliveryTimeSpan { get; set; }
        public string ImageUrl { get; set; }
        public string CreatedBy { get; set; }

    }
}
