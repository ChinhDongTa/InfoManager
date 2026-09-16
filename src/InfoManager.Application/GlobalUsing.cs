global using FluentValidation;
global using InfoManager.Application.Common.Exceptions;
global using InfoManager.Application.Common.Handlers;
global using InfoManager.Application.Common.Interfaces;
global using InfoManager.Application.Common.Models;
global using InfoManager.Application.Extensions;
global using InfoManager.Domain.Entities;
global using InfoManager.Enum;
global using InfoManager.Enum.SFMS;
global using InfoManager.Helper;
global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Logging;
global using InfoManager.Shared.Models;
global using InfoManager.Shared.Dtos.Common;

// Entities
global using InfoManager.Domain.Entities.SFMS.Agricultural;
global using InfoManager.Domain.Entities.SFMS.Customers;
global using InfoManager.Domain.Entities.SFMS.HR;
global using InfoManager.Domain.Entities.SFMS.Economics;
global using InfoManager.Domain.Entities.SFMS.Monitoring;
global using InfoManager.Domain.Entities.SFMS.Issues;
global using InfoManager.Domain.Entities.SFMS.Planning;
global using InfoManager.Domain.Entities.SFMS.Production;
global using InfoManager.Domain.Entities.SFMS.Resources;
global using InfoManager.Domain.Entities.SFMS.Infrastructure;
global using InfoManager.Domain.Entities.Authentication;
global using InfoManager.Domain.Entities.Personal;
global using InfoManager.Domain.Entities.SFMS.Weather;
global using InfoManager.Domain.Entities.SFMS.Inventory;

// Dtos
global using InfoManager.Shared.Dtos.SFMS.Agricultural;
global using InfoManager.Shared.Dtos.SFMS.Customers;
global using InfoManager.Shared.Dtos.SFMS.HR;
global using InfoManager.Shared.Dtos.SFMS.Economics;
global using InfoManager.Shared.Dtos.SFMS.Monitoring;
global using InfoManager.Shared.Dtos.SFMS.Infrastructure;
global using InfoManager.Shared.Dtos.SFMS.Planning;
global using InfoManager.Shared.Dtos.SFMS.Production;
global using InfoManager.Shared.Dtos.SFMS.Issues;