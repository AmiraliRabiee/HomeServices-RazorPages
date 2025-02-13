﻿using App.Domain.Core.Entites;
using App.Domain.Core.Entites.User;
using App.Domain.Core.Enums;
using System.ComponentModel.DataAnnotations;

public class Order
{
    [Key]
    public int Id { get; set; }
    [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
    public string? Description { get; set; }
    //تاریخ اجرا
    public DateTime CompletionDate { get; set; }
    // ساعت اجرا
    public DateTime RunningTime { get; set; }
    public DateTime? CreateAt { get; set; }
    public StausServiceEnum StausService { get; set; }
    [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative number.")]
    public float Price { get; set; }
    public int HomeServiceId { get; set; }
    public int CustomerId { get; set; }
    public int CityId { get; set; }
    public int ExpertId { get; set; }

    public City City { get; set; }
    public HomeService HomeService { get; set; }
    public Customer Customer { get; set; }
    public Expert Expert { get; set; }
}
