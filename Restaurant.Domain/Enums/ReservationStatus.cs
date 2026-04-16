namespace Restaurant.Domain.Enums;

public enum ReservationStatus
{
    /// <summary>Ожидает подтверждения администратором</summary>
    Pending,

    /// <summary>Подтверждена администратором</summary>
    Confirmed,

    /// <summary>Отменена клиентом или администратором</summary>
    Cancelled,

    /// <summary>Истекла — клиент не пришёл в течение 15 минут</summary>
    Expired
}
