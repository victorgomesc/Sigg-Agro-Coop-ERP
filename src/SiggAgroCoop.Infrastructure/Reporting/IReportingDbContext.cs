using Microsoft.EntityFrameworkCore;
using SiggAgroCoop.Domain.Entities;

namespace SiggAgroCoop.Application.Interfaces.Reporting;

public interface IReportingDbContext
{
    DbSet<Field> Fields { get; }
    DbSet<Planting> Plantings { get; }
    DbSet<Harvest> Harvests { get; }
    DbSet<WorkOrder> WorkOrders { get; }
    DbSet<WorkOrderTool> WorkOrderTools { get; }
    DbSet<Employee> Employees { get; }
    DbSet<Tool> Tools { get; }
}
