namespace SiggAgroCoop.Application.Reports.DTOs;

public record EmployeePerformanceDto(
    Guid EmployeeId,
    string EmployeeName,
    int TotalWorkOrdersCompleted,
    double AvgCompletionTimeHours,
    IEnumerable<string> ToolsUsed
);
