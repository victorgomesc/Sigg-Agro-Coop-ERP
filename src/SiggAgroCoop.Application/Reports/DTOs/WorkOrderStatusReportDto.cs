using SiggAgroCoop.Domain.Enums;

namespace SiggAgroCoop.Application.Reports.DTOs;

public record WorkOrderStatusReportDto(
    WorkOrderStatus Status,
    int Count,
    double Percentage
);
