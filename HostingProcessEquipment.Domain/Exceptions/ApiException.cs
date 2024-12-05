namespace HostingProcessEquipment.Domain.Exceptions;

public class ApiException(int httpStatus, int internalStatusCode) : Exception
{
    public int HttpStatusCode { get; private set; } = httpStatus;
    public int InternalStatusCode { get; private set; } = internalStatusCode;
}