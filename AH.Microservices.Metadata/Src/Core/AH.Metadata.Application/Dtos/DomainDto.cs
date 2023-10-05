﻿using AH.Shared.Application.Dtos;

namespace AH.Metadata.Application.Dtos;

public class DomainDto : BaseDto
{
    public string Name { get; set; }
    public List<CompanyDto> Companies { get; set; } = new();
}