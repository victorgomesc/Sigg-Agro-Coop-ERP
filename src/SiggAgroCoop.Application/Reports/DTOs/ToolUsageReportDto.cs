namespace SiggAgroCoop.Application.Reports.DTOs;

public record ToolUsageReportDto(
    Guid ToolId,
    string ToolName,
    int TotalWorkOrders,
    IEnumerable<string> EmployeesWhoUsed
);
