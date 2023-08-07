﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.StoreInfo
{
    public class StoreInfoModel : EntityBase
    {
        public new int? Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public string? Domain { get; set; }
        public int? Games_Count { get; set; }
        public string? Image_Background { get; set; }
    }
}